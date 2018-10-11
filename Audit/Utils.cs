using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Audit
{
    public class Utils
    {
        public static bool WriteToEventLog(string sLogName,
                                           string sSource,
                                           string sLine,
                                           int iEventId,
                                           EventLogEntryType eletSeverity)
        {
            bool bMsgType;

            try
            {
                if (!(EventLog.SourceExists(sSource, ".")))
                {

                    EventSourceCreationData evscd = new EventSourceCreationData(sSource, sLogName);
                    EventLog.CreateEventSource(evscd);
                }

                EventLog ev = new EventLog(sLogName, ".", sSource);    // "." is used for locahost


                ev.WriteEntry(sLine, eletSeverity, iEventId);
                ev.Close();

                bMsgType = true;                //means the event has been added
            }
            catch (Exception ex)
            {
                bMsgType = false;              //means the event is not added
                string sError = ex.Message;
            }

            return bMsgType;
        }

        public static string GetEnumDescription(Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null &&
                    attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                else
                {
                    return value.ToString();
                }
            }
            catch (Exception e)
            {
                return "Error. " + e.Message;
            }
        }
    }
}
