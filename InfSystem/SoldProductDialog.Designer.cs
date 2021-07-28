
namespace InfSystem
{
    partial class SoldProductDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saleComboBox = new System.Windows.Forms.ComboBox();
            this.saleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.productPriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.amountTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPriceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(98, 97);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(179, 97);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 17;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Продажа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Товар:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Количество:";
            // 
            // saleComboBox
            // 
            this.saleComboBox.DataSource = this.saleBindingSource;
            this.saleComboBox.DisplayMember = "View";
            this.saleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saleComboBox.FormattingEnabled = true;
            this.saleComboBox.Location = new System.Drawing.Point(87, 12);
            this.saleComboBox.Name = "saleComboBox";
            this.saleComboBox.Size = new System.Drawing.Size(167, 21);
            this.saleComboBox.TabIndex = 22;
            this.saleComboBox.ValueMember = "Id";
            this.saleComboBox.SelectedIndexChanged += new System.EventHandler(this.saleComboBox_SelectedIndexChanged);
            // 
            // saleBindingSource
            // 
            this.saleBindingSource.DataSource = typeof(DbConnection.Sale);
            // 
            // productComboBox
            // 
            this.productComboBox.DataSource = this.productPriceBindingSource;
            this.productComboBox.DisplayMember = "Product";
            this.productComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(87, 39);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(167, 21);
            this.productComboBox.TabIndex = 23;
            this.productComboBox.ValueMember = "Id";
            // 
            // productPriceBindingSource
            // 
            this.productPriceBindingSource.DataSource = typeof(DbConnection.ProductPrice);
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(87, 66);
            this.amountTextBox.MaxLength = 10;
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.ShortcutsEnabled = false;
            this.amountTextBox.Size = new System.Drawing.Size(167, 20);
            this.amountTextBox.TabIndex = 24;
            this.amountTextBox.TextChanged += new System.EventHandler(this.amountTextBox_TextChanged);
            this.amountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amountTextBox_KeyPress);
            // 
            // SoldProductDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 132);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.saleComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoldProductDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SoldProductDialog_FormClosing);
            this.Load += new System.EventHandler(this.SoldProductDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productPriceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox saleComboBox;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.BindingSource saleBindingSource;
        private System.Windows.Forms.BindingSource productPriceBindingSource;
    }
}