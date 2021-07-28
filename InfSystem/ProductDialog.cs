using DbConnection;
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
    public partial class ProductDialog : Form
    {
        public Product Product { get; private set; }

        List<Unit> units;
        List<Supplier> suppliers;
        List<ProductClass> classes;
        List<ProductSubclass> subClasses;
        List<ProductGroup> groups;
        List<ProductSubgroup> subGroups;
        List<ProductKind> kinds;
        List<ProductCategory> categories;

        public ProductDialog(Product product)
        {
            InitializeComponent();
            Product = product;
        }

        private void ProductDialog_Load(object sender, EventArgs e)
        {
            if (Product.Id == 0) Text = "Новый товар";
            else Text = Product.ToString();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (InfSystemContext db = new InfSystemContext())
                {
                    units = db.Units.ToList();
                    suppliers = db.Suppliers.ToList();

                    classes = db.ProductClasses.ToList();
                    subClasses = db.ProductSubClasses.ToList();
                    groups = db.ProductGroups.ToList();
                    subGroups = db.ProductSubGroups.ToList();
                    kinds = db.ProductKinds.ToList();
                    categories = db.ProductCategories.ToList();
                }

                unitBindingSource.DataSource = units;
                supplierBindingSource.DataSource = suppliers;

                productClassBindingSource.DataSource = classes;
                productSubclassBindingSource.DataSource = subClasses.Where(x => x.Class.Equals(productClassBindingSource.Current));
                productGroupBindingSource.DataSource = groups.Where(x => x.Subclass.Equals(productSubclassBindingSource.Current));
                productSubgroupBindingSource.DataSource = subGroups.Where(x => x.Group.Equals(productGroupBindingSource.Current));
                productKindBindingSource.DataSource = kinds.Where(x => x.Subgroup.Equals(productSubgroupBindingSource.Current));
                productCategoryBindingSource.DataSource = categories.Where(x => x.Kind.Equals(productKindBindingSource.Current));
            }
            catch (Exception e)
            {
                InfSystemMessageBox.ShowError(e);
                Close();
            }

            if (unitBindingSource.Current == null)
            {
                MessageBox.Show("Нет доступных единиц измерения");
                Close();
            }

            if (productClassBindingSource.Current == null)
            {
                MessageBox.Show("Классификация недоступна");
                Close();
            }

            if (suppliers.Count == 0)
            {
                if (MessageBox.Show("Нет данных о поставщиках. Хотите добавить данные?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ContactDialog supplierDialog = new ContactDialog(new Supplier());
                    if (supplierDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (InfSystemContext db = new InfSystemContext())
                            {
                                db.Suppliers.Add((Supplier)supplierDialog.Contact);
                                db.SaveChanges();
                            }

                            InfSystemMessageBox.ShowSuccessAdding();
                        }
                        catch (Exception ex)
                        {
                            InfSystemMessageBox.ShowError(ex);
                            Close();
                        }
                        LoadData();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }

            if (Product.Id != 0)
            {
                nameTextBox.Text = Product.Name;
                unitComboBox.SelectedValue = Product.UnitId;
                subclassComboBox.SelectedValue = Product.SupplierId;
                classComboBox.SelectedValue = Product.Category.Kind.Subgroup.Group.Subclass.ClassId;
                subclassComboBox.SelectedValue = Product.Category.Kind.Subgroup.Group.SubclassId;
                groupComboBox.SelectedValue = Product.Category.Kind.Subgroup.GroupId;
                subgroupComboBox.SelectedValue = Product.Category.Kind.SubgroupId;
                kindComboBox.SelectedValue = Product.Category.KindId;
                categoryComboBox.SelectedValue = Product.CategoryId;
            }
        }

        #region OKDP comboboxes
        private void SubclassChange()
        {
            productSubclassBindingSource.DataSource = subClasses.Where(x => x.Class.Equals(classComboBox.SelectedItem));
            productSubclassBindingSource.ResetBindings(true);
            subclassComboBox.SelectedIndex = 0;
            GroupChange();
        }

        private void GroupChange()
        {
            productGroupBindingSource.DataSource = groups.Where(x => x.Subclass.Equals(subclassComboBox.SelectedItem));
            productGroupBindingSource.ResetBindings(true);
            groupComboBox.SelectedIndex = 0;
            SubgroupChange();
        }

        private void SubgroupChange()
        {
            productSubgroupBindingSource.DataSource = subGroups.Where(x => x.Group.Equals(groupComboBox.SelectedItem));
            productSubgroupBindingSource.ResetBindings(true);
            subgroupComboBox.SelectedIndex = 0;
            KindChange();
        }

        private void KindChange()
        {
            productKindBindingSource.DataSource = kinds.Where(x => x.Subgroup.Equals(subgroupComboBox.SelectedItem));
            productKindBindingSource.ResetBindings(true);
            kindComboBox.SelectedIndex = 0;
            CategoryChange();
        }

        private void CategoryChange()
        {
            productCategoryBindingSource.DataSource = categories.Where(x => x.Kind.Equals(kindComboBox.SelectedItem));
            productCategoryBindingSource.ResetBindings(true);
            categoryComboBox.SelectedIndex = 0;
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubclassChange();
        }

        private void subclassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupChange();
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubgroupChange();
        }

        private void subgroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            KindChange();
        }

        private void kindComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryChange();
        }
        #endregion

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = !(string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrEmpty(nameTextBox.Text));
        }

        private void ProductDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                Product.Name = nameTextBox.Text;
                Product.UnitId = (int)unitComboBox.SelectedValue;
                Product.SupplierId = (int)supplierComboBox.SelectedValue;
                Product.CategoryId = (int)categoryComboBox.SelectedValue;
            }
        }
    }
}
