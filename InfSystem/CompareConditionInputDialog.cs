using QueryBuilder;
using System;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class CompareConditionInputDialog : Form
    {
        private object _type;

        private bool isInt, isDouble, isDate;

        public IComparable Value { get; private set; }

        public Operator Operator { get; private set; }

        public CompareConditionInputDialog(Type type)
        {
            InitializeComponent();
            _type = type;
        }

        private void DoubleInputDialog_Load(object sender, EventArgs e)
        {
            operatorBindingSource.DataSource = Operator.signs;
            if (typeof(double).Equals(_type))
            {
                isDouble = true;
                valueTextBox.KeyPress += new KeyPressEventHandler(valueTextBoxDouble_KeyPress);
                valueTextBox.TextChanged += new EventHandler(valueTextBoxDouble_TextChanged);
            }
            else
            {
                if (typeof(int).Equals(_type))
                {
                    isInt = true;
                    valueTextBox.KeyPress += new KeyPressEventHandler(valueTextBoxInt_KeyPress);
                    valueTextBox.TextChanged += new EventHandler(valueTextBoxInt_TextChanged);
                }
                else
                {
                    if (typeof(DateTime).Equals(_type) || typeof(DateTime?).Equals(_type))
                    {
                        isDate = true;
                        valueTextBox.Visible = false;
                        dateTimePicker.Visible = true;
                        okButton.Enabled = true;
                    }
                    else Close();
                }
            }

        }

        private void valueTextBoxDouble_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = CheckText(valueTextBox.Text) && double.TryParse(valueTextBox.Text, out double d);
        }

        private void valueTextBoxInt_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = CheckText(valueTextBox.Text) && int.TryParse(valueTextBox.Text, out int i);
        }

        private void valueTextBoxDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && !char.IsControl(number) && number != 44)
            {
                e.Handled = true;
            }
        }

        private void valueTextBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && !char.IsControl(number))
            {
                e.Handled = true;
            }
        }

        private void DoubleInputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (isDate) Value = dateTimePicker.Value.Date;
                else
                {
                    if (isDouble) Value = double.Parse(valueTextBox.Text);
                    else
                    {
                        if (isInt) Value = int.Parse(valueTextBox.Text);
                    }
                }
                Operator = new Operator((string)operatorBindingSource.Current);
            }
        }

        private bool CheckText(string text)
        {
            return !(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text));
        }
    }
}
