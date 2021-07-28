using System;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class SubstringInputDialog : Form
    {
        public string Substring { get; private set; }

        public SubstringInputDialog(string substring = null)
        {
            InitializeComponent();
            textBox.Text = substring;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !(string.IsNullOrEmpty(textBox.Text) || string.IsNullOrWhiteSpace(textBox.Text));
        }

        private void SubstringInputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                Substring = textBox.Text;
            }
        }
    }
}
