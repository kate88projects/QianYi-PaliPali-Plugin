using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APISalesOrder_ListResModel
    {
        public bool notSuccess { get; set; }
        public List<SDK_APISalesOrder_InfoModel> result { get; set; }
        public string state { get; set; }
        public int total { get; set; }
    }

    public class SDK_APISalesOrder_InfoModel
    {
        public SDK_APISalesOrder_BuyerInfoModel buyer { get; set; }
        public string buyerMessage { get; set; }
        public double buyerPaidShippingFee { get; set; }
        public string carrier { get; set; }
        public long createTime { get; set; }
        public string currency { get; set; }
        public double finalProductProtection { get; set; }
        public bool forceSys { get; set; }
        public double freight { get; set; }
        public double isAFNv { get; set; }
        public double isDeleted { get; set; }
        public bool isOriginalOrder { get; set; }
        public bool isSys { get; set; }
        public long latestShipDate { get; set; }
        public string logisticsSelected { get; set; }
        public string onlineOrderNumber { get; set; }
        public string onlineStatus { get; set; }
        public string orderNumber { get; set; }
        public string orderTime { get; set; }
        public long payTime { get; set; }
        public string paymentMethod { get; set; }
        public string platform { get; set; }
        public double platformRebate { get; set; }
        public double platformRebateForWook { get; set; }
        public double platformReturnToSeller { get; set; }
        public double sellerDiscount { get; set; }
        public double sellerDiscountForWook { get; set; }
        public string shop { get; set; }
        public long shopId { get; set; }
        public string siteCode { get; set; }

        public List<SDK_APISalesOrder_SKUInfoModel> skuList { get; set; }

        public string status { get; set; }
        public long systemOrderShippedTime { get; set; }
        public double totalAmount { get; set; }
        public double totalDiscount { get; set; }
        public string trackingNumber { get; set; }
        public long updateTime { get; set; }
        public string voucherCode { get; set; }
        public string warehouse { get; set; }
        public string warehouseType { get; set; }
    }
    public class SDK_APISalesOrder_BuyerInfoModel
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string buyerId { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public int isDeleted { get; set; }
        public string phone { get; set; }
        public string postCode { get; set; }
        public string province { get; set; }
        public string receiverName { get; set; }
    }
    public class SDK_APISalesOrder_SKUInfoModel
    {
        public double discountPrice { get; set; }
        public string onlineItemId { get; set; }
        public string onlineProductCode { get; set; }
        public string onlineProductPicUrl { get; set; }
        public string onlineProductTitle { get; set; }
        public string onlineTransactionId { get; set; }
        public long orderSkuId { get; set; }
        public double originalPrice { get; set; }
        public double payAmount { get; set; }
        public double paymentPrice { get; set; }
        public double platformDiscount { get; set; }
        public double points { get; set; }
        public double promotionDiscount { get; set; }
        public double quantity { get; set; }
        public double shippingPrice { get; set; }
        public string sku { get; set; }
        public double totalDiscount { get; set; }
        public double totalTax { get; set; }
    }
    public class SDK_APISalesOrder_TagInfoModel
    {
        public int consolidated { get; set; }
        public int hasRefund { get; set; }
        public int itemReturned { get; set; }
        public int locked { get; set; }
        public int onlineShipFeedbackAlready { get; set; }
        public int onlineShipFeedbackFailed { get; set; }
        public int onlineShipped { get; set; }
        public int outOfStock { get; set; }
        public int preSale { get; set; }
        public int reShip { get; set; }
        public int sendFailed { get; set; }
        public int sendWms { get; set; }
        public int split { get; set; }
    }
} 
