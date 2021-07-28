using DbConnection;
using ReportBuilder;
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
    public partial class PropertiesSelectForm : Form
    {
        public string ReportName { get; private set; }
        public List<EntityProperty> SelectedProperties { get; private set; }

        private List<EntityProperty> _defaultProperties;

        public PropertiesSelectForm(List<EntityProperty> properties)
        {
            InitializeComponent();

            _defaultProperties = properties;
        }

        private void PropertiesSelectForm_Load(object sender, EventArgs e)
        {
            foreach (EntityProperty property in _defaultProperties)
            {
                propertyCheckedListBox.SetItemChecked(propertyCheckedListBox.Items.Add(property.HeaderText), true);
            }
        }

        private void PropertiesSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (propertyCheckedListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Выберите хотя бы 1 столбец", "Пустой отчет", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
                else
                {
                    ReportName = reportNameTextBox.Text;
                    SelectedProperties = new List<EntityProperty>();
                    foreach (int i in propertyCheckedListBox.CheckedIndices) SelectedProperties.Add(_defaultProperties[i]);
                }
            }
        }

        private void reportNameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !(string.IsNullOrEmpty(reportNameTextBox.Text) || string.IsNullOrWhiteSpace(reportNameTextBox.Text));
        }
    }
}
