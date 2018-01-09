namespace Orders {
    partial class frmAlterShippingDate {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeDate = new System.Windows.Forms.Button();
            this.btnChangeDateCancel = new System.Windows.Forms.Button();
            this.dtpShippedDate = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkEnterNullValue = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter New Date (dd/mm/yy)";
            // 
            // btnChangeDate
            // 
            this.btnChangeDate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnChangeDate.Location = new System.Drawing.Point(42, 111);
            this.btnChangeDate.Name = "btnChangeDate";
            this.btnChangeDate.Size = new System.Drawing.Size(70, 25);
            this.btnChangeDate.TabIndex = 2;
            this.btnChangeDate.Text = "&Save";
            this.btnChangeDate.UseVisualStyleBackColor = true;
            this.btnChangeDate.Click += new System.EventHandler(this.btnChangeDate_Click);
            // 
            // btnChangeDateCancel
            // 
            this.btnChangeDateCancel.Location = new System.Drawing.Point(137, 111);
            this.btnChangeDateCancel.Name = "btnChangeDateCancel";
            this.btnChangeDateCancel.Size = new System.Drawing.Size(70, 25);
            this.btnChangeDateCancel.TabIndex = 3;
            this.btnChangeDateCancel.Text = "&Cancel";
            this.btnChangeDateCancel.UseVisualStyleBackColor = true;
            this.btnChangeDateCancel.Click += new System.EventHandler(this.btnChangeDateCancel_Click);
            // 
            // dtpShippedDate
            // 
            this.dtpShippedDate.Location = new System.Drawing.Point(56, 51);
            this.dtpShippedDate.Name = "dtpShippedDate";
            this.dtpShippedDate.Size = new System.Drawing.Size(138, 20);
            this.dtpShippedDate.TabIndex = 4;
            this.toolTip1.SetToolTip(this.dtpShippedDate, "Choose new date between \'Order Date\' and \'Required Date\'");
            this.dtpShippedDate.ValueChanged += new System.EventHandler(this.dtpShippedDate_ValueChanged);
            // 
            // chkEnterNullValue
            // 
            this.chkEnterNullValue.AutoSize = true;
            this.chkEnterNullValue.Location = new System.Drawing.Point(56, 78);
            this.chkEnterNullValue.Name = "chkEnterNullValue";
            this.chkEnterNullValue.Size = new System.Drawing.Size(107, 17);
            this.chkEnterNullValue.TabIndex = 5;
            this.chkEnterNullValue.Text = "Enter Blank Date";
            this.chkEnterNullValue.UseVisualStyleBackColor = true;
            this.chkEnterNullValue.CheckedChanged += new System.EventHandler(this.chkEnterNullValue_CheckedChanged);
            // 
            // frmAlterShippingDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 168);
            this.Controls.Add(this.chkEnterNullValue);
            this.Controls.Add(this.dtpShippedDate);
            this.Controls.Add(this.btnChangeDateCancel);
            this.Controls.Add(this.btnChangeDate);
            this.Controls.Add(this.label1);
            this.Name = "frmAlterShippingDate";
            this.Text = "Alter Shipping Date";
            this.Load += new System.EventHandler(this.frmAlterShippingDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeDate;
        private System.Windows.Forms.Button btnChangeDateCancel;
        private System.Windows.Forms.DateTimePicker dtpShippedDate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkEnterNullValue;
    }
}