using DbConnection;
using System;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class PersonDialog : Form
    {
        private bool _isNameCorrect = false, _isSurnameCorrect = false, _isMiddleNameCorrect = false, _isPhoneCorrect = false;
        public Person Person { get; private set; }

        public PersonDialog(Person person)
        {
            InitializeComponent();

            Person = person;
        }

        private void PersonDialog_Load(object sender, EventArgs e)
        {
            if (Person.Id == 0)
            {
                Text = "Новые персональные данные";
            }
            else Text = Person.ToString();

            nameTextBox.Text = Person.Name;
            surnameTextBox.Text = Person.Surname;
            middlenameTextBox.Text = Person.MiddleName;
            phoneTextBox.Text = Person.PhoneNumber;
            if (Person.Id != 0) dobPicker.Value = Person.DOB;
        }

        private void PersonDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                Person.Name = nameTextBox.Text;
                Person.Surname = surnameTextBox.Text;
                Person.MiddleName = middlenameTextBox.Text;
                Person.PhoneNumber = phoneTextBox.Text;
                Person.DOB = dobPicker.Value.Date;
            }
        }

        private void surnameTextBox_TextChanged(object sender, EventArgs e)
        {
            _isSurnameCorrect = IsCorrect(surnameTextBox.Text);
            SetOkButtonState();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            _isNameCorrect = IsCorrect(nameTextBox.Text);
            SetOkButtonState();
        }

        private void middlenameTextBox_TextChanged(object sender, EventArgs e)
        {
            _isMiddleNameCorrect = IsCorrect(middlenameTextBox.Text);
            SetOkButtonState();
        }

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            _isPhoneCorrect = IsCorrect(phoneTextBox.Text);
            SetOkButtonState();
        }

        private bool IsCorrect(string str)
        {
            return !(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str));
        }

        private void SetOkButtonState()
        {
            okButton.Enabled = _isNameCorrect && _isSurnameCorrect && _isMiddleNameCorrect && _isPhoneCorrect;
        }
    }
}
