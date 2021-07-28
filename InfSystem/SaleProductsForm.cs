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
    public partial class SaleProductsForm : Form
    {
        InfSystemContext db;

        private Sale _sale;

        public List<SoldProduct> SoldProducts { get; private set; }

        public SaleProductsForm(Sale sale)
        {
            InitializeComponent();
            _sale = sale;
        }

        private void SaleProductsForm_Load(object sender, EventArgs e)
        {
            try
            {
                db = new InfSystemContext();
                SoldProducts = new List<SoldProduct>();
                soldProductBindingSource.DataSource = SoldProducts;
            }
            catch(Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                Close();
            }
        }

        private SoldProduct ExistingProduct(int priceId)
        {
            return SoldProducts.Where(x => x.ProductPriceId == priceId).FirstOrDefault();
        }

        private void LoadEntity(SoldProduct soldProduct)
        {
            db.Entry(soldProduct).Reference(x => x.ProductPrice).Load();
            db.Entry(soldProduct.ProductPrice).Reference(x => x.Product).Load();
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            SoldProductDialog soldProductDialog = new SoldProductDialog(new SoldProduct() { SaleId = _sale.Id });
            if (soldProductDialog.ShowDialog() == DialogResult.OK)
            {
                SoldProduct check = ExistingProduct(soldProductDialog.SoldProduct.ProductPriceId);
                if (check == null)
                {
                    try
                    {
                        db.SoldProducts.Local.Add(soldProductDialog.SoldProduct);
                        LoadEntity(soldProductDialog.SoldProduct);
                        //soldProducts.Add(soldProductDialog.SoldProduct);
                        soldProductBindingSource.Add(soldProductDialog.SoldProduct);
                    }
                    catch(Exception ex)
                    {
                        InfSystemMessageBox.ShowError(ex);
                    }
                }
                else check.Amount += soldProductDialog.SoldProduct.Amount;
            }
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (soldProductBindingSource.Current != null)
            {
                SoldProduct soldProduct = soldProductBindingSource.Current as SoldProduct;
                try
                {
                    db.SoldProducts.Local.Remove(soldProduct);
                    //soldProducts.Remove(soldProduct);
                    soldProductBindingSource.RemoveCurrent();
                }
                catch (Exception ex)
                {
                    InfSystemMessageBox.ShowError(ex);
                }
            }
        }

        private void updateToolStripButton_Click(object sender, EventArgs e)
        {
            if (soldProductBindingSource.Current != null)
            {
                SoldProductDialog soldProductDialog = new SoldProductDialog((SoldProduct)soldProductBindingSource.Current);
                if (soldProductDialog.ShowDialog() == DialogResult.OK)
                {
                    SoldProduct soldProduct = soldProductBindingSource.Current as SoldProduct;
                    try
                    {
                        db.Entry(soldProduct).State = EntityState.Modified;
                        LoadEntity(soldProduct);
                        dataGridView.Refresh();
                    }
                    catch (Exception ex)
                    {
                        InfSystemMessageBox.ShowError(ex);
                    }
                }
            }
        }

        private void okToolStripButton_Click(object sender, EventArgs e)
        {
            Confirm();
            Close();
        }

        private void Confirm()
        {
            try
            {
                db.SoldProducts.Local.Clear();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
            }
        }

        private void SaleProductsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && SoldProducts.Count > 0)
            {
                if (MessageBox.Show("Добавить указанные товары в продажу?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Confirm();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
