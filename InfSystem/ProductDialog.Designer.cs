
namespace InfSystem
{
    partial class ProductDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.productCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindComboBox = new System.Windows.Forms.ComboBox();
            this.productKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subgroupComboBox = new System.Windows.Forms.ComboBox();
            this.productSubgroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.productGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subclassComboBox = new System.Windows.Forms.ComboBox();
            this.productSubclassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.productClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productKindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSubgroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSubclassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(445, 260);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 62;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(526, 260);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 61;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DataSource = this.productCategoryBindingSource;
            this.categoryComboBox.DisplayMember = "Name";
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(78, 227);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(523, 21);
            this.categoryComboBox.TabIndex = 60;
            this.categoryComboBox.ValueMember = "Id";
            // 
            // productCategoryBindingSource
            // 
            this.productCategoryBindingSource.DataSource = typeof(DbConnection.ProductCategory);
            // 
            // kindComboBox
            // 
            this.kindComboBox.DataSource = this.productKindBindingSource;
            this.kindComboBox.DisplayMember = "Name";
            this.kindComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kindComboBox.FormattingEnabled = true;
            this.kindComboBox.Location = new System.Drawing.Point(47, 200);
            this.kindComboBox.Name = "kindComboBox";
            this.kindComboBox.Size = new System.Drawing.Size(554, 21);
            this.kindComboBox.TabIndex = 59;
            this.kindComboBox.ValueMember = "Id";
            this.kindComboBox.SelectedIndexChanged += new System.EventHandler(this.kindComboBox_SelectedIndexChanged);
            // 
            // productKindBindingSource
            // 
            this.productKindBindingSource.DataSource = typeof(DbConnection.ProductKind);
            // 
            // subgroupComboBox
            // 
            this.subgroupComboBox.DataSource = this.productSubgroupBindingSource;
            this.subgroupComboBox.DisplayMember = "Name";
            this.subgroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subgroupComboBox.FormattingEnabled = true;
            this.subgroupComboBox.Location = new System.Drawing.Point(82, 173);
            this.subgroupComboBox.Name = "subgroupComboBox";
            this.subgroupComboBox.Size = new System.Drawing.Size(519, 21);
            this.subgroupComboBox.TabIndex = 58;
            this.subgroupComboBox.ValueMember = "Id";
            this.subgroupComboBox.SelectedIndexChanged += new System.EventHandler(this.subgroupComboBox_SelectedIndexChanged);
            // 
            // productSubgroupBindingSource
            // 
            this.productSubgroupBindingSource.DataSource = typeof(DbConnection.ProductSubgroup);
            // 
            // groupComboBox
            // 
            this.groupComboBox.DataSource = this.productGroupBindingSource;
            this.groupComboBox.DisplayMember = "Name";
            this.groupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(63, 146);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(538, 21);
            this.groupComboBox.TabIndex = 57;
            this.groupComboBox.ValueMember = "Id";
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged);
            // 
            // productGroupBindingSource
            // 
            this.productGroupBindingSource.DataSource = typeof(DbConnection.ProductGroup);
            // 
            // subclassComboBox
            // 
            this.subclassComboBox.DataSource = this.productSubclassBindingSource;
            this.subclassComboBox.DisplayMember = "Name";
            this.subclassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subclassComboBox.FormattingEnabled = true;
            this.subclassComboBox.Location = new System.Drawing.Point(78, 119);
            this.subclassComboBox.Name = "subclassComboBox";
            this.subclassComboBox.Size = new System.Drawing.Size(523, 21);
            this.subclassComboBox.TabIndex = 56;
            this.subclassComboBox.ValueMember = "Id";
            this.subclassComboBox.SelectedIndexChanged += new System.EventHandler(this.subclassComboBox_SelectedIndexChanged);
            // 
            // productSubclassBindingSource
            // 
            this.productSubclassBindingSource.DataSource = typeof(DbConnection.ProductSubclass);
            // 
            // classComboBox
            // 
            this.classComboBox.DataSource = this.productClassBindingSource;
            this.classComboBox.DisplayMember = "Name";
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(59, 92);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(542, 21);
            this.classComboBox.TabIndex = 55;
            this.classComboBox.ValueMember = "Id";
            this.classComboBox.SelectedIndexChanged += new System.EventHandler(this.classComboBox_SelectedIndexChanged);
            // 
            // productClassBindingSource
            // 
            this.productClassBindingSource.DataSource = typeof(DbConnection.ProductClass);
            // 
            // unitComboBox
            // 
            this.unitComboBox.DataSource = this.unitBindingSource;
            this.unitComboBox.DisplayMember = "View";
            this.unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(130, 65);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(471, 21);
            this.unitComboBox.TabIndex = 54;
            this.unitComboBox.ValueMember = "Id";
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataSource = typeof(DbConnection.Unit);
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.DataSource = this.supplierBindingSource;
            this.supplierComboBox.DisplayMember = "View";
            this.supplierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(86, 38);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(515, 21);
            this.supplierComboBox.TabIndex = 53;
            this.supplierComboBox.ValueMember = "Id";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(DbConnection.Supplier);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(78, 12);
            this.nameTextBox.MaxLength = 64;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(523, 20);
            this.nameTextBox.TabIndex = 52;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Категория:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Вид:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Подгруппа:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Группа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Подкласс:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Класс:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Единица измерения:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Поставщик:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Название:";
            // 
            // ProductDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 295);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.kindComboBox);
            this.Controls.Add(this.subgroupComboBox);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.subclassComboBox);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.unitComboBox);
            this.Controls.Add(this.supplierComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductDialog_FormClosing);
            this.Load += new System.EventHandler(this.ProductDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productKindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSubgroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productSubclassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox kindComboBox;
        private System.Windows.Forms.ComboBox subgroupComboBox;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.ComboBox subclassComboBox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.ComboBox unitComboBox;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource productCategoryBindingSource;
        private System.Windows.Forms.BindingSource productKindBindingSource;
        private System.Windows.Forms.BindingSource productSubgroupBindingSource;
        private System.Windows.Forms.BindingSource productGroupBindingSource;
        private System.Windows.Forms.BindingSource productSubclassBindingSource;
        private System.Windows.Forms.BindingSource productClassBindingSource;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private System.Windows.Forms.BindingSource supplierBindingSource;
    }
}