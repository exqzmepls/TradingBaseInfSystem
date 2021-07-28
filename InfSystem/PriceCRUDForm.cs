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
    public partial class PriceCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<ProductPrice> dbSet;

        private QueryBuilderForm queryBuilderForm;

        public PriceCRUDForm()
        {
            InitializeComponent();
        }

        private void PriceCRUDForm_Load(object sender, EventArgs e)
        {
            _text = Text;
            LoadData();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            PriceDialog priceDialog = new PriceDialog(new ProductPrice());
            if (priceDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProductPrice price = priceDialog.ProductPrice;
                    if (db.Products.Find(price.ProductId).ContainsPriceOnDate(price.SettingDate))
                    {
                        MessageBox.Show("Невозможно назначить цену. На выбранную дату уже назначено изменение цены.");
                    }
                    else
                    {
                        productPriceBindingSource.Add(price);
                        db.Entry(price).State = EntityState.Added;
                        db.SaveChanges();

                        productPriceBindingSource.MoveLast();
                        dataGridView.Refresh();
                        InfSystemMessageBox.ShowSuccessAdding();
                    }
                }
                catch (Exception ex)
                {
                    InfSystemMessageBox.ShowError(ex);
                }
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (productPriceBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = productPriceBindingSource.Current;
                        productPriceBindingSource.RemoveCurrent();
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
            if (productPriceBindingSource.Current != null)
            {
                PriceDialog priceDialog = new PriceDialog((ProductPrice)productPriceBindingSource.Current);
                if (priceDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.Entry(priceDialog.ProductPrice).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadEntry(priceDialog.ProductPrice);

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
                    Query<ProductPrice> query = new Query<ProductPrice>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    productPriceBindingSource.DataSource = query.Execute();
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
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(ProductPrice)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)productPriceBindingSource.DataSource, typeof(ProductPrice));
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
                dbSet = db.ProductPrices;
                dbSet.Load();
                foreach (ProductPrice p in dbSet.Local)
                {
                    LoadEntry(p);
                }
                productPriceBindingSource.DataSource = dbSet.Local.ToBindingList();

                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(ProductPrice)));
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }

        }

        private void LoadEntry(ProductPrice product)
        {
            db.Entry(product).Reference(x => x.Product).Load();
        }
    }
}
