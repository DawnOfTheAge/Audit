using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace AuditClientWcfContract
{
    //[ServiceContract(SessionMode = SessionMode.Required)]
    [ServiceContract(SessionMode = SessionMode.Required,
                     CallbackContract = typeof(IAudit2Client))]
    [ServiceKnownType(typeof(AuditSeverity))]
    public interface IClient2Audit
    {
        [OperationContract]
        void Audit(string sLine, string sModule, string sMethod, AuditSeverity aSeverity);
    }

    [DataContract]
    public enum AuditSeverity
    {
        [EnumMember]
        Unknown = 0,

        [EnumMember]
        Information = 1,

        [EnumMember]
        Warning = 2,

        [EnumMember]
        Error = 4,

        [EnumMember]
        Important = 8,

        [EnumMember]
        Urgent = 16
    };

    public interface IAudit2Client
    {
        [OperationContract(IsOneWay = true)]
        void Ack(int iNumber);
    }
}
