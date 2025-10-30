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
    class MappingHelper
    {
        #region singleton
        private static readonly Lazy<MappingHelper> lazy = new Lazy<MappingHelper>(() => new MappingHelper());
        public static MappingHelper Instance { get { return lazy.Value; } }
        private MappingHelper() { }
        #endregion

        internal SDK_ServiceResponseModel update_ItemMap(long itemKey, long packKey, string qySKU, string qyTitle)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(PluginConstants.myUserSession.DBSetting.ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                string sql = "";
                if (itemKey == 0 && packKey == 0)
                {
                    sql = string.Format(@"DELETE FROM {0} WHERE QYSKU = '{1}'  ", SDK_Constants.tbl_Flex_ItemMap, qySKU);
                }
                else
                {
                    sql = string.Format(@"IF NOT EXISTS (SELECT 1 FROM {0} WHERE QYSKU = '{1}'  )
                                    BEGIN
                                       INSERT INTO {0} (Item, ItemPackage, QYSKU, QYTitle, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate) 
                                            values ('{3}','{4}','{1}','{2}',@LastModifiedBy,GETDATE(),@LastModifiedBy,GETDATE())
                                    END  
                                ELSE 
                                    BEGIN
                                        UPDATE {0} SET Item='{3}', ItemPackage='{4}', LastModifiedDate=GETDATE(), LastModifiedBy=@LastModifiedBy WHERE QYSKU = '{1}'  
                                    END ", SDK_Constants.tbl_Flex_ItemMap, qySKU, qyTitle, itemKey, packKey);
                }
                sqlCmd.CommandText = sql;

                //DECLARE sql parameter
                sqlCmd.Parameters.Add("@LastModifiedBy", SqlDbType.NVarChar);

                //UPDATE column
                sqlCmd.Parameters["@LastModifiedBy"].Value = PluginConstants.myUserSession.LoginUserID;

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                serviceResponse.success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
                serviceResponse.description = ex.InnerException != null ? ex.InnerException.Message : "";
                //AutoCount.AppMessage.ShowInformationMessage(serviceResponse.description);
            }

            return serviceResponse;
        }

        internal SDK_ServiceResponseModel update_LocationMap(long key, string qyId, string qyName)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(PluginConstants.myUserSession.DBSetting.ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                string sql = "";
                if (key == 0)
                {
                    sql = string.Format(@"DELETE FROM {0} WHERE QYId = '{1}' ", SDK_Constants.tbl_Flex_LocMap, qyId);
                }
                else
                {
                    sql = string.Format(@"IF NOT EXISTS (SELECT 1 FROM {0} WHERE QYId = '{1}' )
                                    BEGIN
                                       INSERT INTO {0} (Location, QYId, QYName, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate) 
                                            values ('{3}','{1}','{2}',@LastModifiedBy,GETDATE(),@LastModifiedBy,GETDATE())
                                    END  
                                ELSE 
                                    BEGIN
                                        UPDATE {0} SET Location='{3}', LastModifiedDate=GETDATE(), LastModifiedBy=@LastModifiedBy WHERE QYId = '{1}' 
                                    END ", SDK_Constants.tbl_Flex_LocMap, qyId, qyName, key);
                }
                sqlCmd.CommandText = sql;

                //DECLARE sql parameter
                sqlCmd.Parameters.Add("@LastModifiedBy", SqlDbType.NVarChar);

                //UPDATE column
                sqlCmd.Parameters["@LastModifiedBy"].Value = PluginConstants.myUserSession.LoginUserID;

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                serviceResponse.success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
                serviceResponse.description = ex.InnerException != null ? ex.InnerException.Message : "";
                //AutoCount.AppMessage.ShowInformationMessage(serviceResponse.description);
            }

            return serviceResponse;
        }

        internal SDK_ServiceResponseModel update_PaymentMethodMap(long key, string qyEnum)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(PluginConstants.myUserSession.DBSetting.ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                string sql = "";
                sql = string.Format(@"IF NOT EXISTS (SELECT 1 FROM {0} WHERE PaymentMethod = '{2}' )
                                    BEGIN
                                       INSERT INTO {0} (PaymentMethod, QYEnum, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate) 
                                            values ('{2}','{1}', @LastModifiedBy,GETDATE(),@LastModifiedBy,GETDATE())
                                    END  
                                ELSE 
                                    BEGIN
                                        UPDATE {0} SET QYEnum='{1}', LastModifiedDate=GETDATE(), LastModifiedBy=@LastModifiedBy WHERE PaymentMethod = '{2}' 
                                    END ", SDK_Constants.tbl_Flex_PaymentMap, qyEnum, key);
                sqlCmd.CommandText = sql;

                //DECLARE sql parameter
                sqlCmd.Parameters.Add("@LastModifiedBy", SqlDbType.NVarChar);

                //UPDATE column
                sqlCmd.Parameters["@LastModifiedBy"].Value = PluginConstants.myUserSession.LoginUserID;

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                serviceResponse.success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
                serviceResponse.description = ex.InnerException != null ? ex.InnerException.Message : "";
                //AutoCount.AppMessage.ShowInformationMessage(serviceResponse.description);
            }

            return serviceResponse;
        }

        internal SDK_ServiceResponseModel update_CurrencyMap(string curGuid, string qyEnum)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(PluginConstants.myUserSession.DBSetting.ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                string sql = "";
                sql = string.Format(@"IF NOT EXISTS (SELECT 1 FROM {0} WHERE Currency = '{2}' )
                                    BEGIN
                                       INSERT INTO {0} (Currency, QYEnum, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate) 
                                            values ('{2}','{1}', @LastModifiedBy,GETDATE(),@LastModifiedBy,GETDATE())
                                    END  
                                ELSE 
                                    BEGIN
                                        UPDATE {0} SET QYEnum='{1}', LastModifiedDate=GETDATE(), LastModifiedBy=@LastModifiedBy WHERE Currency = '{2}' 
                                    END ", SDK_Constants.tbl_Flex_CurrencyMap, qyEnum, curGuid);
                sqlCmd.CommandText = sql;

                //DECLARE sql parameter
                sqlCmd.Parameters.Add("@LastModifiedBy", SqlDbType.NVarChar);

                //UPDATE column
                sqlCmd.Parameters["@LastModifiedBy"].Value = PluginConstants.myUserSession.LoginUserID;

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                serviceResponse.success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
                serviceResponse.description = ex.InnerException != null ? ex.InnerException.Message : "";
                //AutoCount.AppMessage.ShowInformationMessage(serviceResponse.description);
            }

            return serviceResponse;
        }

    }
}
