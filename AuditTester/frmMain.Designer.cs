namespace AuditTester
{
    partial class frmMain
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
            this.lblLine = new System.Windows.Forms.Label();
            this.btnAudit = new System.Windows.Forms.Button();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.cboModule = new System.Windows.Forms.ComboBox();
            this.lblModule = new System.Windows.Forms.Label();
            this.lblSeverity = new System.Windows.Forms.Label();
            this.cboSeverity = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(12, 9);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(27, 13);
            this.lblLine.TabIndex = 0;
            this.lblLine.Text = "Line";
            // 
            // btnAudit
            // 
            this.btnAudit.Location = new System.Drawing.Point(336, 122);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(55, 32);
            this.btnAudit.TabIndex = 1;
            this.btnAudit.Text = "Audit";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(61, 6);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(332, 20);
            this.txtLine.TabIndex = 2;
            this.txtLine.Text = "a fish without a bicycle";
            // 
            // cboModule
            // 
            this.cboModule.FormattingEnabled = true;
            this.cboModule.Location = new System.Drawing.Point(61, 43);
            this.cboModule.Name = "cboModule";
            this.cboModule.Size = new System.Drawing.Size(190, 21);
            this.cboModule.TabIndex = 3;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Location = new System.Drawing.Point(12, 46);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(42, 13);
            this.lblModule.TabIndex = 4;
            this.lblModule.Text = "Module";
            // 
            // lblSeverity
            // 
            this.lblSeverity.AutoSize = true;
            this.lblSeverity.Location = new System.Drawing.Point(12, 83);
            this.lblSeverity.Name = "lblSeverity";
            this.lblSeverity.Size = new System.Drawing.Size(45, 13);
            this.lblSeverity.TabIndex = 5;
            this.lblSeverity.Text = "Severity";
            // 
            // cboSeverity
            // 
            this.cboSeverity.FormattingEnabled = true;
            this.cboSeverity.Location = new System.Drawing.Point(61, 80);
            this.cboSeverity.Name = "cboSeverity";
            this.cboSeverity.Size = new System.Drawing.Size(190, 21);
            this.cboSeverity.TabIndex = 6;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(12, 120);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(43, 13);
            this.lblMethod.TabIndex = 7;
            this.lblMethod.Text = "Method";
            // 
            // txtMethod
            // 
            this.txtMethod.Location = new System.Drawing.Point(61, 117);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(190, 20);
            this.txtMethod.TabIndex = 8;
            this.txtMethod.Text = "Main";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 176);
            this.Controls.Add(this.txtMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.cboSeverity);
            this.Controls.Add(this.lblSeverity);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.cboModule);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.lblLine);
            this.Name = "frmMain";
            this.Text = "Audit Tester";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.ComboBox cboModule;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblSeverity;
        private System.Windows.Forms.ComboBox cboSeverity;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.TextBox txtMethod;
    }
}

