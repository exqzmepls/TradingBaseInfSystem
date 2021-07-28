using System;
using System.Windows.Forms;
using DbConnection;

namespace InfSystem
{
    public partial class ContactDialog : Form
    {
        private bool _isNameCorrect = false, _isPhoneCorrect = false;
        public ContactDialog(Contact contact)
        {
            InitializeComponent();

            Contact = contact;
        }

        public Contact Contact { get; private set; }

        private void ContactDialog_Load(object sender, EventArgs e)
        {
            if (Contact.Id == 0)
            {
                if (Contact is Customer) Text = "Новый клиент";
                else if (Contact is Supplier) Text = "Новый поставщик";
            }
            else Text = Contact.Name;
            
            nameTextBox.Text = Contact.Name;
            phoneTextBox.Text = Contact.PhoneNumber;
        }

        private void ContactDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                Contact.Name = nameTextBox.Text;
                Contact.PhoneNumber = phoneTextBox.Text;
            }
        }
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            _isNameCorrect = IsCorrect(nameTextBox.Text);
            SetOkButtonState();
        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            _isPhoneCorrect = IsCorrect(phoneTextBox.Text);
            SetOkButtonState();
        }

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsCorrect(string str)
        {
            return !(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str));
        }

        private void SetOkButtonState()
        {
            okButton.Enabled = _isNameCorrect && _isPhoneCorrect;
        }
    }
}
