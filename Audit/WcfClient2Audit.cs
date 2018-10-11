using AuditClientWcfContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Audit
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class Client2Audit : IClient2Audit
    {
        private IAudit2Client m_CallbackChannel;

        private ctlAudit m_Audit;

        public Client2Audit(ctlAudit theAudit)
        {
            m_Audit = theAudit;            
        }

        public void Audit(string sLine, string sModule, string sMethod, AuditClientWcfContract.AuditSeverity aSeverity)
        {
            m_CallbackChannel = OperationContext.Current.GetCallbackChannel<IAudit2Client>();
            m_Audit.Audit(sLine, sMethod, sModule, aSeverity.ToString());
            m_CallbackChannel.Ack(2);
        }
    }
}
