namespace Audit
{
    partial class ctlAudit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.lblSeverity = new System.Windows.Forms.Label();
            this.lstSeverity = new System.Windows.Forms.ListBox();
            this.lstModule = new System.Windows.Forms.ListBox();
            this.lvAudit = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtMethod
            // 
            this.txtMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMethod.Location = new System.Drawing.Point(835, 374);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(105, 20);
            this.txtMethod.TabIndex = 28;
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMethod.Location = new System.Drawing.Point(780, 377);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(49, 13);
            this.lblMethod.TabIndex = 27;
            this.lblMethod.Text = "Method";
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblModule.Location = new System.Drawing.Point(149, 11);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(47, 13);
            this.lblModule.TabIndex = 20;
            this.lblModule.Text = "Source";
            // 
            // lblSeverity
            // 
            this.lblSeverity.AutoSize = true;
            this.lblSeverity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSeverity.Location = new System.Drawing.Point(404, 11);
            this.lblSeverity.Name = "lblSeverity";
            this.lblSeverity.Size = new System.Drawing.Size(53, 13);
            this.lblSeverity.TabIndex = 19;
            this.lblSeverity.Text = "Severity";
            // 
            // lstSeverity
            // 
            this.lstSeverity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstSeverity.FormattingEnabled = true;
            this.lstSeverity.Location = new System.Drawing.Point(456, 11);
            this.lstSeverity.Name = "lstSeverity";
            this.lstSeverity.Size = new System.Drawing.Size(110, 69);
            this.lstSeverity.TabIndex = 18;
            this.lstSeverity.SelectedIndexChanged += new System.EventHandler(this.lstSeverity_SelectedIndexChanged);
            // 
            // lstModule
            // 
            this.lstModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstModule.FormattingEnabled = true;
            this.lstModule.Location = new System.Drawing.Point(195, 11);
            this.lstModule.Name = "lstModule";
            this.lstModule.Size = new System.Drawing.Size(197, 69);
            this.lstModule.TabIndex = 17;
            this.lstModule.SelectedIndexChanged += new System.EventHandler(this.lstModule_SelectedIndexChanged);
            // 
            // lvAudit
            // 
            this.lvAudit.Location = new System.Drawing.Point(136, 34);
            this.lvAudit.Name = "lvAudit";
            this.lvAudit.Size = new System.Drawing.Size(612, 482);
            this.lvAudit.TabIndex = 16;
            this.lvAudit.UseCompatibleStateImageBehavior = false;
            this.lvAudit.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAudit_ColumnClick);
            // 
            // ctlAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMethod);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.lblSeverity);
            this.Controls.Add(this.lstSeverity);
            this.Controls.Add(this.lstModule);
            this.Controls.Add(this.lvAudit);
            this.Name = "ctlAudit";
            this.Size = new System.Drawing.Size(1204, 526);
            this.Load += new System.EventHandler(this.ctlAudit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Label lblSeverity;
        private System.Windows.Forms.ListBox lstSeverity;
        private System.Windows.Forms.ListBox lstModule;
        private System.Windows.Forms.ListView lvAudit;
    }
}
