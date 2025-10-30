using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIPurchaseOrder_CreateReqModel
    {
        public string purchaseType { get; set; }
        public string warehouseName { get; set; }
        public string transferWarehouseName { get; set; }
        public string purchaserName { get; set; }
        public string purchaseDate { get; set; }
        public string purchasePriceUnit { get; set; }
        public string transportParty { get; set; }
        public string transportMode { get; set; }
        public string supplierName { get; set; }
        public string paymentType { get; set; }
        public string settlementType { get; set; }
        public List<SDK_APIPurchaseOrder_AccPeriodListCreateInfoModel> accountPeriodList { get; set; }
        //public string accountPeriodOpt { get; set; }
        //public long billingDate { get; set; }
        public string effectiveNode { get; set; }
        public List<SDK_APIPurchaseOrder_CreateSKUInfoModel> skuList { get; set; }
    }

    public class SDK_APIPurchaseOrder_CreateSKUInfoModel
    {
        public string sku { get; set; }
        public double purchasePrice { get; set; }
        public string purchasePriceUnit { get; set; }
        public long purchaseQuantity { get; set; }
        public double taxRate { get; set; }

    }

    public class SDK_APIPurchaseOrder_AccPeriodListCreateInfoModel
    {
        public string days { get; set; }
        public int percent { get; set; }
    }
}
