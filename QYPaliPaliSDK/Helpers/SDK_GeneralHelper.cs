using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_GeneralHelper
    {
        #region singleton
        private static readonly Lazy<SDK_GeneralHelper> lazy = new Lazy<SDK_GeneralHelper>(() => new SDK_GeneralHelper());
        public static SDK_GeneralHelper Instance { get { return lazy.Value; } }
        private SDK_GeneralHelper() { }
        #endregion

        public string get_DocStatus(string docStatus)
        {
            string result = "";

            if (docStatus == "V")
            {
                result = "Void";
            }
            else if (docStatus == "A")
            {
                result = "Approved";
            }
            else if (docStatus == "E")
            {
                result = "Expired";
            }
            else if (docStatus == "R")
            {
                result = "Rejected";
            }
            else if (docStatus == "D")
            {
                result = "Draft";
            }
            else 
            {
                result = "Awaiting Approval";
            }

            return result;
        }
    }
}
