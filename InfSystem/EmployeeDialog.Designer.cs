
namespace InfSystem
{
    partial class EmployeeDialog
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
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.setLeavingDateRadioButton = new System.Windows.Forms.RadioButton();
            this.nullLeavingDateRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.positionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.personComboBox = new System.Windows.Forms.ComboBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Enabled = false;
            this.endDateTimePicker.Location = new System.Drawing.Point(84, 42);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(226, 20);
            this.endDateTimePicker.TabIndex = 2;
            // 
            // setLeavingDateRadioButton
            // 
            this.setLeavingDateRadioButton.AutoSize = true;
            this.setLeavingDateRadioButton.Location = new System.Drawing.Point(6, 42);
            this.setLeavingDateRadioButton.Name = "setLeavingDateRadioButton";
            this.setLeavingDateRadioButton.Size = new System.Drawing.Size(72, 17);
            this.setLeavingDateRadioButton.TabIndex = 2;
            this.setLeavingDateRadioButton.Text = "Выбрать:";
            this.setLeavingDateRadioButton.UseVisualStyleBackColor = true;
            this.setLeavingDateRadioButton.CheckedChanged += new System.EventHandler(this.setLeavingDateRadioButton_CheckedChanged);
            // 
            // nullLeavingDateRadioButton
            // 
            this.nullLeavingDateRadioButton.AutoSize = true;
            this.nullLeavingDateRadioButton.Checked = true;
            this.nullLeavingDateRadioButton.Location = new System.Drawing.Point(6, 19);
            this.nullLeavingDateRadioButton.Name = "nullLeavingDateRadioButton";
            this.nullLeavingDateRadioButton.Size = new System.Drawing.Size(44, 17);
            this.nullLeavingDateRadioButton.TabIndex = 1;
            this.nullLeavingDateRadioButton.TabStop = true;
            this.nullLeavingDateRadioButton.Text = "Нет";
            this.nullLeavingDateRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "ФИО:";
            // 
            // positionComboBox
            // 
            this.positionComboBox.DataSource = this.positionBindingSource;
            this.positionComboBox.DisplayMember = "Name";
            this.positionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Location = new System.Drawing.Point(86, 39);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(242, 21);
            this.positionComboBox.TabIndex = 2;
            this.positionComboBox.ValueMember = "Id";
            // 
            // positionBindingSource
            // 
            this.positionBindingSource.DataSource = typeof(DbConnection.Position);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(139, 66);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(189, 20);
            this.startDatePicker.TabIndex = 3;
            // 
            // personComboBox
            // 
            this.personComboBox.DataSource = this.personBindingSource;
            this.personComboBox.DisplayMember = "View";
            this.personComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.personComboBox.FormattingEnabled = true;
            this.personComboBox.Location = new System.Drawing.Point(86, 12);
            this.personComboBox.Name = "personComboBox";
            this.personComboBox.Size = new System.Drawing.Size(242, 21);
            this.personComboBox.TabIndex = 1;
            this.personComboBox.ValueMember = "Id";
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(DbConnection.Person);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Дата начала работы:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Должность:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(172, 180);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(253, 180);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nullLeavingDateRadioButton);
            this.groupBox1.Controls.Add(this.endDateTimePicker);
            this.groupBox1.Controls.Add(this.setLeavingDateRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 76);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дата ухода с работы:";
            // 
            // EmployeeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 215);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.positionComboBox);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.personComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeDialog_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.RadioButton setLeavingDateRadioButton;
        private System.Windows.Forms.RadioButton nullLeavingDateRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.ComboBox personComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.BindingSource positionBindingSource;
    }
}