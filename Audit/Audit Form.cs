using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Audit
{
    public class Audit_Form
    {
        public ctlAudit m_Audit;

        public Audit_Form(bool bShowMethod,
                          bool bShowErrorOnMessageBox,
                          int iAuditLinesLimit,
                          List<string> lsModule)
        {
            m_Audit = new ctlAudit(bShowMethod,
                                   bShowErrorOnMessageBox,
                                   iAuditLinesLimit,
                                   lsModule);

            Form frmMain = new Form();
            frmMain.Size = new System.Drawing.Size(1000, 600);
            frmMain.Controls.Add(m_Audit);
            frmMain.Show();
        }

        public void Audit(string sLine, string sModule, string sMethod, string sSeverity)
        {
            m_Audit.Audit(sLine, sMethod, sModule, sSeverity);
        }
    }
}
