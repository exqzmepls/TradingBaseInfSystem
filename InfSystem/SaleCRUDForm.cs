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
    public partial class SaleCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<Sale> dbSet;

        private QueryBuilderForm queryBuilderForm;

        public SaleCRUDForm()
        {
            InitializeComponent();
        }

        private void SaleCRUDForm_Load(object sender, EventArgs e)
        {
            _text = Text;
            LoadData();

            SetLimits(MainForm.user);
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            SaleDialog saleDialog = new SaleDialog(new Sale());
            if (saleDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Sale sale = saleDialog.Sale;
                    saleBindingSource.Add(sale);
                    db.Entry(sale).State = EntityState.Added;
                    db.SaveChanges();
                    InfSystemMessageBox.ShowSuccessAdding();

                    SaleProductsForm saleProductsForm = new SaleProductsForm(saleDialog.Sale);
                    if (saleProductsForm.ShowDialog() == DialogResult.OK)
                    {
                        db.SoldProducts.AddRange(saleProductsForm.SoldProducts);
                        db.SaveChanges();

                        MessageBox.Show("Товарные позиции успешно добавлены в состав продажи");
                    }

                    saleBindingSource.MoveLast();
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
            if (saleBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = saleBindingSource.Current;
                        saleBindingSource.RemoveCurrent();
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
            if (saleBindingSource.Current != null)
            {
                SaleDialog saleDialog = new SaleDialog((Sale)saleBindingSource.Current);
                if (saleDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.Entry(saleDialog.Sale).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadEntry(saleDialog.Sale);

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
                    Query<Sale> query = new Query<Sale>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    saleBindingSource.DataSource = query.Execute();
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
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(Sale)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)saleBindingSource.DataSource, typeof(Sale));
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
                dbSet = db.Sales;
                dbSet.Load();
                foreach (Sale s in dbSet.Local)
                {
                    LoadEntry(s);
                }
                saleBindingSource.DataSource = dbSet.Local.ToBindingList();

                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(Sale)));
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }

        private void LoadEntry(Sale sale)
        {
            db.Entry(sale).Collection(x => x.SoldProducts).Load();
            foreach (SoldProduct sp in sale.SoldProducts)
            {
                db.Entry(sp).Reference(x => x.ProductPrice).Load();
            }
        }

        private void SetLimits(User user)
        {
            if (user is User)
            {
                deleteToolStripButton.Visible = false;
                toolStripSeparator3.Visible = false;
                updateToolStripButton.Visible = false;
                toolStripSeparator4.Visible = false;
            }
            if (user is FavoredUser)
            {
                updateToolStripButton.Visible = true;
                toolStripSeparator4.Visible = true;
                deleteToolStripButton.Visible = true;
                toolStripSeparator3.Visible = true;
            }
        }
    }
}
