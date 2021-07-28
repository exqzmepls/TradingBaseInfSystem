
namespace InfSystem
{
    partial class EntitySelectForm
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.productsRadioButton = new System.Windows.Forms.RadioButton();
            this.soldProductsRadioButton = new System.Windows.Forms.RadioButton();
            this.customerRadioButton = new System.Windows.Forms.RadioButton();
            this.supplierRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.salesRadioButton = new System.Windows.Forms.RadioButton();
            this.pricesRadioButton = new System.Windows.Forms.RadioButton();
            this.employeesRadioButton = new System.Windows.Forms.RadioButton();
            this.peopleRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.peopleRadioButton);
            this.groupBox.Controls.Add(this.employeesRadioButton);
            this.groupBox.Controls.Add(this.pricesRadioButton);
            this.groupBox.Controls.Add(this.salesRadioButton);
            this.groupBox.Controls.Add(this.productsRadioButton);
            this.groupBox.Controls.Add(this.soldProductsRadioButton);
            this.groupBox.Controls.Add(this.customerRadioButton);
            this.groupBox.Controls.Add(this.supplierRadioButton);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(266, 207);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Выберите данные для отчета:";
            // 
            // productsRadioButton
            // 
            this.productsRadioButton.AutoSize = true;
            this.productsRadioButton.Location = new System.Drawing.Point(6, 88);
            this.productsRadioButton.Name = "productsRadioButton";
            this.productsRadioButton.Size = new System.Drawing.Size(64, 17);
            this.productsRadioButton.TabIndex = 3;
            this.productsRadioButton.Text = "Товары";
            this.productsRadioButton.UseVisualStyleBackColor = true;
            // 
            // soldProductsRadioButton
            // 
            this.soldProductsRadioButton.AutoSize = true;
            this.soldProductsRadioButton.Location = new System.Drawing.Point(6, 65);
            this.soldProductsRadioButton.Name = "soldProductsRadioButton";
            this.soldProductsRadioButton.Size = new System.Drawing.Size(123, 17);
            this.soldProductsRadioButton.TabIndex = 2;
            this.soldProductsRadioButton.Text = "Проданные товары";
            this.soldProductsRadioButton.UseVisualStyleBackColor = true;
            // 
            // customerRadioButton
            // 
            this.customerRadioButton.AutoSize = true;
            this.customerRadioButton.Checked = true;
            this.customerRadioButton.Location = new System.Drawing.Point(6, 19);
            this.customerRadioButton.Name = "customerRadioButton";
            this.customerRadioButton.Size = new System.Drawing.Size(69, 17);
            this.customerRadioButton.TabIndex = 1;
            this.customerRadioButton.TabStop = true;
            this.customerRadioButton.Text = "Клиенты";
            this.customerRadioButton.UseVisualStyleBackColor = true;
            // 
            // supplierRadioButton
            // 
            this.supplierRadioButton.AutoSize = true;
            this.supplierRadioButton.Location = new System.Drawing.Point(6, 134);
            this.supplierRadioButton.Name = "supplierRadioButton";
            this.supplierRadioButton.Size = new System.Drawing.Size(89, 17);
            this.supplierRadioButton.TabIndex = 0;
            this.supplierRadioButton.Text = "Поставщики";
            this.supplierRadioButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(122, 225);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(203, 225);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "Далее >>";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // salesRadioButton
            // 
            this.salesRadioButton.AutoSize = true;
            this.salesRadioButton.Location = new System.Drawing.Point(6, 42);
            this.salesRadioButton.Name = "salesRadioButton";
            this.salesRadioButton.Size = new System.Drawing.Size(71, 17);
            this.salesRadioButton.TabIndex = 4;
            this.salesRadioButton.Text = "Продажи";
            this.salesRadioButton.UseVisualStyleBackColor = true;
            // 
            // pricesRadioButton
            // 
            this.pricesRadioButton.AutoSize = true;
            this.pricesRadioButton.Location = new System.Drawing.Point(6, 111);
            this.pricesRadioButton.Name = "pricesRadioButton";
            this.pricesRadioButton.Size = new System.Drawing.Size(108, 17);
            this.pricesRadioButton.TabIndex = 5;
            this.pricesRadioButton.Text = "Цены на товары";
            this.pricesRadioButton.UseVisualStyleBackColor = true;
            // 
            // employeesRadioButton
            // 
            this.employeesRadioButton.AutoSize = true;
            this.employeesRadioButton.Location = new System.Drawing.Point(6, 157);
            this.employeesRadioButton.Name = "employeesRadioButton";
            this.employeesRadioButton.Size = new System.Drawing.Size(84, 17);
            this.employeesRadioButton.TabIndex = 6;
            this.employeesRadioButton.Text = "Сотрудники";
            this.employeesRadioButton.UseVisualStyleBackColor = true;
            // 
            // peopleRadioButton
            // 
            this.peopleRadioButton.AutoSize = true;
            this.peopleRadioButton.Location = new System.Drawing.Point(6, 180);
            this.peopleRadioButton.Name = "peopleRadioButton";
            this.peopleRadioButton.Size = new System.Drawing.Size(209, 17);
            this.peopleRadioButton.TabIndex = 7;
            this.peopleRadioButton.Text = "Персональные данные сотрудников";
            this.peopleRadioButton.UseVisualStyleBackColor = true;
            // 
            // EntitySelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 256);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntitySelectForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntitySelectForm_FormClosing);
            this.Load += new System.EventHandler(this.EntitySelectForm_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton productsRadioButton;
        private System.Windows.Forms.RadioButton soldProductsRadioButton;
        private System.Windows.Forms.RadioButton customerRadioButton;
        private System.Windows.Forms.RadioButton supplierRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton salesRadioButton;
        private System.Windows.Forms.RadioButton peopleRadioButton;
        private System.Windows.Forms.RadioButton employeesRadioButton;
        private System.Windows.Forms.RadioButton pricesRadioButton;
    }
}