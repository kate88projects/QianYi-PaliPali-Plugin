using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QYPaliPaliSDK.General.SDK_Enums;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_ConfigHelper
    {
        #region singleton
        private static readonly Lazy<SDK_ConfigHelper> lazy = new Lazy<SDK_ConfigHelper>(() => new SDK_ConfigHelper());
        public static SDK_ConfigHelper Instance { get { return lazy.Value; } }
        private SDK_ConfigHelper() { }
        #endregion

        public SDK_ConfigModel loadConfig(string connString)
        {
            SDK_ConfigModel config = new SDK_ConfigModel();
            string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_Config + "   ";
            DataTable dtDefVal = SDK_SqlHelper.Instance.getDataTable(connString, sql);
            if (dtDefVal.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDefVal.Rows)
                {
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_isStart.ToString())
                    {
                        config.s_isStart = dr["ConfigValue"].ToString() == "1" ? true : false;
                    }
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_dateStart.ToString())
                    {
                        config.s_dateStart = dr["ConfigValue"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ConfigValue"].ToString());
                    }
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_lastSyncDate.ToString())
                    {
                        config.s_lastSyncDate = dr["ConfigValue"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ConfigValue"].ToString());
                    }
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_restartSyncDate.ToString())
                    {
                        config.s_restartSyncDate = dr["ConfigValue"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ConfigValue"].ToString());
                    }

                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_api_url.ToString())
                    {
                        config.s_api_url = dr["ConfigValue"] == DBNull.Value ? "" : dr["ConfigValue"].ToString();
                    }
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_api_accesskey.ToString())
                    {
                        config.s_api_accesskey = dr["ConfigValue"] == DBNull.Value ? "" : dr["ConfigValue"].ToString();
                    }
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_api_accesssecret.ToString())
                    {
                        string t = dr["ConfigValue"] == DBNull.Value ? "" : dr["ConfigValue"].ToString();
                        string pass = t.Trim() == "" ? "" : SDK_EncryptHelper.Instance.Decrypt(t);
                        config.s_api_accesssecret = pass;
                    }
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.s_api_pageSize.ToString())
                    {
                        config.s_api_pageSize = dr["ConfigValue"] == DBNull.Value ? 100 : Convert.ToInt32(dr["ConfigValue"].ToString());
                        SDK_Constants.api_pagesize = dr["ConfigValue"] == DBNull.Value ? 100 : Convert.ToInt32(dr["ConfigValue"].ToString());
                    }

                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.dayDeleteAppLog.ToString())
                    {
                        config.dayDeleteAppLog = dr["ConfigValue"] == DBNull.Value ? 15 : Convert.ToInt32(dr["ConfigValue"].ToString());
                    }
                    if (dr["ConfigTitle"].ToString() == EnumConfiguration.dayDeleteSyncLog.ToString())
                    {
                        config.dayDeleteSyncLog = dr["ConfigValue"] == DBNull.Value ? 5 : Convert.ToInt32(dr["ConfigValue"].ToString());
                    }

                }
            }
            else
            {
                //sqlup.create_DefaultSetting(dbSetting, docType, ConfigTitle);
            }
            return config;
        }
    }
}
