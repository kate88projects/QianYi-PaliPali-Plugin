using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.General
{
    public class SDK_Constants
    {
        // ---------------------------- TABLE ----------------------------
        public static string tbl_Flex_Log { get; set; } = "Flex_QianYi_Log";
        public static string tbl_Flex_SyncLog { get; set; } = "Flex_QianYi_SyncLog";

        public static string tbl_Flex_Config { get; set; } = "Flex_QianYi_Config";
        public static string tbl_Flex_ShopConfig { get; set; } = "Flex_QianYi_ShopConfig";
        public static string tbl_Flex_ShopOfflineConfig { get; set; } = "Flex_QianYi_ShopOfflineConfig";
        public static string tbl_Flex_ShopOfflineConfig_Debtor { get; set; } = "Flex_QianYi_ShopOfflineConfig_Debtor";
        public static string tbl_Flex_PendingSync { get; set; } = "Flex_QianYi_PendingSync";

        public static string tbl_Flex_LocMap { get; set; } = "Flex_QianYi_LocationMapping";
        public static string tbl_Flex_CreditorMap { get; set; } = "Flex_QianYi_CreditorMapping";
        public static string tbl_Flex_ItemMap { get; set; } = "Flex_QianYi_ItemMapping";
        public static string tbl_Flex_PaymentMap { get; set; } = "Flex_QianYi_PaymentMethodMapping";
        public static string tbl_Flex_CurrencyMap { get; set; } = "Flex_QianYi_CurrencyMapping";

        public static string tbl_Flex_SyncRecord { get; set; } = "Flex_QianYi_SyncRecord";
        public static string tbl_Flex_SyncRevision { get; set; } = "Flex_QianYi_SyncRevision";

        public static string tbl_currency { get; set; } = "CURRENCY";

        public static string tbl_debtor { get; set; } = "Debtor";
        public static string tbl_creditor { get; set; } = "Creditor";
        public static string tbl_branch { get; set; } = "Branch";
        public static string tbl_item { get; set; } = "Item";
        public static string tbl_itemuom { get; set; } = "ItemUOM";
        public static string tbl_itemsubcode { get; set; } = "ItemSubCode";
        public static string tbl_location { get; set; } = "Location";
        public static string tbl_paymentmethod { get; set; } = "PaymentMethod";
        public static string tbl_pack { get; set; } = "Package";
        public static string tbl_packdtl { get; set; } = "PackageDTL";

        public static string tbl_arinv { get; set; } = "ARInvoice";
        public static string tbl_arinvdtl { get; set; } = "ARInvoiceDTL";
        public static string tbl_tr { get; set; } = "XFER";
        public static string tbl_trdtl { get; set; } = "XFERDTL";
        public static string tbl_iv { get; set; } = "IV";
        public static string tbl_ivdtl { get; set; } = "IVDTL";
        public static string tbl_cs { get; set; } = "CS";
        public static string tbl_csdtl { get; set; } = "CSDTL";
        public static string tbl_itembatch { get; set; } = "ItemBatch";
        public static string tbl_itemgroup { get; set; } = "ItemGroup";
        public static string tbl_adj { get; set; } = "ADJ";
        public static string tbl_adjdtl { get; set; } = "ADJDTL";
        public static string tbl_so { get; set; } = "SO";
        public static string tbl_sodtl { get; set; } = "SODTL";
        public static string tbl_po { get; set; } = "PO";
        public static string tbl_podtl { get; set; } = "PODTL";
        public static string tbl_pi { get; set; } = "PI";
        public static string tbl_pidtl { get; set; } = "PIDTL";


        // ---------------------------- UDF ----------------------------
        public static string udf_iv_qydocno { get; set; } = "QYDocNo";
        public static string udf_so_delcountry{ get; set; } = "DelCountry";
        public static string udf_so_delcprovince { get; set; } = "DelProvince";
        public static string udf_so_delcity { get; set; } = "DelCity";
        public static string udf_so_delpostcode { get; set; } = "DelPostCode";
        public static string udf_so_posteddate { get; set; } = "QYPostedDate";
        public static string udf_so_orderno { get; set; } = "QYOrderNo";
        public static string udf_sodtl_posteddate { get; set; } = "QYPostedDate";

        public static string udf_pi_qydocno { get; set; } = "QYDocNo";
        public static string udf_po_posteddate { get; set; } = "QYPostedDate";
        public static string udf_po_orderno { get; set; } = "QYOrderNo";
        public static string udf_podtl_posteddate { get; set; } = "QYPostedDate";

        // ---------------------------- FORMAT ----------------------------
        public static string format_datedisplay { get; set; } = "dd/MM/yyyy";
        public static string format_datesql { get; set; } = "yyy-MM-dd";

        // ---------------------------- SERVICE ----------------------------
        public const string sync_user = "QIANYIAPI";
        public const string sync_pass = "QIANYIAPI@123";
        public const string syncservice_path = "C:\\Program Files (x86)\\Flex Software Consulting Sdn Bhd\\QIANYIService.Setup";
        public const string syncservice_tokenfilename = "QIANYIService_t.txt";

        public static int api_pagesize = 100;

        // ---------------------------- API ----------------------------
        public static string api_post_shop = "api/v1/shop";
        public static string api_post_stock = "api/v1/sku";
        public static string api_post_warehouse = "api/v1/warehouse";
        public static string api_post_salesOrder = "api/v1/salesOrder";
        public static string api_post_purchaseOrder = "api/v1/purchase";
        public static string api_post_inboundOrder = "api/v1/asn";
        public static string api_post_report = "api/v1/report";

        // ---------------------------- API SERVICE TYPE ----------------------------
        public static string api_servicetype_getShopList = "QUERY_SHOP_LIST";
        public static string api_servicetype_getStockList = "QUERY_SIMPLE_LIST_SKU";
        public static string api_servicetype_getWarehouseList = "QUERY_WAREHOUSE_LIST";
        public static string api_servicetype_getSalesOrderList = "QUERY_SALES_ORDER_LIST";
        public static string api_servicetype_getPurchaseOrderList = "QUERY_PURCHASE_ORDER_LIST";
        public static string api_servicetype_getInboundOrderList = "QUERY_ASN_LIST";
        public static string api_servicetype_createPurchaseOrder = "CREATE_PURCHASE_ORDER";
        public static string api_servicetype_createSalesOrder = "CREATE_SALES_ORDER";
        public static string api_servicetype_createInboundOrder = "CREATE_ASN_ORDER";

        public static string api_servicetype_getShopeeTransaction = "QUERY_SHOPEE_TRANSACTION_DETAIL_LIST";
    }
}
