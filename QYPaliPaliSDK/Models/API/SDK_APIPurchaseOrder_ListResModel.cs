using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIPurchaseOrder_ListResModel
    {
        public bool notSuccess { get; set; }
        public List<SDK_APIPurchaseOrder_InfoModel> result { get; set; }
    }

    public class SDK_APIPurchaseOrder_InfoModel
    {
        public string purchaseNumber { get; set; }
        public string asnNumber { get; set; }
        public string customNumber { get; set; }
        public string warehouseName { get; set; }
        public string transferWarehouseName { get; set; }
        public string purchaseType { get; set; }
        public string supplierName { get; set; }
        public string settlementType { get; set; }
        public decimal prepayRate { get; set; }
        public string purchasePriceUnit { get; set; }
        public Enum paymentType { get; set; } 
        public decimal shippingCost { get; set; }
        public Enum transportMode { get; set; }
        public string buyerTitle { get; set; }
        public string companyName { get; set; }
        public string transportParty { get; set; }
        public string createTime { get; set; }
        public string updateTime { get; set; }
        public string preReceiveTime { get; set; }
        public string status { get; set; }
        public string purchaseMode { get; set; }
        public string remark { get; set;}
        public SDK_APIPurchaseOrderSKUInfoModel skuList { get; set; }
    }

    public class SDK_APIPurchaseOrderSKUInfoModel
    {
        public string sku { get; set; }
        public string title { get; set; }
        public decimal purchasePrice { get; set; }
        public int purchaseQuantity { get; set; }
        public int packSpecification { get; set; }
        public decimal taxRate { get; set; }
    }
}
