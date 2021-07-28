using DbConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class SaleDialog : Form
    {
        public Sale Sale { get; private set; }

        public SaleDialog(Sale sale)
        {
            InitializeComponent();
            Sale = sale;
        }

        private void SaleDialog_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (InfSystemContext db = new InfSystemContext())
                {
                    customerBindingSource.DataSource = db.Customers.ToList();
                    employeeBindingSource.DataSource = db.Employees.ToList();
                    foreach (var employee in db.Employees.ToList())
                    {
                        db.Entry(employee).Reference(x => x.Person).Load();
                        db.Entry(employee).Reference(x => x.Position).Load();
                    }
                }

                if (employeeBindingSource.Current == null)
                {
                    MessageBox.Show("Нет доступных сотрудников");
                    Close();
                }

                if (Sale.Id == 0) Text = "Новая продажа";
                else Text = Sale.View;

                if (Sale.Id != 0)
                {
                    customerComboBox.SelectedValue = Sale.CustomerId;
                    employeeComboBox.SelectedValue = Sale.EmployeeId;
                    dateTimePicker.Value = Sale.Date;
                }
                
                if (!(MainForm.user is FavoredUser))
                {
                    employeeComboBox.SelectedValue = MainForm.user.Id;
                    employeeComboBox.Enabled = false;
                }

                if (customerBindingSource.Current == null)
                {
                    if (MessageBox.Show("Нет записей о покупателях. Хотите добавить данные?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ContactDialog contactDialog = new ContactDialog(new Customer());
                        if (contactDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                using (InfSystemContext db = new InfSystemContext())
                                {
                                    db.Customers.Add((Customer)contactDialog.Contact);
                                    db.SaveChanges();
                                }

                                InfSystemMessageBox.ShowSuccessAdding();
                            }
                            catch (Exception ex)
                            {
                                InfSystemMessageBox.ShowError(ex);
                                Close();
                            }
                            LoadData();
                        }
                        else
                        {
                            Close();
                        }
                    }
                    else
                    {
                        Close();
                    }
                }

            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }

        private void SaleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                Sale.CustomerId = (int)customerComboBox.SelectedValue;
                Sale.EmployeeId = (int)employeeComboBox.SelectedValue;
                Sale.Date = dateTimePicker.Value.Date;
            }
        }
    }
}
