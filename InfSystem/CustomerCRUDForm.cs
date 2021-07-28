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
    public partial class CustomerCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<Customer> dbSet;

        QueryBuilderForm queryBuilderForm;

        public CustomerCRUDForm()
        {
            InitializeComponent();

            SetLimits(MainForm.user);
        }

        private void CustomerCRUDForm_Load(object sender, EventArgs e)
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
            ContactDialog contactDialog = new ContactDialog(new Customer());
            if (contactDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    customerBindingSource.Add(contactDialog.Contact);
                    db.Entry(contactDialog.Contact).State = EntityState.Added;
                    //dbSet.Local.Add((Customer)contactDialog.Contact);
                    db.SaveChanges();

                    customerBindingSource.MoveLast();
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
            if (customerBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = customerBindingSource.Current;
                        customerBindingSource.RemoveCurrent();
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
            if (customerBindingSource.Current != null)
            {
                ContactDialog contactDialog = new ContactDialog((Customer)customerBindingSource.Current);
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

        private void reportToolStripButton_Click(object sender, EventArgs e)
        {
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(Customer)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)customerBindingSource.DataSource, typeof(Customer));
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
                    Query<Customer> query = new Query<Customer>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    customerBindingSource.DataSource = query.Execute();
                    Text = _text + " - Поиск";
                }
                catch (Exception ex)
                {
                    InfSystemMessageBox.ShowError(ex);
                }
            }
        }

        private void LoadData()
        {
            Text = _text;
            try
            {
                db = new InfSystemContext();
                dbSet = db.Customers;
                dbSet.Load();
                customerBindingSource.DataSource = dbSet.Local.ToBindingList();
                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(Customer)));
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
