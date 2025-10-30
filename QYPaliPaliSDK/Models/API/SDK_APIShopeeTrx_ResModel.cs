using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIShopeeTrx_ResModel
    {
        public bool notSuccess { get; set; }
        public List<SDK_APIShopeeTrx_InfoModel> result { get; set; }
        public string state { get; set; }
        public int total { get; set; }
    }
    public class SDK_APIShopeeTrx_InfoModel
    {
        public string shopName { get; set; }
        public string ordersn { get; set; }
        public long payoutTime { get; set; }
        public string currency { get; set; }
        public decimal originalPrice { get; set; }
        public decimal sellerDiscount { get; set; }
        public decimal productSaleAmount { get; set; }
        public decimal refundAmount { get; set; }
        public decimal shopeeDiscount { get; set; }
        public decimal voucherFromSeller { get; set; }
        public decimal sellerCoinCashBack { get; set; }
        public decimal buyerPaidShippingFee { get; set; }
        public decimal shopeeShippingRebate { get; set; }
        public decimal actualShippingFee { get; set; }
        public decimal reverseShippingFee { get; set; }
        public decimal commissionFee { get; set; }
        public decimal serviceFee { get; set; }
        public decimal rsfSellerProtectionFeeClaimAmount { get; set; }
        public decimal rsfSellerProtectionFeePremiumAmount { get; set; }
        public decimal orderAmsCommissionFee { get; set; }
        public decimal deliverySellerProtectionFeePremiumAmount { get; set; }
        public decimal sellerTransactionFee { get; set; }
        public decimal escrowTax { get; set; }
        public decimal sellerLostCompensation { get; set; }
        public decimal sellerShippingDiscount { get; set; }
        public decimal buyerTotalAmount { get; set; }
        public decimal coins { get; set; }
        public decimal voucherFromShopee { get; set; }
        public decimal crossBorderTax { get; set; }
        public decimal paymentPromotion { get; set; }
        public decimal estimatedShippingFee { get; set; }
        public decimal finalShippingFee { get; set; }
        public decimal shippingFeeDiscountFrom3pl { get; set; }
        public string sellerVoucherCode { get; set; }
        public decimal offlineAdjustment { get; set; }
        public string module { get; set; }
        public string scenario { get; set; }
        public decimal adjustmentAmount { get; set; }
        public string remark { get; set; }
    }
}
