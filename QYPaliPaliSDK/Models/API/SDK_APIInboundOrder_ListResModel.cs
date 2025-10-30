using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIInboundOrder_ListResModel
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public string state { get; set; }
        public int total { get; set; }
        public List<SDK_APIInboundOrder_InfoModel> result { get; set; }
    }

    public class SDK_APIInboundOrder_InfoModel
    {
        public string asnNumber { get; set; }
        public string businessNumber { get; set; }
        public string customNumber { get; set; }
        public string trackNumber { get; set; }
        public string warehouseName { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
        public string stockInTime { get; set; }
        public string finishTime { get; set; }
        public string purchasePriceCurrency { get; set; }
        public string firstLegPriceCurrency { get; set; }
        public string transferPriceCurrency { get; set; }
        public List<SDK_APIInboundOrder_SKUInfoModel> asnSkuVOList { get; set; }
    }

    public class SDK_APIInboundOrder_SKUInfoModel
    {
        public string sku { get; set; }
        public string title { get; set; }
        public double purchasePrice { get; set; }
        public double firstLegPrice { get; set; }
        public double transferPrice { get; set; }
        public long expectQuantity { get; set; }
        public long receiveQuantity { get; set; }
    }
}
