using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIInboundOrder_CreateReqModel
    {
        public string warehouseName { get; set; } // Y
        public string customNumber { get; set; }
        public string trackNumber { get; set; }
        public string remark { get; set; }
        public string purchasePriceCurrency { get; set; } // Y
        public string firstLegPriceCurrency { get; set; } // Y
        public string transferPriceCurrency { get; set; } // Y
        public List<SDK_APIInboundOrder_CreateSKUInfoModel> asnSkuVOList { get; set; }
        public string sendWarehouseFlag { get; set; }
        public string preArriveTime { get; set; }
        public string shippingType { get; set; }
        public string containerModel { get; set; }
        public string packageType { get; set; }
        public string boxCount { get; set; }
        public string type { get; set; }
        public string asnCustomFieldValueVOList { get; set; }

    }
    public class SDK_APIInboundOrder_CreateSKUInfoModel
    {
        public string sku { get; set; } // Y
        public double purchasePrice { get; set; } // Y
        public double firstLegPrice { get; set; } // Y
        public double transferPrice { get; set; } // Y
        public long expectQuantity { get; set; } // Y
        public int perBoxQuantity { get; set; }

    }

}
