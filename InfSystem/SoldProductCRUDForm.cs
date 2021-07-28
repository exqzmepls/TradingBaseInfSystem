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
    public partial class SoldProductCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<SoldProduct> dbSet;

        QueryBuilderForm queryBuilderForm;

        public SoldProductCRUDForm()
        {
            InitializeComponent();
        }

        private void SoldProductCRUDForm_Load(object sender, EventArgs e)
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
            SoldProductDialog soldProductDialog = new SoldProductDialog(new SoldProduct());
            if (soldProductDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    soldProductBindingSource.Add(soldProductDialog.SoldProduct);
                    db.Entry(soldProductDialog.SoldProduct).State = EntityState.Added;
                    //dbSet.Local.Add(employeeDialog.Employee);
                    db.SaveChanges();
                    LoadEntry(soldProductDialog.SoldProduct);

                    soldProductBindingSource.MoveLast();
                    dataGridView.Refresh();
                    InfSystemMessageBox.ShowSuccessAdding();
                }
                catch (Exception ex)
                {
                    InfSystemMessageBox.ShowError(ex);
                }
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (soldProductBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = soldProductBindingSource.Current;
                        soldProductBindingSource.RemoveCurrent();
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
            if (soldProductBindingSource.Current != null)
            {
                SoldProductDialog soldProductDialog = new SoldProductDialog((SoldProduct)soldProductBindingSource.Current);
                if (soldProductDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.Entry(soldProductDialog.SoldProduct).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadEntry(soldProductDialog.SoldProduct);

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
                    Query<SoldProduct> query = new Query<SoldProduct>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    soldProductBindingSource.DataSource = query.Execute();
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
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(SoldProduct)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)soldProductBindingSource.DataSource, typeof(SoldProduct));
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

                dbSet = db.SoldProducts;
                dbSet.Load();

                foreach (var p in dbSet.Local) LoadEntry(p);

                soldProductBindingSource.DataSource = dbSet.Local.ToBindingList();

                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(SoldProduct)));
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }

        private void LoadEntry(SoldProduct soldProduct)
        {
            db.Entry(soldProduct).Reference(x => x.ProductPrice).Load();
            db.Entry(soldProduct.ProductPrice).Reference(x => x.Product).Load();
        }

        private void SetLimits(User user)
        {
            if (user is User)
            {
                addToolStripButton.Visible = false;
                toolStripSeparator1.Visible = false;
                deleteToolStripButton.Visible = false;
                toolStripSeparator3.Visible = false;
                updateToolStripButton.Visible = false;
                toolStripSeparator4.Visible = false;
            }
            if (user is FavoredUser)
            {
                addToolStripButton.Visible = true;
                toolStripSeparator1.Visible = true;
                updateToolStripButton.Visible = true;
                toolStripSeparator4.Visible = true;
                deleteToolStripButton.Visible = true;
                toolStripSeparator3.Visible = true;
            }
        }
    }
}
