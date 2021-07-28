using DbConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class ForeignKeyInputDialog : Form
    {
        private Type _entityType;

        public int Value { get; private set; }

        public string View { get; private set; }

        public ForeignKeyInputDialog(Type entityType)
        {
            InitializeComponent();
            _entityType = entityType;
        }

        private void ForeignKeyInputDialog_Load(object sender, EventArgs e)
        {
            try
            {
                using(InfSystemContext db = new InfSystemContext())
                {
                    db.Configuration.LazyLoadingEnabled = true;
                    db.Set(_entityType).Load();
                    comboBox.DataSource = db.Set(_entityType).Local;
                    comboBox.ValueMember = "Id";
                    comboBox.DisplayMember = "View";
                }
            }
            catch(Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }

        private void ForeignKeyInputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (comboBox.SelectedItem != null)
                {
                    Value = (int)comboBox.SelectedValue;
                    View = comboBox.SelectedItem.ToString();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
