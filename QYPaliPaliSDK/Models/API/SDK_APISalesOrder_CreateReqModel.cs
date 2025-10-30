using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APISalesOrder_CreateReqModel
    {
        public string shop { get; set; }
        public string onlineOrderNumber { get; set; }
        public string paymentMethod { get; set; }
        public string currency { get; set; }
        public string payTime { get; set; }
        public SDK_APISalesOrder_CreateBuyerInfoModel buyer { get; set; }
        public List<SDK_APISalesOrder_CreateSKUInfoModel> skuList { get; set; }
    }

    public class SDK_APISalesOrder_CreateBuyerInfoModel
    {
        public string receiverName { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string postCode { get; set; }
        public string address1 { get; set; }
    }

    public class SDK_APISalesOrder_CreateSKUInfoModel
    {
        public string sku { get; set; }
        public double payAmount { get; set; }
        public double paymentPrice { get; set; }
        public int quantity { get; set; }
    }
}
