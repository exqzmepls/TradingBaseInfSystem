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
    public partial class EmployeeCRUDForm : Form
    {
        private string _text;

        private InfSystemContext db;

        private DbSet<Employee> dbSet;

        QueryBuilderForm queryBuilderForm;

        public EmployeeCRUDForm()
        {
            InitializeComponent();
        }

        private void EmployeeCRUDForm_Load(object sender, EventArgs e)
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
            EmployeeDialog employeeDialog = new EmployeeDialog(new Employee());
            if (employeeDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    employeeBindingSource.Add(employeeDialog.Employee);
                    db.Entry(employeeDialog.Employee).State = EntityState.Added;
                    //dbSet.Local.Add(employeeDialog.Employee);
                    db.SaveChanges();
                    LoadEntry(employeeDialog.Employee);

                    employeeBindingSource.MoveLast();
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
            if (employeeBindingSource.Current != null)
            {
                if (InfSystemMessageBox.ConfirmDeleting() == DialogResult.Yes)
                {
                    try
                    {
                        object current = employeeBindingSource.Current;
                        employeeBindingSource.RemoveCurrent();
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
            if (employeeBindingSource.Current != null)
            {
                EmployeeDialog employeeDialog = new EmployeeDialog((Employee)employeeBindingSource.Current);
                if (employeeDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.Entry(employeeDialog.Employee).State = EntityState.Modified;
                        db.SaveChanges();
                        LoadEntry(employeeDialog.Employee);

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
                    Query<Employee> query = new Query<Employee>(dbSet.Local.ToList(), queryBuilderForm.EntityProperties, queryBuilderForm.Conditions);
                    employeeBindingSource.DataSource = query.Execute();
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
            PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(typeof(Employee)));
            if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
            {
                if (MainForm.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(MainForm.openFileDialog.FileName), propertiesSelectForm.SelectedProperties, (IList)employeeBindingSource.DataSource, typeof(Employee));
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

                dbSet = db.Employees;
                dbSet.Load();
                
                foreach (Employee e in dbSet.Local) LoadEntry(e);

                employeeBindingSource.DataSource = dbSet.Local.ToBindingList();

                queryBuilderForm = new QueryBuilderForm(EntityProperty.GetProperties(typeof(Employee)));
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }

        private void LoadEntry(Employee employee)
        {
            db.Entry(employee).Reference(x => x.Person).Load();
            db.Entry(employee).Reference(x => x.Position).Load();
        } 
    }
}
