using QYPaliPaliSDK.General;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QYPaliPaliSDK.General.SDK_Enums;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_LogHelper
    {
        #region singleton
        private static readonly Lazy<SDK_LogHelper> lazy = new Lazy<SDK_LogHelper>(() => new SDK_LogHelper());
        public static SDK_LogHelper Instance { get { return lazy.Value; } }
        private SDK_LogHelper() { }
        #endregion

        public void insert_LogDBFile(EnumLogInfoType infotype, string evt, string msg)
        {
            string oripath = "C:\\Windows\\Temp\\";
            string fileName = "FlexQianYi.txt";

            string sTxt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t " + infotype.ToString() + "\t " + evt + "\t " + msg;

            long size = 0;
            string filePath = oripath + fileName;
            try
            {
                FileInfo fi = new FileInfo(filePath);
                size = fi.Length;
            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
            }

            try
            {
                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(sTxt);
                sw.Flush();
                sw.Close();
                if (size > (5 * 1024 * 1024)) //5mb
                {
                    File.WriteAllLines(filePath, File.ReadAllLines(filePath).Skip(3));
                }
            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
            }
        }

        public void insert_LogDB(string connStr, SDK_Enums.EnumLogInfoType infotype, string msg1, string msg2, string evt, string module)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                Guid obj = Guid.NewGuid();
                sqlCmd.CommandText = "INSERT INTO " + SDK_Constants.tbl_Flex_Log + " (Id, created_at, Message1, Message2, action, module, InfoType) " +
                    "VALUES('" + obj.ToString() + "', GETDATE(), '" + msg1.Replace("'", "''") + "', '" + msg2.Replace("'", "''") + "', '" + evt.Replace("'", "''") + "', '" + module.Replace("'", "''") + "', '" + infotype.ToString() + "' ) ";

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();


                //insert_GKashLogFile(infotype, evt, msg1);

                return;

            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
                return;
            }

            //string oripath = AppDomain.CurrentDomain.BaseDirectory;
            //string fileName = "FlexLog.txt";

            //string sTxt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t " + infotype.ToString() + "\t " + evt + "\t " + msg1 + "\t " + msg2;

            //try
            //{
            //    string filePath = oripath + fileName;
            //    FileInfo fi = new FileInfo(filePath);
            //    long size = fi.Length;

            //    FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            //    StreamWriter sw = new StreamWriter(fs);
            //    sw.BaseStream.Seek(0, SeekOrigin.End);
            //    sw.WriteLine(sTxt);
            //    sw.Flush();
            //    sw.Close();
            //    if (size > (5 * 1024 * 1024)) //5mb
            //    {
            //        File.WriteAllLines(filePath, File.ReadAllLines(filePath).Skip(3));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string e = ex.Message;
            //}
        }

        public void delete_LogDB(string connStr, int day)
        {
            try
            {
                string sql = "DELETE FROM " + SDK_Constants.tbl_Flex_Log + " WHERE cast(created_at as date) < '" + DateTime.Now.AddDays(day * -1).ToString("yyyy-MM-dd") + "'  ";
                SDK_SqlHelper.Instance.execnonquerySql(connStr, sql);
                return;
            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
            }
        }

        public void insert_SyncLogDB(string connStr, SDK_Enums.EnumLogInfoType infotype, string msg1, string msg2, string evt, string module)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                Guid obj = Guid.NewGuid();
                sqlCmd.CommandText = "INSERT INTO " + SDK_Constants.tbl_Flex_SyncLog + " (Id, created_at, Message1, Message2, action, module, InfoType) " +
                    "VALUES('" + obj.ToString() + "', GETDATE(), '" + msg1.Replace("'", "''") + "', '" + msg2.Replace("'", "''") + "', '" + evt.Replace("'", "''") + "', '" + module.Replace("'", "''") + "', '" + infotype.ToString() + "' ) ";

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();


                //insert_GKashLogFile(infotype, evt, msg1);

                return;

            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
                return;
            }

            //string oripath = AppDomain.CurrentDomain.BaseDirectory;
            //string fileName = "FlexLog.txt";

            //string sTxt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t " + infotype.ToString() + "\t " + evt + "\t " + msg1 + "\t " + msg2;

            //try
            //{
            //    string filePath = oripath + fileName;
            //    FileInfo fi = new FileInfo(filePath);
            //    long size = fi.Length;

            //    FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            //    StreamWriter sw = new StreamWriter(fs);
            //    sw.BaseStream.Seek(0, SeekOrigin.End);
            //    sw.WriteLine(sTxt);
            //    sw.Flush();
            //    sw.Close();
            //    if (size > (5 * 1024 * 1024)) //5mb
            //    {
            //        File.WriteAllLines(filePath, File.ReadAllLines(filePath).Skip(3));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string e = ex.Message;
            //}
        }

        public void delete_SyncLogDB(string connStr, int day)
        {
            try
            {
                string sql = "DELETE FROM " + SDK_Constants.tbl_Flex_SyncLog + " WHERE cast(created_at as date) < '" + DateTime.Now.AddDays(day * -1).ToString("yyyy-MM-dd") + "'  ";
                SDK_SqlHelper.Instance.execnonquerySql(connStr, sql);
                return;
            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
            }
        }

        public void insert_SyncRecordDB(string connStr, string req, string res, string remark)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                Guid obj = Guid.NewGuid();
                sqlCmd.CommandText = "INSERT INTO " + SDK_Constants.tbl_Flex_SyncRecord + " (Id, created_at, RequestJSON, ResponseJSON, Remark) " +
                    "VALUES('" + obj.ToString() + "', GETDATE(), '" + req.Replace("'", "''") + "', '" + res.Replace("'", "''") + "', '" + remark.Replace("'", "''") + "'  ) ";

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();


                //insert_GKashLogFile(infotype, evt, msg1);

                return;

            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
                return;
            }

        }

    }
}
