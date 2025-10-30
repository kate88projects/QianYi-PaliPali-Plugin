using QYPaliPaliPlugin.General;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliPlugin.Helpers
{
    class ShopOfflineConfigHelper
    {
        #region singleton
        private static readonly Lazy<ShopOfflineConfigHelper> lazy = new Lazy<ShopOfflineConfigHelper>(() => new ShopOfflineConfigHelper());
        public static ShopOfflineConfigHelper Instance { get { return lazy.Value; } }
        private ShopOfflineConfigHelper() { }
        #endregion

        public SDK_ServiceResponseModel get_ShopList(string cond)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                string sql = "SELECT a.* " +
                    "FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " a " +
                    "WHERE a.id IS NOT NULL";
                DataTable dt = PluginConstants.myUserSession.DBSetting.GetDataTable(sql, false);

                serviceResponse.dt1 = dt;
                serviceResponse.success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
            }

            return serviceResponse;
        }

        public SDK_ServiceResponseModel update_shopConfig(long id, SDK_ShopOfflineConfigModel shopConfig)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                string sqlUpdate = "";

                if (shopConfig.DefaultShop == true)
                {
                    sqlUpdate = "UPDATE " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " " +
                        "SET DefaultShop=0 " +
                        "WHERE Id<>" + id + " ";
                    PluginConstants.myUserSession.DBSetting.ExecuteNonQuery(sqlUpdate, null);
                }

                if (id == 0)
                {
                    sqlUpdate = "INSERT INTO " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " " +
                        "(ShopId, ShopName, ShopPlatform, Description, QYPMEnum, DefaultShop, SkipPOSync, " +
                        "CreatedDate, CreatedBy, LastModifiedDate, LastModifiedBy)" +
                        "VALUES ('" + shopConfig.ShopId.Replace("'", "''") + "', '" + shopConfig.ShopName.Replace("'", "''") + "', '" +
                        shopConfig.ShopPlatform.Replace("'", "''") + "', '" + shopConfig.Description.Replace("'", "''") + "', '" + shopConfig.QYPMEnum.Replace("'", "''") + "', " +
                        (shopConfig.DefaultShop ? 1 : 0) + ", " + (shopConfig.SkipPOSync ? 1 : 0) + ", " +
                        "getdate(), '" + PluginConstants.myUserSession.LoginUserID + "', getdate(), '" + PluginConstants.myUserSession.LoginUserID + "'); ";

                    PluginConstants.myUserSession.DBSetting.ExecuteNonQuery(sqlUpdate, null);
                }
                else
                {
                    sqlUpdate = "UPDATE " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " " +
                        "SET ShopId='" + shopConfig.ShopId.Replace("'", "''") + "', ShopName='" + shopConfig.ShopName.Replace("'", "''") + "', " +
                        "ShopPlatform='" + shopConfig.ShopPlatform.Replace("'", "''") + "', Description='" + shopConfig.Description.Replace("'", "''") + "', " +
                        "QYPMEnum='" + shopConfig.QYPMEnum.Replace("'", "''") + "'," +
                        "DefaultShop=" + (shopConfig.DefaultShop ? 1 : 0) + ", SkipPOSync=" + (shopConfig.SkipPOSync ? 1 : 0) + ", " +
                        "LastModifiedDate=getdate(), LastModifiedBy= '" + PluginConstants.myUserSession.LoginUserID + "' " +
                        "WHERE Id=" + id + " ";
                    PluginConstants.myUserSession.DBSetting.ExecuteNonQuery(sqlUpdate, null);
                }

                serviceResponse.success = true;
                serviceResponse.dockey = id;

            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
            }

            return serviceResponse;
        }

        public SDK_ServiceResponseModel delete_shopConfig(long id)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                string sql = "DELETE FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " WHERE Id=" + id + " ";
                PluginConstants.myUserSession.DBSetting.ExecuteNonQuery(sql);

                serviceResponse.success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
