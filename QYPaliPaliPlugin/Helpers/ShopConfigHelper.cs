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
    class ShopConfigHelper
    {
        #region singleton
        private static readonly Lazy<ShopConfigHelper> lazy = new Lazy<ShopConfigHelper>(() => new ShopConfigHelper());
        public static ShopConfigHelper Instance { get { return lazy.Value; } }
        private ShopConfigHelper() { }
        #endregion

        public SDK_ServiceResponseModel get_ShopList(string cond)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                string sql = "SELECT a.*, b.AccNo, b.CompanyName FROM " + SDK_Constants.tbl_Flex_ShopConfig + " " +
                    "a INNER JOIN " + SDK_Constants.tbl_debtor + " b ON a.Debtor = b.AutoKey " +
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

        public SDK_ServiceResponseModel update_shopConfig(long id, SDK_ShopConfigModel shopConfig)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                string sqlUpdate = "";
                if (id == 0)
                {
                    /*
                    sqlUpdate = "INSERT INTO " + SDK_Constants.tbl_Flex_ShopConfig + " " +
                        "(ShopId, ShopName, ShopPlatform, Description, Debtor, PlatformRebate, PlatformRebateForWook, SellerDiscount, SellerDiscountForWook, BuyerPaidShipFee, D_PlatformDiscount," +
                        "D_PromotionDiscount, D_Shipping, D_TotalDiscount, PaymentMethod, ShopDraft, CreatedDate, CreatedBy, LastModifiedDate, LastModifiedBy)" +
                        "VALUES ('" + shopConfig.ShopId.Replace("'", "''") + "', '" + shopConfig.ShopName.Replace("'", "''") + "', '" + shopConfig.ShopPlatform.Replace("'", "''") + "', '" +
                        shopConfig.Description.Replace("'", "''") + "', '" + shopConfig.Debtor + "', '" + shopConfig.PlatformRebate + "', '" +
                        shopConfig.PlatformRebateForWook + "', '" + shopConfig.SellerDiscount + "', '" + shopConfig.SellerDiscountForWook + "', '" + shopConfig.BuyerPaidShipFee + "', '" +
                        shopConfig.D_PlatformDiscount + "', '" + shopConfig.D_PromotionDiscount + "', '" + shopConfig.D_Shipping + "', '" +
                        shopConfig.D_TotalDiscount + "', '" + shopConfig.PaymentMethod + "', '" + shopConfig.ShopDraft + "', " +
                        "getdate(), '" + PluginConstants.myUserSession.LoginUserID + "', getdate(), '" + PluginConstants.myUserSession.LoginUserID + "'); ";*/

                    sqlUpdate = "INSERT INTO " + SDK_Constants.tbl_Flex_ShopConfig + " " +
                        "(ShopId, ShopName, ShopPlatform, Description, Debtor, PlatformRebate, SellerDiscount, BuyerPaidShipFee, AutoCreateARPayment, PaymentMethod, BundleVariance, " +
                        "ShopDraft, CreatedDate, CreatedBy, LastModifiedDate, LastModifiedBy)" +
                        "VALUES ('" + shopConfig.ShopId.Replace("'", "''") + "', '" + shopConfig.ShopName.Replace("'", "''") + "', '" +
                        shopConfig.ShopPlatform.Replace("'", "''") + "', '" + shopConfig.Description.Replace("'", "''") + "', '" +
                        shopConfig.Debtor + "', '" + shopConfig.PlatformRebate + "', '" + shopConfig.SellerDiscount + "', '" +
                        shopConfig.BuyerPaidShipFee + "', '" + shopConfig.AutoCreateARPayment + "',  '" + shopConfig.PaymentMethod + "',  '" + shopConfig.BundleVariance + "',  '" + shopConfig.ShopDraft + "', " +
                        "getdate(), '" + PluginConstants.myUserSession.LoginUserID + "', getdate(), '" + PluginConstants.myUserSession.LoginUserID + "'); ";

                    PluginConstants.myUserSession.DBSetting.ExecuteNonQuery(sqlUpdate, null);
                }
                else
                {
                    /*
                    sqlUpdate = "UPDATE " + SDK_Constants.tbl_Flex_ShopConfig + " " +
                        "SET ShopId='" + shopConfig.ShopId.Replace("'", "''") + "', ShopName='" + shopConfig.ShopName.Replace("'", "''") +"', " +
                        "ShopPlatform='" + shopConfig.ShopPlatform.Replace("'", "''") + "', Description='" + shopConfig.Description.Replace("'", "''") + "', " +
                        "Debtor='" + shopConfig.Debtor + "', " +
                        "PlatformRebate='" + shopConfig.PlatformRebate + "', PlatformRebateForWook='" + shopConfig.PlatformRebateForWook + "', " +
                        "SellerDiscount='" + shopConfig.SellerDiscount + "', SellerDiscountForWook='" + shopConfig.SellerDiscountForWook + "', BuyerPaidShipFee='" + shopConfig.BuyerPaidShipFee + "', " + 
                        "D_PlatformDiscount='" + shopConfig.D_PlatformDiscount + "', D_PromotionDiscount='" + shopConfig.D_PromotionDiscount + "', " +
                        "D_Shipping='" + shopConfig.D_Shipping + "', D_TotalDiscount='" + shopConfig.D_TotalDiscount + "', " +
                        "PaymentMethod='" + shopConfig.PaymentMethod + "', ShopDraft='" + shopConfig.ShopDraft + "', " +
                        "LastModifiedDate=getdate(), LastModifiedBy= '" + PluginConstants.myUserSession.LoginUserID + "' " +
                        "WHERE Id=" + id + " ";*/

                    sqlUpdate = "UPDATE " + SDK_Constants.tbl_Flex_ShopConfig + " " +
                        "SET ShopId='" + shopConfig.ShopId.Replace("'", "''") + "', ShopName='" + shopConfig.ShopName.Replace("'", "''") + "', " +
                        "ShopPlatform='" + shopConfig.ShopPlatform.Replace("'", "''") + "', Description='" + shopConfig.Description.Replace("'", "''") + "', " +
                        "Debtor='" + shopConfig.Debtor + "', PlatformRebate='" + shopConfig.PlatformRebate + "', " +
                        "SellerDiscount='" + shopConfig.SellerDiscount + "', BuyerPaidShipFee='" + shopConfig.BuyerPaidShipFee + "',  BundleVariance='" + shopConfig.BundleVariance + "', " +
                        "AutoCreateARPayment='" + shopConfig.AutoCreateARPayment + "', PaymentMethod='" + shopConfig.PaymentMethod + "', ShopDraft='" + shopConfig.ShopDraft + "', " +
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
                string sql = "DELETE FROM " + SDK_Constants.tbl_Flex_ShopConfig + " WHERE Id=" + id + " ";
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
