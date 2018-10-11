using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Audit
{
    public enum AuditSeverity
    {
        Unknown = 0,
        Information = 1,
        Warning = 2,
        Error = 4,
        Important = 8,
        Urgent = 16
    };
}
