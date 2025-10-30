using AutoCount.Authentication;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QYPaliPaliSDK.General.SDK_Enums;

namespace QYPaliPaliPlugin.Helpers
{
    class ConfigHelper
    {
        #region singleton
        private static readonly Lazy<ConfigHelper> lazy = new Lazy<ConfigHelper>(() => new ConfigHelper());
        public static ConfigHelper Instance { get { return lazy.Value; } }
        private ConfigHelper() { }
        #endregion

        internal SDK_ServiceResponseModel get_ConfigList(UserSession userSession)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_Config + "  ";
                DataTable dt = userSession.DBSetting.GetDataTable(sql, false);

                serviceResponse.success = true;
                serviceResponse.dt1 = dt;
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

        internal SDK_ServiceResponseModel update_Config(UserSession userSession, EnumConfiguration configType, string val, bool isNull)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();

            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(userSession.DBSetting.ConnectionString);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                //READ COMMAND with difference status
                string sql = string.Format(@"IF NOT EXISTS (SELECT 1 FROM {0} WHERE ConfigTitle = '{1}')
                                    BEGIN
                                       INSERT INTO {0} (ConfigTitle, ConfigValue, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate) values ('{1}',@ConfigValue,@LastModifiedBy,GETDATE(),@LastModifiedBy,GETDATE())
                                    END  
                                ELSE 
                                    BEGIN
                                        UPDATE {0} SET ConfigValue=@ConfigValue, LastModifiedDate=GETDATE(), LastModifiedBy=@LastModifiedBy WHERE ConfigTitle = '{1}'
                                    END ", SDK_Constants.tbl_Flex_Config, configType.ToString());
                sqlCmd.CommandText = sql;
                //DECLARE sql parameter
                sqlCmd.Parameters.Add("@ConfigValue", SqlDbType.NVarChar);
                sqlCmd.Parameters.Add("@LastModifiedBy", SqlDbType.NVarChar);

                //UPDATE column
                sqlCmd.Parameters["@ConfigValue"].Value = isNull ? null : val;
                sqlCmd.Parameters["@LastModifiedBy"].Value = userSession.LoginUserID;

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
