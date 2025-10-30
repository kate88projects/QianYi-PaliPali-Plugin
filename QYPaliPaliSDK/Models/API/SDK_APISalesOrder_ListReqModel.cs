using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APISalesOrder_ListReqModel
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 50;
        public string status { get; set; } = "";
        public string orderNumber { get; set; } = "";
        public string orderNumbers { get; set; } = "";
        public string updateTimeFrom { get; set; } = "";
        public string updateTimeTo { get; set; } = "";
        public string shop { get; set; } = "";
        //public List<long> shopIdList { get; set; } = new List<long>();
        //public string latestShipTimeFrom { get; set; } = "";
        //public string latestShipTimeTo { get; set; } = "";
        //public string shippingTimeFrom { get; set; } = "";
        //public string shippingTimeTo { get; set; } = "";
        //public string orderByParam { get; set; } = "update_time";
        //public string orderByOrder { get; set; } = "asc"; //枚举值为： 1.desc 2.asc

    }
}
