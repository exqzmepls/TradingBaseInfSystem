using DbConnection;
using QueryBuilder;
using ReportBuilder;
using System;
using System.Collections;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class ProductCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<Product> dbSet;

        private QueryBuilderForm queryBuilderForm;

        public ProductCRUDForm()
        {
            InitializeComponent();
        }

        private void ProductCRUDForm_Load(object sender, EventArgs e)
        {
            SetLimits(MainForm.user);
            _text = Text;
            LoadData();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            ProductDialog productDialog = new ProductDialog(new Product());
            if (productDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    productBindingSource.Add(productDialog.Product);
                    db.Entry(productDialog.Product).State = EntityState.Added;
                    db.SaveChanges();
                    LoadEntry(productDialog.Product);

                    InfSystemMessageBox.ShowSuccessAdding();

                    if (MessageBox.Show("Вы хотите установить цену на добавленный товар?", "Добавление цены", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PriceDialog priceDialog = new PriceDialog(new ProductPrice() { ProductId = productDialog.Product.Id });
                        if (priceDialog.ShowDialog() == DialogResult.OK)
                        {
                            db.ProductPrices.Add(priceDialog.ProductPrice);
                            db.SaveChanges();
                            InfSystemMessageBox.ShowSuccessAdding();
                        }
                    }

                    productBindingSource.MoveLast();
                    dataGridView.Refresh();
                }
                catch (Exception ex)
                {
                    InfSystemMessageBox.ShowError(ex);
                }
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (productBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = productBindingSource.Current;
                        productBindingSource.RemoveCurrent();
                        db.Entry(current).State = EntityState.Deleted;
                        db.SaveChanges();

                        InfSystemMessageBox.ShowSuccessDeleting();
                    }
                    catch (Exception ex)
                    {
                        InfSystemMessageBox.ShowError(ex);
                    }
                }
            }
        }

        private void updateToolStripButton_Click(object sender, EventArgs e)
        {
            if (productBindingSource.Current != null)
            {
                ProductDialog productDialog = new ProductDialog((Product)productBindingSource.Current);
                if (productDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.Entry(productDialog.Product).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadEntry(productDialog.Product);

                        dataGridView.Refresh();
                        InfSystemMessageBox.ShowSuccessUpdating();
                    }
                    catch (Exception ex)
                    {
                        InfSystemMessageBox.ShowError(ex);
                    }
                }
            }
        }

        private void filterToolStripButton_Click(object sender, EventArgs e)
        {
            ShowFilter();
        }

        internal void ShowFilter()
        {
            if (queryBuilderForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Query<Product> query = new Query<Product>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    productBindingSource.DataSource = query.Execute();
                    Text = _text + " - Поиск";
                }
                catch (Exception ex)
                {
                    InfSystemMessageBox.ShowError(ex);
                }
            }
        }

        private void reportToolStripButton_Click(object sender, EventArgs e)
        {
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(Product)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)productBindingSource.DataSource, typeof(Product));
                        report.Create();

                        MessageBox.Show("Отчет успешно создан");

                        System.Diagnostics.Process.Start(MainForm.openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        InfSystemMessageBox.ShowError(ex);
                    }
                }
            }
        }

        private void LoadData()
        {
            Text = _text;
            try
            {
                db = new InfSystemContext();
                db.Configuration.LazyLoadingEnabled = true;
                dbSet = db.Products;
                dbSet.Load();
                foreach (Product p in dbSet.Local)
                {
                    LoadEntry(p);
                }
                productBindingSource.DataSource = dbSet.Local.ToBindingList();

                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(Product)));
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
            
        }

        private void LoadEntry(Product product)
        {
            db.Entry(product).Reference(x => x.Unit).Load();
            db.Entry(product).Reference(x => x.Supplier).Load();
            db.Entry(product).Reference(x => x.Category).Load();
            db.Entry(product).Collection(x => x.Prices).Load();
        }

        private void SetLimits(User user)
        {
            if (user is User)
            {
                addToolStripButton.Visible = false;
                toolStripSeparator2.Visible = false;
                deleteToolStripButton.Visible = false;
                toolStripSeparator3.Visible = false;
                updateToolStripButton.Visible = false;
                toolStripSeparator4.Visible = false;
            }
            if (user is SuperUser)
            {
                addToolStripButton.Visible = true;
                toolStripSeparator2.Visible = true;
                deleteToolStripButton.Visible = true;
                toolStripSeparator3.Visible = true;
                updateToolStripButton.Visible = true;
                toolStripSeparator4.Visible = true;
            }
        }
    }
}
