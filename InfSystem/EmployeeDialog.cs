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
    public partial class EmployeeDialog : Form
    {
        public Employee Employee { get; private set; }

        public EmployeeDialog(Employee employee)
        {
            InitializeComponent();

            Employee = employee;
        }

        private void EmployeeDialog_Load(object sender, EventArgs e)
        {
            if (Employee.Id == 0) Text = "Новый сотрудник";
            else Text = Employee.View;

            LoadData();

            if (positionBindingSource.Current == null)
            {
                MessageBox.Show("Нет доступных должностей");
                Close();
            }

            if (personBindingSource.Current == null)
            {
                if (MessageBox.Show("Нет персональных данных сотрудников. Хотите добавить данные?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PersonDialog personDialog = new PersonDialog(new Person());
                    if (personDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (InfSystemContext db = new InfSystemContext())
                            {
                                db.People.Add(personDialog.Person);
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

            if (Employee.Id != 0)
            {
                positionComboBox.SelectedValue = Employee.PositionId;
                personComboBox.SelectedValue = Employee.PersonId;
                startDatePicker.Value = Employee.EntranceDate;
                if (Employee.LeaveDate != null)
                {
                    endDateTimePicker.Value = (DateTime)Employee.LeaveDate;
                    setLeavingDateRadioButton.Checked = true;
                }
            }
        }

        private void EmployeeDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (setLeavingDateRadioButton.Checked && endDateTimePicker.Value.Date < startDatePicker.Value.Date)
                {
                    MessageBox.Show("Дата ухода с работы не может быть раньше чем дата начала работы!", "Недопустимые значения дат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    endDateTimePicker.Focus();
                    e.Cancel = true;
                }
                else
                {
                    try
                    {
                        Employee.PositionId = (int)positionComboBox.SelectedValue;
                        Employee.PersonId = (int)personComboBox.SelectedValue;
                        Employee.EntranceDate = startDatePicker.Value.Date;
                        if (setLeavingDateRadioButton.Checked) Employee.LeaveDate = endDateTimePicker.Value.Date;
                        else Employee.LeaveDate = null;
                    }
                    catch
                    {
                        e.Cancel = true;
                        MessageBox.Show("Не все обязательные поля были заполнены!");
                    }
                }
            }
        }

        private void setLeavingDateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            endDateTimePicker.Enabled = setLeavingDateRadioButton.Checked;
        }

        private void LoadData()
        {
            try
            {
                using (InfSystemContext db = new InfSystemContext())
                {
                    personBindingSource.DataSource = db.People.ToList();
                    positionBindingSource.DataSource = db.Positions.ToList();
                }
            }
            catch (Exception e)
            {
                InfSystemMessageBox.ShowError(e);
                Close();
            }
        }
    }
}
