using QYPaliPaliSDK.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QYPaliPaliSDK.General.SDK_Enums;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_PendingHelper
    {
        #region singleton
        private static readonly Lazy<SDK_PendingHelper> lazy = new Lazy<SDK_PendingHelper>(() => new SDK_PendingHelper());
        public static SDK_PendingHelper Instance { get { return lazy.Value; } }
        private SDK_PendingHelper() { }
        #endregion

        public void insert_PendingSync(string connStr, EnumSyncDocType docType, string docId, long docKey, string remark)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                Guid obj = Guid.NewGuid();
                string sql = string.Format(@"IF NOT EXISTS (SELECT 1 FROM {0} WHERE DocType = '{1}' AND DocId = '{2}')
                                    BEGIN
                                       INSERT INTO {0} (Id, DocType, DocId, DocKey, Remark, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate) values 
                                                ('{5}','{1}','{2}','{3}','{4}','Service',GETDATE(),'Service',GETDATE())
                                    END  
                                ELSE 
                                    BEGIN
                                        UPDATE {0} SET LastModifiedDate=GETDATE() WHERE DocType = '{1}' AND DocId = '{2}' 
                                    END ", SDK_Constants.tbl_Flex_PendingSync, docType.ToString(), docId, docKey, remark, obj.ToString());

                sqlCmd.CommandText = sql;
                    //"INSERT INTO " + SDK_Constants.tbl_Flex_PendingSync + " (Id, DocType, DocId, DocKey, Remark, " +
                    //"CreatedDate, CreatedBy, LastModifiedDate, LastModifiedBy) " +
                    //"VALUES('" + obj.ToString() + "', '" + docType.ToString().Replace("'", "''") + "', '" + docId.Replace("'", "''") + "', " + docKey + ", '" + remark.Replace("'", "''") + "', " +
                    //"GETDATE(), 'Service', GETDATE(), 'Service') "; 

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
            }
        }

    }
}
