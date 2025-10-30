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
    public class SDK_ShopOfflineConfigHelper
    {
        #region singleton
        private static readonly Lazy<SDK_ShopOfflineConfigHelper> lazy = new Lazy<SDK_ShopOfflineConfigHelper>(() => new SDK_ShopOfflineConfigHelper());
        public static SDK_ShopOfflineConfigHelper Instance { get { return lazy.Value; } }
        private SDK_ShopOfflineConfigHelper() { }
        #endregion

        public SDK_ShopOfflineConfigModel loadDefaultShopConfig(string connString)
        {
            SDK_ShopOfflineConfigModel config = new SDK_ShopOfflineConfigModel();
            DataRow drGet;
            string val = "";

            try
            {
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " WHERE DefaultShop=1  ";
                DataRow drC = SDK_SqlHelper.Instance.getFirstDataRow(connString, sql);
                if (drC == null)
                {
                    config.message = "Not found default shop config.";
                }
                else
                {
                    //val = drC["Debtor"] == DBNull.Value ? "0" : drC["Debtor"].ToString();
                    //drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_debtor + " WHERE AutoKey='" + val + "'");
                    //config.Debtor = Convert.ToInt64(val);
                    //config.DebtorCode = drGet == null ? "" : drGet["AccNo"].ToString();

                    //val = drC["PlatformRebate"] == DBNull.Value ? "0" : drC["PlatformRebate"].ToString();
                    //drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_itemuom + " WHERE AutoKey='" + val + "'");
                    //config.PlatformRebate = Convert.ToInt64(val);
                    //config.PlatformRebate_ItemCode = drGet == null ? "" : drGet["ItemCode"].ToString();
                    //config.PlatformRebate_UOM = drGet == null ? "" : drGet["UOM"].ToString();

                    val = drC["ShopId"] == DBNull.Value ? "" : drC["ShopId"].ToString();
                    config.ShopId = val;

                    val = drC["ShopName"] == DBNull.Value ? "" : drC["ShopName"].ToString();
                    config.ShopName = val;

                    val = drC["ShopPlatform"] == DBNull.Value ? "" : drC["ShopPlatform"].ToString();
                    config.ShopPlatform = val;

                    val = drC["QYPMEnum"] == DBNull.Value ? "" : drC["QYPMEnum"].ToString();
                    config.QYPMEnum = val;

                    val = drC["DefaultShop"] == DBNull.Value ? "1" : drC["DefaultShop"].ToString();
                    if (val == "1")
                    {
                        config.DefaultShop = true;
                    }
                    else if (val == "True")
                    {
                        config.DefaultShop = true;
                    }
                    else
                    {
                        config.DefaultShop = false;
                    }

                    val = drC["SkipPOSync"] == DBNull.Value ? "1" : drC["SkipPOSync"].ToString();
                    if (val == "1")
                    {
                        config.SkipPOSync = true;
                    }
                    else if (val == "True")
                    {
                        config.SkipPOSync = true;
                    }
                    else
                    {
                        config.SkipPOSync = false;
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

        public SDK_ShopOfflineConfigModel loadShopConfig(string connString, string id)
        {
            SDK_ShopOfflineConfigModel config = new SDK_ShopOfflineConfigModel();
            DataRow drGet;
            string val = "";

            try
            {
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " WHERE id='" + id + "'  ";
                DataRow drC = SDK_SqlHelper.Instance.getFirstDataRow(connString, sql);
                if (drC == null)
                {
                    config.message = "Not found shop config.";
                }
                else
                {
                    //val = drC["Debtor"] == DBNull.Value ? "0" : drC["Debtor"].ToString();
                    //drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_debtor + " WHERE AutoKey='" + val + "'");
                    //config.Debtor = Convert.ToInt64(val);
                    //config.DebtorCode = drGet == null ? "" : drGet["AccNo"].ToString();

                    //val = drC["PlatformRebate"] == DBNull.Value ? "0" : drC["PlatformRebate"].ToString();
                    //drGet = SDK_SqlHelper.Instance.getFirstDataRow(connString, "SELECT * FROM " + SDK_Constants.tbl_itemuom + " WHERE AutoKey='" + val + "'");
                    //config.PlatformRebate = Convert.ToInt64(val);
                    //config.PlatformRebate_ItemCode = drGet == null ? "" : drGet["ItemCode"].ToString();
                    //config.PlatformRebate_UOM = drGet == null ? "" : drGet["UOM"].ToString();

                    val = drC["ShopId"] == DBNull.Value ? "" : drC["ShopId"].ToString();
                    config.ShopId = val;

                    val = drC["ShopName"] == DBNull.Value ? "" : drC["ShopName"].ToString();
                    config.ShopName = val;

                    val = drC["ShopPlatform"] == DBNull.Value ? "" : drC["ShopPlatform"].ToString();
                    config.ShopPlatform = val;

                    val = drC["QYPMEnum"] == DBNull.Value ? "" : drC["QYPMEnum"].ToString();
                    config.QYPMEnum = val;

                    val = drC["DefaultShop"] == DBNull.Value ? "1" : drC["DefaultShop"].ToString();
                    if (val == "1")
                    {
                        config.DefaultShop = true;
                    }
                    else if (val == "True")
                    {
                        config.DefaultShop = true;
                    }
                    else
                    {
                        config.DefaultShop = false;
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
