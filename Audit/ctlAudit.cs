using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using AuditClientWcfContract;
using System.ServiceModel;

namespace Audit
{
    public partial class ctlAudit : UserControl
    {
        #region Close button definitions

        const int MF_BYPOSITION = 0x400;        

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        #endregion

        #region Data Members

        private bool m_bShowMethod;
        private bool m_bShowErrorOnMessageBox;

        private int m_iAuditLinesLimit;

        private List<string> m_lsModule;

        private string m_SeverityFilter;
        private string m_ModuleFilter;

        private ListViewColumnSorter lvAuditColumnSorter;

        private ServiceHost m_WcfHost;

        private Client2Audit m_Client2Audit;

        #endregion

        public ctlAudit(bool bShowMethod, 
                        bool bShowErrorOnMessageBox, 
                        int iAuditLinesLimit,
                        List<string> lsModule)
        {
            InitializeComponent();

            m_bShowMethod = bShowMethod;
            m_bShowErrorOnMessageBox = bShowErrorOnMessageBox;

            m_lsModule = lsModule;

            m_iAuditLinesLimit = iAuditLinesLimit;
        }

        private void ctlAudit_Load(object sender, EventArgs e)
        {
            string sThisMethod = MethodBase.GetCurrentMethod().Name;
            int iGap = 8;

            try
            {
                IntPtr hMenu = GetSystemMenu(this.Handle, false);
                int menuItemCount = GetMenuItemCount(hMenu);
                RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);

                lvAuditColumnSorter = new ListViewColumnSorter();
                lvAudit.View = View.Details;
                lvAudit.GridLines = true;
                lvAudit.ListViewItemSorter = lvAuditColumnSorter;

                lvAudit.Columns.Add("Date Time", 130);
                lvAudit.Columns.Add("Source", 100);
                if (m_bShowMethod)
                {
                    lvAudit.Columns.Add("Method", 100);
                }
                else
                {
                    lvAudit.Columns.Add("Method", 0);
                }
                lvAudit.Columns.Add("Message", 500);
                lvAudit.Columns.Add("Severity", 100);

                this.Location = new Point(0, 0);
                this.Width = 950;
                this.Height = (Screen.PrimaryScreen.Bounds.Height / 3) * 2;

                foreach (string sModule in m_lsModule)
                {
                    string sAddModule = sModule;

                    if (sModule == "Unknown")
                    {
                        sAddModule = "<All>";
                    }

                    lstModule.Items.Add(sAddModule);
                }

                m_ModuleFilter = "<All>";

                foreach (AuditSeverity aSeverity in Enum.GetValues(typeof(AuditSeverity)))
                {
                    string sSeverity = Utils.GetEnumDescription(aSeverity);

                    if (sSeverity == AuditSeverity.Unknown.ToString())
                    {
                        sSeverity = "<All>";
                    }

                    lstSeverity.Items.Add(sSeverity);
                }

                m_SeverityFilter = "<All>";

                #region Filer ListBoxs Locations

                lblModule.Left = iGap;
                lstModule.Left = lblModule.Left + lblModule.Width + (iGap / 2);

                lblSeverity.Left = lstModule.Left + lstModule.Width + iGap;
                lstSeverity.Left = lblSeverity.Left + lblSeverity.Width + (iGap / 2);

                lblMethod.Left = lblModule.Left;
                lblMethod.Top = lstModule.Top + lstModule.Height + iGap / 2;

                txtMethod.Left = lstModule.Left; ;
                txtMethod.Top = lblMethod.Top;
                txtMethod.Width = lstModule.Width;

                #endregion

                //lvAudit.Location = new Point(10, 100);
                lvAudit.Location = new Point(lblMethod.Left, lblMethod.Top + lblMethod.Height + iGap * 2);
                lvAudit.Height = Height - 150;
                lvAudit.Width = Width - 40;

                Top = 10;
                Left = 10;
                Width = ParentForm.Width - iGap / 2;
                Height = ParentForm.Height - iGap / 2;

                ParentForm.Resize += ParentForm_Resize;
                ParentForm_Resize(null, null);

                StartWcfService();
            }
            catch (Exception ex)
            {
                WriteToEventLog(sThisMethod, ex.Message);
            }
        }

        #region Write To Form/MessageBox/EventLog

        public void Audit(string sLine, string sMethod, string sModule)
        {
            try
            {
                AddListViewItem(sLine, sMethod, sModule, AuditSeverity.Unknown.ToString(), Color.White);
            }
            catch (Exception e)
            {
                PopErrorMessageBox(sLine, sMethod, sModule, AuditSeverity.Unknown.ToString(), e.Message);
            }
        }

        public void Audit(string sLine, string sMethod, string sModule, string sSeverity)
        {
            try
            {
                AddListViewItem(sLine, sMethod, sModule, sSeverity, Color.White);
            }
            catch (Exception e)
            {
                PopErrorMessageBox(sLine, sMethod, sModule, sSeverity, e.Message);
            }
        }

        public void Audit(string sLine, string sMethod, string sModule, Color backColor)
        {
            try
            {
                AddListViewItem(sLine, sMethod, sModule, AuditSeverity.Unknown.ToString(), backColor);
            }
            catch (Exception e)
            {
                PopErrorMessageBox(sLine, sMethod, sModule, AuditSeverity.Unknown.ToString(), e.Message);
            }
        }

        private void AddListViewItem(string sLine,
                                     string sMethod,
                                     string sModule,
                                     string sSeverity,
                                     Color backColor)
        {
            string sThisMethod = MethodBase.GetCurrentMethod().Name;
            string sDateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff");

            try
            {
                if (sSeverity != AuditSeverity.Urgent.ToString())
                {
                    if (sSeverity != m_SeverityFilter)
                    {
                        if (m_SeverityFilter != "<All>")
                        {
                            return;
                        }
                    }
                }

                if (sModule != m_ModuleFilter)
                {
                    if (m_ModuleFilter != "<All>")
                    {
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(txtMethod.Text.Trim()))
                {
                    if (sMethod != txtMethod.Text)
                    {
                        return;
                    }
                }

                ListViewItem auditItem = new ListViewItem(sDateTime);
                if (auditItem != null)
                {
                    if (lvAudit.Items.Count > m_iAuditLinesLimit)
                    {
                        lvAudit.Items.Clear();
                    }

                    auditItem.SubItems.Add(sModule);
                    auditItem.SubItems.Add(sMethod);
                    auditItem.SubItems.Add(sLine);

                    if (sSeverity != AuditSeverity.Unknown.ToString())
                    {
                        auditItem.SubItems.Add(sSeverity);
                    }

                    if (backColor != Color.White)
                    {
                        auditItem.BackColor = backColor;
                    }

                    lvAudit.Items.Add(auditItem);

                    lvAudit.Items[lvAudit.Items.Count - 1].EnsureVisible();
                    Application.DoEvents();
                }
            }
            catch (Exception e)
            {
                string sError = "Line[" + sLine +
                                " Method[" + sMethod +
                                " Module[" + sModule +
                                " AuditSeverity[" + sSeverity +
                                " Color[" + backColor.ToString() + "]. " + e.Message;
                Utils.WriteToEventLog("DVR Client",
                                      "Audit - " + sThisMethod,
                                      sError,
                                      0,
                                      EventLogEntryType.Warning);
            }
        }

        private void PopErrorMessageBox(string sLine,
                                        string sMethod,
                                        string sModule,
                                        string sSeverity,
                                        string sError)
        {
            string sMessage;

            sMessage = "Problem auditing!" + Environment.NewLine;
            sMessage += "Source[" + sModule + "]" + Environment.NewLine;
            sMessage += "Method[" + sMethod + "]" + Environment.NewLine;
            sMessage += "Line[" + sLine + "]" + Environment.NewLine;
            if (sSeverity != AuditSeverity.Unknown.ToString())
            {
                sMessage += "Severity[" + sSeverity + "]" + Environment.NewLine;
            }
            sMessage += "Error[" + sError + "]" + Environment.NewLine;

            if (m_bShowErrorOnMessageBox)
            {
                MessageBox.Show(sMessage);
            }
        }

        private void WriteToEventLog(string sMethod, string sMessage)
        {
            Utils.WriteToEventLog("DVR Client",
                                  "Audit - " + sMethod,
                                  sMessage,
                                  0,
                                  EventLogEntryType.Warning);
        } 

        #endregion

        #region ListBox Selection

        private void lstSeverity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sThisMethod = MethodBase.GetCurrentMethod().Name;

            try
            {
                m_SeverityFilter = lstSeverity.Items[lstSeverity.SelectedIndex].ToString();
            }
            catch (Exception ex)
            {
                WriteToEventLog(sThisMethod, ex.Message);
            }
        }

        private void lstModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sThisMethod = MethodBase.GetCurrentMethod().Name;

            try
            {
                m_ModuleFilter = lstModule.Items[lstModule.SelectedIndex].ToString();
            }
            catch (Exception ex)
            {
                WriteToEventLog(sThisMethod, ex.Message);
            }
        }

        #endregion

        private void lvAudit_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string sThisMethod = MethodBase.GetCurrentMethod().Name;

            try
            {
                lvAuditColumnSorter.CurrentColumn = e.Column;

                // Determine if clicked column is already the column that is being sorted.  
                if (e.Column == lvAuditColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.  
                    if (lvAuditColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                    {
                        lvAuditColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                    }
                    else
                    {
                        lvAuditColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.  
                    lvAuditColumnSorter.SortColumn = e.Column;
                    lvAuditColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }

                lvAudit.Sort();
            }
            catch (Exception ex)
            {
                Utils.WriteToEventLog("DVR Client",
                                      "Audit - " + sThisMethod,
                                      ex.Message,
                                      0,
                                      EventLogEntryType.Warning);
            }
        }

        private void ParentForm_Resize(object sender, EventArgs e)
        {
            int iGap = 8;

            Width = ParentForm.Width;// -iGap;
            Height = ParentForm.Height;// - iGap * 2;

            lvAudit.Width = Width - iGap * 6;
            lvAudit.Height = Height - iGap * 22;
        }
        
        private void lvAudit_HandleDestroyed(object sender, EventArgs e)
        {

        }

        private bool StartWcfService()
        {
            string sMethod = MethodBase.GetCurrentMethod().Name;

            try
            {
                m_Client2Audit = new Client2Audit(this);

                string address = "net.pipe://localhost/AuditComm";
                m_WcfHost = new ServiceHost(m_Client2Audit);
                NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                m_WcfHost.AddServiceEndpoint(typeof(IClient2Audit), binding, address);
                m_WcfHost.Open();

                #region Tcp Duplex
                //m_WcfHost = new ServiceHost(m_Client2Audit, new Uri[] { new Uri("net.tcp://localhost:11223") });

                //m_WcfHost.AddServiceEndpoint(typeof(IClient2Audit),
                //                             new NetTcpBinding(),
                //                             "AuditComm");
                //m_WcfHost.Open();
                #endregion

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
