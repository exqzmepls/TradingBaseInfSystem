
namespace InfSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPricesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showSoldProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSoldProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.addEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетнаяЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.слеваНаправоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сверхуВнизToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.saleToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.отчетToolStripMenuItem,
            this.учетнаяЗаписьToolStripMenuItem,
            this.окноToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductToolStripMenuItem,
            this.showProductsToolStripMenuItem,
            this.searchProductToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showPricesToolStripMenuItem,
            this.searchPriceToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.productToolStripMenuItem.Text = "&Товар";
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.addProductToolStripMenuItem.Text = "&Добавить товар...";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // showProductsToolStripMenuItem
            // 
            this.showProductsToolStripMenuItem.Name = "showProductsToolStripMenuItem";
            this.showProductsToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.showProductsToolStripMenuItem.Text = "&Просмотреть товары...";
            this.showProductsToolStripMenuItem.Click += new System.EventHandler(this.showProductsToolStripMenuItem_Click);
            // 
            // searchProductToolStripMenuItem
            // 
            this.searchProductToolStripMenuItem.Name = "searchProductToolStripMenuItem";
            this.searchProductToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.searchProductToolStripMenuItem.Text = "&Поиск по товарам...";
            this.searchProductToolStripMenuItem.Click += new System.EventHandler(this.searchProductToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(245, 6);
            // 
            // showPricesToolStripMenuItem
            // 
            this.showPricesToolStripMenuItem.Name = "showPricesToolStripMenuItem";
            this.showPricesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.showPricesToolStripMenuItem.Text = "Просмотреть &цены на товары...";
            this.showPricesToolStripMenuItem.Click += new System.EventHandler(this.showPricesToolStripMenuItem_Click);
            // 
            // searchPriceToolStripMenuItem
            // 
            this.searchPriceToolStripMenuItem.Name = "searchPriceToolStripMenuItem";
            this.searchPriceToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.searchPriceToolStripMenuItem.Text = "Поиск по &ценам...";
            this.searchPriceToolStripMenuItem.Click += new System.EventHandler(this.searchPriceToolStripMenuItem_Click);
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSaleToolStripMenuItem,
            this.showSalesToolStripMenuItem,
            this.searchSaleToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showSoldProductsToolStripMenuItem,
            this.searchSoldProductsToolStripMenuItem});
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.saleToolStripMenuItem.Text = "&Продажа";
            // 
            // addSaleToolStripMenuItem
            // 
            this.addSaleToolStripMenuItem.Name = "addSaleToolStripMenuItem";
            this.addSaleToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.addSaleToolStripMenuItem.Text = "&Добавить продажу...";
            this.addSaleToolStripMenuItem.Click += new System.EventHandler(this.addSaleToolStripMenuItem_Click);
            // 
            // showSalesToolStripMenuItem
            // 
            this.showSalesToolStripMenuItem.Name = "showSalesToolStripMenuItem";
            this.showSalesToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.showSalesToolStripMenuItem.Text = "&Просмотреть продажи...";
            this.showSalesToolStripMenuItem.Click += new System.EventHandler(this.showSalesToolStripMenuItem_Click);
            // 
            // searchSaleToolStripMenuItem
            // 
            this.searchSaleToolStripMenuItem.Name = "searchSaleToolStripMenuItem";
            this.searchSaleToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.searchSaleToolStripMenuItem.Text = "&Поиск по продажам...";
            this.searchSaleToolStripMenuItem.Click += new System.EventHandler(this.searchSaleToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(262, 6);
            // 
            // showSoldProductsToolStripMenuItem
            // 
            this.showSoldProductsToolStripMenuItem.Name = "showSoldProductsToolStripMenuItem";
            this.showSoldProductsToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.showSoldProductsToolStripMenuItem.Text = "Просмотреть проданные &товары...";
            this.showSoldProductsToolStripMenuItem.Click += new System.EventHandler(this.showSoldProductsToolStripMenuItem_Click);
            // 
            // searchSoldProductsToolStripMenuItem
            // 
            this.searchSoldProductsToolStripMenuItem.Name = "searchSoldProductsToolStripMenuItem";
            this.searchSoldProductsToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.searchSoldProductsToolStripMenuItem.Text = "Поиск по проданным &товарам...";
            this.searchSoldProductsToolStripMenuItem.Click += new System.EventHandler(this.searchSoldProductsToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.showCustomersToolStripMenuItem,
            this.searchCustomersToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.customerToolStripMenuItem.Text = "По&купатель";
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.addCustomerToolStripMenuItem.Text = "&Добавить покупателя...";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // showCustomersToolStripMenuItem
            // 
            this.showCustomersToolStripMenuItem.Name = "showCustomersToolStripMenuItem";
            this.showCustomersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.showCustomersToolStripMenuItem.Text = "&Просмотреть покупателей...";
            this.showCustomersToolStripMenuItem.Click += new System.EventHandler(this.showCustomersToolStripMenuItem_Click);
            // 
            // searchCustomersToolStripMenuItem
            // 
            this.searchCustomersToolStripMenuItem.Name = "searchCustomersToolStripMenuItem";
            this.searchCustomersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.searchCustomersToolStripMenuItem.Text = "П&оиск по покупателям...";
            this.searchCustomersToolStripMenuItem.Click += new System.EventHandler(this.searchCustomersToolStripMenuItem_Click);
            // 
            // supplierToolStripMenuItem
            // 
            this.supplierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSupplierToolStripMenuItem,
            this.showSuppliersToolStripMenuItem,
            this.searchSupplierToolStripMenuItem});
            this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            this.supplierToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.supplierToolStripMenuItem.Text = "Пост&авщик";
            // 
            // addSupplierToolStripMenuItem
            // 
            this.addSupplierToolStripMenuItem.Name = "addSupplierToolStripMenuItem";
            this.addSupplierToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.addSupplierToolStripMenuItem.Text = "&Добавить поставщика...";
            this.addSupplierToolStripMenuItem.Click += new System.EventHandler(this.addSupplierToolStripMenuItem_Click);
            // 
            // showSuppliersToolStripMenuItem
            // 
            this.showSuppliersToolStripMenuItem.Name = "showSuppliersToolStripMenuItem";
            this.showSuppliersToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.showSuppliersToolStripMenuItem.Text = "&Просмотреть поставщиков...";
            this.showSuppliersToolStripMenuItem.Click += new System.EventHandler(this.showSuppliersToolStripMenuItem_Click);
            // 
            // searchSupplierToolStripMenuItem
            // 
            this.searchSupplierToolStripMenuItem.Name = "searchSupplierToolStripMenuItem";
            this.searchSupplierToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.searchSupplierToolStripMenuItem.Text = "П&оиск по поставщикам...";
            this.searchSupplierToolStripMenuItem.Click += new System.EventHandler(this.searchSupplierToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPersonToolStripMenuItem,
            this.showPersonsToolStripMenuItem,
            this.searchPersonToolStripMenuItem,
            this.toolStripMenuItem4,
            this.addEmployeeToolStripMenuItem,
            this.showEmployeesToolStripMenuItem,
            this.searchEmployeeToolStripMenuItem});
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.employeeToolStripMenuItem.Text = "Сот&рудник";
            // 
            // addPersonToolStripMenuItem
            // 
            this.addPersonToolStripMenuItem.Name = "addPersonToolStripMenuItem";
            this.addPersonToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.addPersonToolStripMenuItem.Text = "&Добавить персональные данные сотрудника...";
            this.addPersonToolStripMenuItem.Click += new System.EventHandler(this.addPersonToolStripMenuItem_Click);
            // 
            // showPersonsToolStripMenuItem
            // 
            this.showPersonsToolStripMenuItem.Name = "showPersonsToolStripMenuItem";
            this.showPersonsToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.showPersonsToolStripMenuItem.Text = "Просмотреть &персональные данные сторудников...";
            this.showPersonsToolStripMenuItem.Click += new System.EventHandler(this.showPersonsToolStripMenuItem_Click);
            // 
            // searchPersonToolStripMenuItem
            // 
            this.searchPersonToolStripMenuItem.Name = "searchPersonToolStripMenuItem";
            this.searchPersonToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.searchPersonToolStripMenuItem.Text = "Поиск по &персональным данным...";
            this.searchPersonToolStripMenuItem.Click += new System.EventHandler(this.searchPersonToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(355, 6);
            // 
            // addEmployeeToolStripMenuItem
            // 
            this.addEmployeeToolStripMenuItem.Name = "addEmployeeToolStripMenuItem";
            this.addEmployeeToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.addEmployeeToolStripMenuItem.Text = "&Добавить сотрудника на должность...";
            this.addEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addEmployeeToolStripMenuItem_Click);
            // 
            // showEmployeesToolStripMenuItem
            // 
            this.showEmployeesToolStripMenuItem.Name = "showEmployeesToolStripMenuItem";
            this.showEmployeesToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.showEmployeesToolStripMenuItem.Text = "Просмотреть &сотрудников по должностям...";
            this.showEmployeesToolStripMenuItem.Click += new System.EventHandler(this.showEmployeesToolStripMenuItem_Click);
            // 
            // searchEmployeeToolStripMenuItem
            // 
            this.searchEmployeeToolStripMenuItem.Name = "searchEmployeeToolStripMenuItem";
            this.searchEmployeeToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.searchEmployeeToolStripMenuItem.Text = "Поиск по &сотрудникам...";
            this.searchEmployeeToolStripMenuItem.Click += new System.EventHandler(this.searchEmployeeToolStripMenuItem_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьОтчетToolStripMenuItem});
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.отчетToolStripMenuItem.Text = "От&чет";
            // 
            // создатьОтчетToolStripMenuItem
            // 
            this.создатьОтчетToolStripMenuItem.Name = "создатьОтчетToolStripMenuItem";
            this.создатьОтчетToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.создатьОтчетToolStripMenuItem.Text = "&Создать отчет";
            this.создатьОтчетToolStripMenuItem.Click += new System.EventHandler(this.создатьОтчетToolStripMenuItem_Click);
            // 
            // учетнаяЗаписьToolStripMenuItem
            // 
            this.учетнаяЗаписьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменитьПользователяToolStripMenuItem,
            this.toolStripMenuItem9,
            this.выйтиToolStripMenuItem});
            this.учетнаяЗаписьToolStripMenuItem.Name = "учетнаяЗаписьToolStripMenuItem";
            this.учетнаяЗаписьToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.учетнаяЗаписьToolStripMenuItem.Text = "&Учетная запись";
            // 
            // сменитьПользователяToolStripMenuItem
            // 
            this.сменитьПользователяToolStripMenuItem.Name = "сменитьПользователяToolStripMenuItem";
            this.сменитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.сменитьПользователяToolStripMenuItem.Text = "&Сменить пользователя...";
            this.сменитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.сменитьПользователяToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(206, 6);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.выйтиToolStripMenuItem.Text = "&Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадомToolStripMenuItem,
            this.слеваНаправоToolStripMenuItem,
            this.сверхуВнизToolStripMenuItem,
            this.toolStripMenuItem3});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.окноToolStripMenuItem.Text = "&Окно";
            // 
            // каскадомToolStripMenuItem
            // 
            this.каскадомToolStripMenuItem.Name = "каскадомToolStripMenuItem";
            this.каскадомToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.каскадомToolStripMenuItem.Text = "&Каскадом";
            this.каскадомToolStripMenuItem.Click += new System.EventHandler(this.каскадомToolStripMenuItem_Click);
            // 
            // слеваНаправоToolStripMenuItem
            // 
            this.слеваНаправоToolStripMenuItem.Name = "слеваНаправоToolStripMenuItem";
            this.слеваНаправоToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.слеваНаправоToolStripMenuItem.Text = "С&лева направо";
            this.слеваНаправоToolStripMenuItem.Click += new System.EventHandler(this.слеваНаправоToolStripMenuItem_Click);
            // 
            // сверхуВнизToolStripMenuItem
            // 
            this.сверхуВнизToolStripMenuItem.Name = "сверхуВнизToolStripMenuItem";
            this.сверхуВнизToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.сверхуВнизToolStripMenuItem.Text = "С&верху вниз";
            this.сверхуВнизToolStripMenuItem.Click += new System.EventHandler(this.сверхуВнизToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(153, 6);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "&Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "&О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 588);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showPricesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showSoldProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchSoldProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem addEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem слеваНаправоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сверхуВнизToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem учетнаяЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPersonToolStripMenuItem;
    }
}

