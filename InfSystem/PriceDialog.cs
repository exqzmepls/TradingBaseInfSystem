using DbConnection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class PriceDialog : Form
    {
        private bool isRubCorrect = false, isKopCorrect = true;

        public ProductPrice ProductPrice { get; private set; }

        public PriceDialog(ProductPrice price)
        {
            InitializeComponent();

            ProductPrice = price;
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void priceRubTextBox_TextChanged(object sender, EventArgs e)
        {
            isRubCorrect = !(string.IsNullOrWhiteSpace(priceRubTextBox.Text) || string.IsNullOrEmpty(priceRubTextBox.Text));
            okButton.Enabled = isRubCorrect && isKopCorrect;
        }

        private void priceKopTextBox_TextChanged(object sender, EventArgs e)
        {
            isKopCorrect = !(string.IsNullOrWhiteSpace(priceKopTextBox.Text) || string.IsNullOrEmpty(priceKopTextBox.Text));
            okButton.Enabled = isRubCorrect && isKopCorrect;
        }

        private void PriceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                ProductPrice.ProductId = (int)productComboBox.SelectedValue;
                ProductPrice.ValuePerOneUnit = double.Parse(priceRubTextBox.Text) + double.Parse(priceKopTextBox.Text) / 100;
                ProductPrice.SettingDate = settingDateTimePicker.Value.Date;
            }
        }

        private void PriceDialog_Load(object sender, EventArgs e)
        {
            if (ProductPrice.Id == 0) Text = "Новая цена";
            else Text = "Назначенная цена";

            LoadData();

            if (productBindingSource.Current == null)
            {
                MessageBox.Show("Нет доступных товаров");
                Close();
            }

            if (ProductPrice.ProductId != 0)
            {
                productComboBox.Enabled = false;
                productComboBox.SelectedValue = ProductPrice.ProductId;
            }

            if (ProductPrice.Id != 0)
            {
                priceRubTextBox.Text = ((int)ProductPrice.ValuePerOneUnit).ToString();
                priceKopTextBox.Text = ((int)((ProductPrice.ValuePerOneUnit - (int)ProductPrice.ValuePerOneUnit) * 100)).ToString();
                settingDateTimePicker.Value = ProductPrice.SettingDate;
            }
        }

        private void LoadData()
        {
            try
            {
                using (InfSystemContext db = new InfSystemContext())
                {
                    productBindingSource.DataSource = db.Products.ToList();
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
