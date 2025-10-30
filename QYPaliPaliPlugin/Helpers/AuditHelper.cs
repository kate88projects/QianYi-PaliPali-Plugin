using AutoCount.AuditTrail;
using QYPaliPaliPlugin.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliPlugin.Helpers
{
    internal class AuditHelper
    {
        #region singleton
        private static readonly Lazy<AuditHelper> lazy = new Lazy<AuditHelper>(() => new AuditHelper());
        public static AuditHelper Instance { get { return lazy.Value; } }
        private AuditHelper() { }
        #endregion

        public void save_auditlog(EventType evtType, string module, string title, List<Dictionary<string, string>> dataOld, List<Dictionary<string, string>> dataNew)
        {

            //************************* Audit Trail *************************
            StringBuilder @string = new StringBuilder();

            if (evtType == EventType.Delete || evtType == EventType.New)
            {
                @string.AppendLine(evtType.ToString() + " " + title);
                int maxCnt = dataNew.Count;
                for (int i = 0; i < maxCnt; i++)
                {
                    @string.AppendLine(string.Format("{0} : {1} ", dataNew[i].Keys.First(), dataNew[i].Values.First()));
                }
            }
            else
            {
                int maxCnt = (dataOld.Count > dataNew.Count ? dataOld.Count : dataNew.Count);
                for (int i = 0; i < maxCnt; i++)
                {
                    if (dataOld[i].Values.First() != dataNew[i].Values.First())
                    {
                        @string.AppendLine(string.Format("Change {0} : {1} to {2} ", dataOld[i].Keys.First(), dataOld[i].Values.First(), dataNew[i].Values.First()));
                    }
                }
            }

            if (@string.Length > 0)
            {
                Logger.Log(PluginConstants.myUserSession, "P9", 0L, evtType, evtType.ToString() + " " + module + " " + title, @string.ToString());
            }
            //****************************************************************

        }
    }
}
