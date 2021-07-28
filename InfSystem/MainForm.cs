using System;
using System.Data.Entity;
using System.IO;
using System.Windows.Forms;
using DbConnection;
using ReportBuilder;

namespace InfSystem
{
    public partial class MainForm : Form
    {
        internal static User user;
        internal static OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Файлы Excel (*.xls;*.xlsx)|*.xls;*.xlsx" };

        private int productsFormNumber = 0;
        private int soldProductsFormNumber = 0;
        private int pricesFormNumber = 0;
        private int salesFormNumber = 0;
        private int customersFormNumber = 0;
        private int supliersFormNumber = 0;
        private int employeesFormNumber = 0;
        private int peopleFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (ShowAuthorizationForm("Вход в систему") == DialogResult.OK)
            {
                Authorize();
            }
            else
            {
                Close();
            }
        }

        private void SetUserLimits()
        {
            SetFavoredUserLimits();
            showPricesToolStripMenuItem.Visible = false;
            searchPriceToolStripMenuItem.Visible = false;
        }

        private void SetFavoredUserLimits()
        {
            SetSuperUserLimits();
            employeeToolStripMenuItem.Visible = false;
            supplierToolStripMenuItem.Visible = false;
            addProductToolStripMenuItem.Visible = false;
        }

        private void SetSuperUserLimits()
        {
            employeeToolStripMenuItem.Visible = true;
            supplierToolStripMenuItem.Visible = true;
            addProductToolStripMenuItem.Visible = true;
            showPricesToolStripMenuItem.Visible = true;
            searchPriceToolStripMenuItem.Visible = true;
        }

        private DialogResult ShowAuthorizationForm(string formText = "")
        {
            AuthorizationForm authorizationForm = new AuthorizationForm() { Text = formText };
            return authorizationForm.ShowDialog();
        }

        private void Authorize()
        {
            foreach (Form form in MdiChildren) form.Close();

            if (user is SuperUser)
            {
                SetSuperUserLimits();
            }
            else
            {
                if (user is FavoredUser)
                {
                    SetFavoredUserLimits();
                }
                else
                {
                    if (user is User)
                    {
                        SetUserLimits();
                    }
                }
            }
        }

        private bool AddEntity(object entity)
        {
            try
            {
                using(InfSystemContext db = new InfSystemContext())
                {
                    db.Set(entity.GetType()).Add(entity);
                    db.SaveChanges();
                }

                InfSystemMessageBox.ShowSuccessAdding();
                return true;
            }
            catch (Exception ex)
            {
                InfSystemMessageBox.ShowError(ex);
                return false;
            }
        }

        private string GetFormName(string name, ref int index)
        {
            string result = name;
            if (index > 0) result += index.ToString();
            index++;
            return result;
        }

        #region menustrip

        #region product
        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductDialog productDialog = new ProductDialog(new Product());
            if (productDialog.ShowDialog() == DialogResult.OK)
            {
                if (AddEntity(productDialog.Product))
                {
                    if (MessageBox.Show("Вы хотите установить цену на добавленный товар?", "Добавление цены", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PriceDialog priceDialog = new PriceDialog(new ProductPrice() { ProductId = productDialog.Product.Id });
                        if (priceDialog.ShowDialog() == DialogResult.OK)
                        {
                            AddEntity(priceDialog.ProductPrice);
                        }
                    }
                }

            }
        }

        private void showProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductCRUDForm products = new ProductCRUDForm() { Text = GetFormName("Товары", ref productsFormNumber), MdiParent = this };
            products?.Show();
        }

        private void searchProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductCRUDForm products = new ProductCRUDForm() { Text = GetFormName("Товары", ref productsFormNumber), MdiParent = this };
            products?.Show();
            products?.ShowFilter();
        }

        private void showPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PriceCRUDForm prices = new PriceCRUDForm() { Text = GetFormName("Цены на товары", ref pricesFormNumber), MdiParent = this };
            prices?.Show();
        }

        private void searchPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PriceCRUDForm prices = new PriceCRUDForm() { Text = GetFormName("Цены на товары", ref pricesFormNumber), MdiParent = this };
            prices?.Show();
            prices?.ShowFilter();
        }
        #endregion

        #region sale
        private void addSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleDialog saleDialog = new SaleDialog(new Sale());
            if (saleDialog.ShowDialog() == DialogResult.OK)
            {
                AddEntity(saleDialog.Sale);
                SaleProductsForm saleProductsForm = new SaleProductsForm(saleDialog.Sale);
                if (saleProductsForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (InfSystemContext db = new InfSystemContext())
                        {
                            db.SoldProducts.AddRange(saleProductsForm.SoldProducts);
                            db.SaveChanges();
                        }
                        MessageBox.Show("Товарные позиции успешно добавлены в состав продажи");
                    }
                    catch(Exception ex)
                    {
                        InfSystemMessageBox.ShowError(ex);
                    }
                }
            }
        }

        private void showSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleCRUDForm sales = new SaleCRUDForm() { Text = GetFormName("Продажи", ref salesFormNumber), MdiParent = this };
            sales?.Show();
        }

        private void searchSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleCRUDForm sales = new SaleCRUDForm() { Text = GetFormName("Продажи", ref salesFormNumber), MdiParent = this };
            sales?.Show();
            sales?.ShowFilter();
        }

        private void showSoldProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoldProductCRUDForm soldProducts = new SoldProductCRUDForm() { Text = GetFormName("Проданные товары", ref soldProductsFormNumber), MdiParent = this };
            soldProducts?.Show();
        }

        private void searchSoldProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoldProductCRUDForm soldProducts = new SoldProductCRUDForm() { Text = GetFormName("Проданные товары", ref soldProductsFormNumber), MdiParent = this };
            soldProducts?.Show();
            soldProducts?.ShowFilter();
        }
        #endregion

        #region customer
        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactDialog contactDialog = new ContactDialog(new Customer());
            if (contactDialog.ShowDialog() == DialogResult.OK)
            {
                AddEntity(contactDialog.Contact);
            }
        }

        private void showCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerCRUDForm customers = new CustomerCRUDForm() { Text = GetFormName("Покупатели", ref customersFormNumber), MdiParent = this };
            customers?.Show();
        }

        private void searchCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerCRUDForm customers = new CustomerCRUDForm() { Text = GetFormName("Покупатели", ref customersFormNumber), MdiParent = this };
            customers?.Show();
            customers?.ShowFilter();
        }
        #endregion

        #region supplier
        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactDialog contactDialog = new ContactDialog(new Supplier());
            if (contactDialog.ShowDialog() == DialogResult.OK)
            {
                AddEntity(contactDialog.Contact);
            }
        }

        private void showSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierCRUDForm suppliers = new SupplierCRUDForm() { Text = GetFormName("Поставщики", ref supliersFormNumber), MdiParent = this };
            suppliers?.Show();
        }

        private void searchSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierCRUDForm suppliers = new SupplierCRUDForm() { Text = GetFormName("Поставщики", ref supliersFormNumber), MdiParent = this };
            suppliers?.Show();
            suppliers?.ShowFilter();
        }
        #endregion

        #region employee
        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDialog personDialog = new PersonDialog(new Person());
            if (personDialog.ShowDialog() == DialogResult.OK)
            {
                AddEntity(personDialog.Person);
            }
        }

        private void showPersonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonCRUDForm people = new PersonCRUDForm() { Text = GetFormName("Персональные данные сотрудников", ref peopleFormNumber), MdiParent = this };
            people?.Show();
        }
        private void searchPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonCRUDForm people = new PersonCRUDForm() { Text = GetFormName("Персональные данные сотрудников", ref peopleFormNumber), MdiParent = this };
            people?.Show();
            people?.ShowFilter();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeDialog employeeDialog = new EmployeeDialog(new Employee());
            if (employeeDialog.ShowDialog() == DialogResult.OK)
            {
                AddEntity(employeeDialog.Employee);
            }
        }

        private void showEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeCRUDForm employees = new EmployeeCRUDForm() { Text = GetFormName("Сотрудники", ref employeesFormNumber), MdiParent = this };
            employees?.Show();
        }

        private void searchEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeCRUDForm employees = new EmployeeCRUDForm() { Text = GetFormName("Сотрудники", ref employeesFormNumber), MdiParent = this };
            employees?.Show();
            employees?.ShowFilter();
        }

        #endregion

        #region report
        private void создатьОтчетToolStripMenuItem_Click(object sender, EventArgs e) // without filter
        {
            EntitySelectForm entitySelectForm = new EntitySelectForm();
            if (entitySelectForm.ShowDialog() == DialogResult.OK)
            {
                PropertiesSelectForm propertiesSelectForm = new PropertiesSelectForm(EntityProperty.GetProperties(entitySelectForm.EntityType));
                if (propertiesSelectForm.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (InfSystemContext db = new InfSystemContext())
                            {
                                db.Configuration.LazyLoadingEnabled = true;
                                DbSet dbSet = db.Set((Type)entitySelectForm.EntityType);
                                dbSet.Load();

                                Report report = new Report(propertiesSelectForm.ReportName, new FileInfo(openFileDialog.FileName), propertiesSelectForm.SelectedProperties, dbSet.Local, (Type)entitySelectForm.EntityType);
                                report.Create();

                                MessageBox.Show("Отчет успешно создан");

                                System.Diagnostics.Process.Start(openFileDialog.FileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            InfSystemMessageBox.ShowError(ex);
                        }
                    }
                }
            }
        }
        #endregion

        #region account
        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowAuthorizationForm("Смена пользователя") == DialogResult.OK)
            {
                Authorize();
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из учетной записи?", "Выход из учетной записи", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
                if (ShowAuthorizationForm("Вход в систему") == DialogResult.OK)
                {
                    Show();
                    Authorize();
                }
                else
                {
                    Close();
                }
            }
        }
        #endregion

        #region window
        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        #endregion

        #region help
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }






        #endregion

        #endregion
    }
}
