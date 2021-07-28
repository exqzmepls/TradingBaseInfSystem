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
    public partial class SupplierCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<Supplier> dbSet;

        QueryBuilderForm queryBuilderForm;

        public SupplierCRUDForm()
        {
            InitializeComponent();

            SetLimits(MainForm.user);
        }

        private void SupplierCRUDForm_Load(object sender, EventArgs e)
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
            ContactDialog contactDialog = new ContactDialog(new Supplier());
            if (contactDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    supplierBindingSource.Add(contactDialog.Contact);
                    db.Entry(contactDialog.Contact).State = EntityState.Added;
                    db.SaveChanges();

                    supplierBindingSource.MoveLast();
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
            if (supplierBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = supplierBindingSource.Current;
                        supplierBindingSource.RemoveCurrent();
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
            if (supplierBindingSource.Current != null)
            {
                ContactDialog contactDialog = new ContactDialog((Supplier)supplierBindingSource.Current);
                if (contactDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.Entry(contactDialog.Contact).State = EntityState.Modified;
                        db.SaveChanges();

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
                    Query<Supplier> query = new Query<Supplier>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    supplierBindingSource.DataSource = query.Execute();
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
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(Supplier)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)supplierBindingSource.DataSource, typeof(Supplier));
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
                dbSet = db.Suppliers;
                dbSet.Load();
                supplierBindingSource.DataSource = dbSet.Local.ToBindingList();
                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(Supplier)));
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
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
            }
            if (user is SuperUser)
            {
                deleteToolStripButton.Visible = true;
                toolStripSeparator3.Visible = true;
            }
        }
    }
}
