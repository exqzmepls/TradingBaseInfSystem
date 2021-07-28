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
    public partial class PersonCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<Person> dbSet;

        QueryBuilderForm queryBuilderForm;

        public PersonCRUDForm()
        {
            InitializeComponent();
        }

        private void PersonCRUDForm_Load(object sender, EventArgs e)
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
            PersonDialog personDialog = new PersonDialog(new Person());
            if (personDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    personBindingSource.Add(personDialog.Person);
                    db.Entry(personDialog.Person).State = EntityState.Added;
                    db.SaveChanges();

                    personBindingSource.MoveLast();
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
            if (personBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = personBindingSource.Current;
                        personBindingSource.RemoveCurrent();
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
            if (personBindingSource.Current != null)
            {
                PersonDialog personDialog = new PersonDialog((Person)personBindingSource.Current);
                if (personDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.Entry(personDialog.Person).State = EntityState.Modified;
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
                    Query<Person> query = new Query<Person>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    personBindingSource.DataSource = query.Execute();
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
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(Person)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)personBindingSource.DataSource, typeof(Person));
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
                dbSet = db.People;
                dbSet.Load();
                personBindingSource.DataSource = dbSet.Local.ToBindingList();
                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(Person)));
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }
    }
}
