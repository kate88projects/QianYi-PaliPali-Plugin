using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models
{
    public class SDK_ShopConfigModel
    {
        public bool success { get; set; } = false;
        public string message { get; set; } = "";
        public string ShopId { get; set; } = "";
        public string ShopName { get; set; } = "";
        public string ShopPlatform { get; set; } = "";
        public string Description { get; set; } = "";
        
        public long Debtor { get; set; } = 0;
        public string DebtorCode { get; set; } = "";

        public long PlatformRebate { get; set; } = 0;
        public string PlatformRebate_ItemCode { get; set; } = "";
        public string PlatformRebate_UOM { get; set; } = "";
        public long PlatformRebateForWook { get; set; } = 0;
        public string PlatformRebateForWook_ItemCode { get; set; } = "";
        public string PlatformRebateForWook_UOM { get; set; } = "";
        public long SellerDiscount { get; set; } = 0;
        public string SellerDiscount_ItemCode { get; set; } = "";
        public string SellerDiscount_UOM { get; set; } = "";
        public long SellerDiscountForWook { get; set; } = 0;
        public string SellerDiscountForWook_ItemCode { get; set; } = "";
        public string SellerDiscountForWook_UOM { get; set; } = "";

        public long D_PlatformDiscount { get; set; } = 0;
        public string D_PlatformDiscount_ItemCode { get; set; } = "";
        public string D_PlatformDiscount_UOM { get; set; } = "";
        public long D_PromotionDiscount { get; set; } = 0;
        public string D_PromotionDiscount_ItemCode { get; set; } = "";
        public string D_PromotionDiscount_UOM { get; set; } = "";
        public long D_Shipping { get; set; } = 0;
        public string D_Shipping_ItemCode { get; set; } = "";
        public string D_Shipping_UOM { get; set; } = "";
        public long D_TotalDiscount { get; set; } = 0;
        public string D_TotalDiscount_ItemCode { get; set; } = "";
        public string D_TotalDiscount_UOM { get; set; } = "";

        public bool AutoCreateARPayment { get; set; } = false;
        public long PaymentMethod { get; set; } = 0;
        public string PaymentMethodCode { get; set; } = "";

        public bool ShopDraft { get; set; } = false;
        public long BuyerPaidShipFee { get; set; } = 0;
        public string BuyerPaidShipFee_ItemCode { get; set; } = "";
        public string BuyerPaidShipFee_UOM { get; set; } = "";

        public long BundleVariance { get; set; } = 0;
        public string BundleVariance_ItemCode { get; set; } = "";
        public string BundleVariance_UOM { get; set; } = "";
    }
}
