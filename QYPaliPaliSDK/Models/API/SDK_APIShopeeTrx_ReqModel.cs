using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIShopeeTrx_ReqModel
    {
        //public string onlineOrderId { get; set; } = "";
        public List<string> shopNameList { get; set; } = new List<string>();
        public string payoutTimeFrom { get; set; } = "";
        public string payoutTimeTo { get; set; } = "";
        public int type { get; set; } = 1;
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 50;
    }
}
