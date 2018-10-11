using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Audit;

namespace Audit_SA
{
    public partial class frmMain : Form
    {
        public ctlAudit m_Audit;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> lsModule = new List<string>(new string[] { "<All>", "CC Flow", "Core", "Delivery", "Access" });

            m_Audit = new ctlAudit(true,
                                   false,
                                   1000,
                                   lsModule);

            Controls.Add(m_Audit);
        }
    }
}
