using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.General
{
    public class SDK_Enums
    {
        public enum EnumConfiguration
        {
            s_isStart,
            s_dateStart,
            s_lastSyncDate,
            s_restartSyncDate,

            s_api_url,
            s_api_accesskey,
            s_api_accesssecret,
            s_api_pageSize,

            dayDeleteAppLog, 
            dayDeleteSyncLog
        }

        public enum EnumLogInfoType
        {
            INF,
            WRN,
            ERR,
        }

        public enum EnumLogInfoModule
        {
            BeforeLoad,
            Config,
            Service,
        }

        public enum EnumDocState
        {
            New,
            Edit,
            View
        }

        public enum EnumSalesOrderStatus
        {
            ALL,

            WAIT_PAYMENT,
            WAIT_AUDIT,
            WAIT_SHIP,
            SHIPPING,
            SHIP_FAILURE,
            PARTIALLY_SHIPPED,
            SHIPPED,
            CLOSED
        }

        public enum EnumInboundOrderStatus
        {
            ALL,

            NEW,
            DELETED,
            SHIPPING,
            RECEIVING,
            FINISHED,
            CLOSED
        }

        public enum EnumInboundOrderTimeType
        {
            CREATE_TIME,
            STOCK_IN_TIME,
            FINISH_TIME
        }

        public enum EnumShopConfig
        {
            shopId,
            shop_debtor,
            shop_desc,
            platformRebate,
            platformRebateForWook,
            sellerDiscount,
            sellerDicsountForWook,
            buyerPaidShipFee,
            bundleVariance,
            d_platformDiscount,
            d_promotionDiscount,
            d_shipping,
            d_totalDiscount,
            autoCreateARPay,
            paymentMethod,
            shop_draft,
        }

        public enum EnumShopOfflineConfig
        {
            shopId,
            shop_desc,
            paymentMethod,
            defaultShop,
            skipPOSync
        }

        public enum EnumDocType
        {
            SO,
            PO,
        }

        public enum EnumSyncDocType
        {
            SO,
            ASN,
        }

    }
}
