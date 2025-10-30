using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models
{
    public class SDK_ServiceResponseModel
    {
        public bool success { get; set; } = false;
        public string message { get; set; } = null;
        public string description { get; set; } = null;
        public long dockey { get; set; } = 0;
        public long dtlkey { get; set; } = 0;
        public string docno { get; set; } = "";
        public DataTable dt1 { get; set; } = new DataTable();
        public DataTable dt2 { get; set; } = new DataTable();
        public DataSet ds1 { get; set; } = new DataSet();
        public int totalRecords { get; set; } = 0;
        public object obj { get; set; }
    }
}
