using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIInboundOrder_ListReqModel
    {
        public string warehouseName { get; set; } = "";
        public string type { get; set; } = "";
        public string status { get; set; } = "";
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 50;
        public string number { get; set; } = "";
        public string trackNumber { get; set; } = "";
        public string timeType { get; set; } = "";
        public string timeFrom { get; set; } = "";
        public string timeEnd { get; set; } = "";

    }
}
