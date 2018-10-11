using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Audit;
using AuditClientWcfContract;
using System.Reflection;
using System.ServiceModel;

namespace AuditTester
{
    public partial class frmMain : Form
    {
        private Audit_Form m_Audit;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> lsModule = new List<string>(new string[]{"Unknown", "yosef", "david", "dalia", "moshe", "alexander", "ervin"});

            foreach (string sModule in lsModule)
            {
                cboModule.Items.Add(sModule);
            }

            foreach (Audit.AuditSeverity aSeverity in Enum.GetValues(typeof(Audit.AuditSeverity)))
            {
                cboSeverity.Items.Add(Utils.GetEnumDescription(aSeverity));
            }

            cboModule.Text = cboModule.Items[2].ToString();
            cboSeverity.Text = cboSeverity.Items[3].ToString();

            m_Audit = new Audit_Form(true, false, 1000, lsModule);
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            if (m_Audit != null)
            {
                m_Audit.Audit(txtLine.Text, cboModule.Text, txtMethod.Text, cboSeverity.Text); 
            }
        }

        //#region WCF

        //private DuplexChannelFactory<IClient2Audit> pipeFactory;

        //private IClient2Audit Client2AuditProxy;

        //private Audit2Client a2cAudit2Client;

        //private bool ConnectToWcfService()
        //{
        //    string sMethod = MethodBase.GetCurrentMethod().Name;

        //    try
        //    {
        //        a2cAudit2Client = new Audit2Client();

        //        pipeFactory = new DuplexChannelFactory<IClient2Audit>(a2cAudit2Client,
        //                                                              new NetTcpBinding(),
        //                                                              new EndpointAddress("net.tcp://127.0.0.1:11223/AuditComm"));

        //        Client2AuditProxy = pipeFactory.CreateChannel();
        //        ((ICommunicationObject)Client2AuditProxy).Closed += new EventHandler(Channel_Faulted);
        //        ((ICommunicationObject)Client2AuditProxy).Faulted += new EventHandler(Channel_Faulted);

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

        //private void Channel_Faulted(object sender, EventArgs e)
        //{
        //    string sMethod = MethodBase.GetCurrentMethod().Name;

        //    IContextChannel channel = sender as IContextChannel;

        //    try
        //    {
        //        //if (!m_bWcfConnectionOpen)
        //        //{
        //        //    tmrWcfClientReconnectTimer = new System.Timers.Timer();
        //        //    tmrWcfClientReconnectTimer.Elapsed += tmrWcfClientReconnectTimer_Elapsed;
        //        //    tmrWcfClientReconnectTimer.Interval = Constants.SECONDS * 2;
        //        //}
        //        //else
        //        //{
        //        //    if (channel != null)
        //        //    {
        //        //        AuditPerform("Channel Faulted", sMethod, AuditSeverity.Error);

        //        //        channel.Abort();
        //        //        channel.Close();
        //        //    }

        //        //    tmrWcfKeepAliveTimer.Stop();

        //        //    AbortProxy();

        //        //    if (tmrWcfClientReconnectTimer == null)
        //        //    {
        //        //        tmrWcfClientReconnectTimer = new System.Timers.Timer();
        //        //        tmrWcfClientReconnectTimer.Elapsed += tmrWcfClientReconnectTimer_Elapsed;
        //        //        tmrWcfClientReconnectTimer.Interval = Constants.SECONDS * 2;
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public void AbortProxy()
        //{
        //    string sMethod = MethodBase.GetCurrentMethod().Name;

        //    try
        //    {
        //        if (pipeFactory != null)
        //        {
        //            pipeFactory.Abort();
        //            pipeFactory.Close();
        //            pipeFactory = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void Logout(IContextChannel channel)
        //{
        //    string sessionId = null;

        //    if (channel != null)
        //    {
        //        sessionId = channel.SessionId;
        //    }
        //}

        //[CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
        //public class Audit2Client : IAudit2Client
        //{
        //    public void Ack(int iNumber)
        //    {
        //        MessageBox.Show(iNumber.ToString());
        //    }
        //}

        //#endregion
    }
}
