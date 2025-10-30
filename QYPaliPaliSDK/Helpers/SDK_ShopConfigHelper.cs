using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_ShopConfigHelper
    {
        #region singleton
        private static readonly Lazy<SDK_ShopConfigHelper> lazy = new Lazy<SDK_ShopConfigHelper>(() => new SDK_ShopConfigHelper());
        public static SDK_ShopConfigHelper Instance { get { return lazy.Value; } }
        private SDK_ShopConfigHelper() { }
        #endregion

        public SDK_ShopConfigModel loadShopConfig(string connString, string shopId)
        {
            SDK_ShopConfigModel config = new SDK_ShopConfigModel();
            DataRow drGet;
            string val = "";

            try
            {
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_ShopConfig + " WHERE ShopId='" + shopId + "'  "; 
                DataRow drC = SDK_SqlHelper.Instance.getFirstDataRow(connString, sql);
                if (drC == null)
                {
                    config.message = "Not found shop config.";
                }
                else
                {
                    val = drC["Debtor"] == DBNull.Value ? "0" : drC["Debtor"].ToString();
                    drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_debtor + " WHERE AutoKey='" + val + "'");
                    config.Debtor = Convert.ToInt64(val);
                    config.DebtorCode = drGet == null ? "" : drGet["AccNo"].ToString();

                    val = drC["PlatformRebate"] == DBNull.Value ? "0" : drC["PlatformRebate"].ToString();
                    drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_itemuom + " WHERE AutoKey='" + val + "'");
                    config.PlatformRebate = Convert.ToInt64(val);
                    config.PlatformRebate_ItemCode = drGet == null ? "" : drGet["ItemCode"].ToString();
                    config.PlatformRebate_UOM = drGet == null ? "" : drGet["UOM"].ToString();

                    val = drC["SellerDiscount"] == DBNull.Value ? "0" : drC["SellerDiscount"].ToString();
                    drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_itemuom + " WHERE AutoKey='" + val + "'");
                    config.SellerDiscount = Convert.ToInt64(val);
                    config.SellerDiscount_ItemCode = drGet == null ? "" : drGet["ItemCode"].ToString();
                    config.SellerDiscount_UOM = drGet == null ? "" : drGet["UOM"].ToString();

                    val = drC["BuyerPaidShipFee"] == DBNull.Value ? "0" : drC["BuyerPaidShipFee"].ToString();
                    drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_itemuom + " WHERE AutoKey='" + val + "'");
                    config.BuyerPaidShipFee = Convert.ToInt64(val);
                    config.BuyerPaidShipFee_ItemCode = drGet == null ? "" : drGet["ItemCode"].ToString();
                    config.BuyerPaidShipFee_UOM = drGet == null ? "" : drGet["UOM"].ToString();

                    val = drC["BundleVariance"] == DBNull.Value ? "0" : drC["BundleVariance"].ToString();
                    drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_itemuom + " WHERE AutoKey='" + val + "'");
                    config.BundleVariance = Convert.ToInt64(val);
                    config.BundleVariance_ItemCode = drGet == null ? "" : drGet["ItemCode"].ToString();
                    config.BundleVariance_UOM = drGet == null ? "" : drGet["UOM"].ToString();

                    val = drC["ShopDraft"] == DBNull.Value ? "1" : drC["ShopDraft"].ToString();
                    if (val =="1")
                    {
                        config.ShopDraft = true;
                    }
                    else if (val == "True")
                    {
                        config.ShopDraft = true;
                    }
                    else
                    {
                        config.ShopDraft = false;
                    }

                    val = drC["PaymentMethod"] == DBNull.Value ? "0" : drC["PaymentMethod"].ToString();
                    drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_paymentmethod + " WHERE AutoKey='" + val + "'");
                    config.PaymentMethod = Convert.ToInt64(val);
                    config.PaymentMethodCode = drGet == null ? "" : drGet["PaymentMethod"].ToString();

                    val = drC["AutoCreateARPayment"] == DBNull.Value ? "1" : drC["AutoCreateARPayment"].ToString();
                    if (val == "1")
                    {
                        config.AutoCreateARPayment = true;
                    }
                    else if (val == "True")
                    {
                        config.AutoCreateARPayment = true;
                    }
                    else
                    {
                        config.AutoCreateARPayment = false;
                    }

                    config.success = true;
                }
            }
            catch (Exception ex)
            {
                config.message = ex.Message + (ex.InnerException == null ? "" : ex.InnerException.Message);
            }

            return config;
        }
    }
}
