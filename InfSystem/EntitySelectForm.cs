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
    public partial class EntitySelectForm : Form
    {
        public EntitySelectForm()
        {
            InitializeComponent();
        }

        public object EntityType { get; private set; }

        private void EntitySelectForm_Load(object sender, EventArgs e)
        {
            SetLimits();

            soldProductsRadioButton.Tag = typeof(SoldProduct);
            salesRadioButton.Tag = typeof(Sale);
            productsRadioButton.Tag = typeof(Product);
            supplierRadioButton.Tag = typeof(Supplier);
            customerRadioButton.Tag = typeof(Customer);
            pricesRadioButton.Tag = typeof(ProductPrice);
            employeesRadioButton.Tag = typeof(Employee);
            peopleRadioButton.Tag = typeof(Person);
        }

        private void EntitySelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                foreach (RadioButton rdo in groupBox.Controls.OfType<RadioButton>())
                {
                    if (rdo.Checked)
                    {
                        EntityType = rdo.Tag;
                        break;
                    }
                }
            }
        }

        private void SetLimits()
        {
            if (MainForm.user is User)
            {
                productsRadioButton.Visible = false;
                pricesRadioButton.Visible = false;
                supplierRadioButton.Visible = false;
                employeesRadioButton.Visible = false;
                peopleRadioButton.Visible = false;

                if (MainForm.user is FavoredUser)
                {
                    productsRadioButton.Visible = true;
                    pricesRadioButton.Visible = true;

                    if (MainForm.user is SuperUser)
                    {
                        employeesRadioButton.Visible = true;
                        peopleRadioButton.Visible = true;
                        supplierRadioButton.Visible = true;
                    }
                }
            }
        }
    }
}
