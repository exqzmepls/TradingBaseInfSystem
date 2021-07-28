using DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InfSystem
{
    public partial class SoldProductDialog : Form
    {
        private List<Product> products;

        public SoldProduct SoldProduct { get; private set; }

        public SoldProductDialog(SoldProduct soldProduct)
        {
            InitializeComponent();
            SoldProduct = soldProduct;
        }

        private void SoldProductDialog_Load(object sender, EventArgs e)
        {
            Text = "Товарная позиция";
            LoadData();
        }

        private List<ProductPrice> GetPrices(DateTime date)
        {
            List<ProductPrice> result = new List<ProductPrice>();
            foreach (var p in products)
            {
                ProductPrice price = p.PriceOnDate(date);
                if (price != null) result.Add(price);
            }
            return result;
        }

        private void LoadData()
        {
            try
            {
                using (InfSystemContext db = new InfSystemContext())
                {
                    products = db.Products.ToList();
                    saleBindingSource.DataSource = db.Sales.ToList();
                    foreach (var p in products) db.Entry(p).Collection(x => x.Prices).Load();
                }

                if (saleBindingSource.Current == null)
                {
                    MessageBox.Show("Нет совершенных продаж");
                    Close();
                }

                if (SoldProduct.SaleId != 0)
                {
                    saleComboBox.SelectedValue = SoldProduct.SaleId;
                    saleComboBox.Enabled = false;
                }

                productPriceBindingSource.DataSource = GetPrices((saleBindingSource.Current as Sale).Date);

                if (SoldProduct.ProductPriceId != 0)
                {
                    productComboBox.SelectedValue = SoldProduct.ProductPriceId;
                    productComboBox.Enabled = false;
                }

                amountTextBox.Text = SoldProduct.Amount.ToString();
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }

        private void saleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productComboBox.DataSource = GetPrices((saleComboBox.SelectedItem as Sale).Date);
            okButton.Enabled = CheckAmount(amountTextBox.Text) && productPriceBindingSource.Current != null;
        }

        private void SoldProductDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                SoldProduct.SaleId = (int)saleComboBox.SelectedValue;
                SoldProduct.ProductPriceId = (int)productComboBox.SelectedValue;
                SoldProduct.Amount = double.Parse(amountTextBox.Text);
            }
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = productPriceBindingSource.Current != null && CheckAmount(amountTextBox.Text);
        }

        private void amountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && !char.IsControl(number) && number != 44)
            {
                e.Handled = true;
            }
        }

        private bool CheckAmount(string text)
        {
            return !(string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)) && double.TryParse(text, out double d) && d > 0;
        }
    }
}
