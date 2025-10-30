using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_SqlHelper
    {
        #region singleton
        private static readonly Lazy<SDK_SqlHelper> lazy = new Lazy<SDK_SqlHelper>(() => new SDK_SqlHelper());
        public static SDK_SqlHelper Instance { get { return lazy.Value; } }
        private SDK_SqlHelper() { }
        #endregion

        public string set_RTF(string ds, string text)
        {
            RichTextBox rtbTmp = new RichTextBox(); // Temporary Rich Text Box 

            rtbTmp.Rtf = ds;
            //rtbTmp.AppendText(Environment.NewLine);
            rtbTmp.AppendText(text);
            return rtbTmp.Rtf;
        }

        public DataRow getFirstDataRow(string connstr, string sql)
        {
            DataRow result = null;

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        result = dt.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public DataTable getDataTable(string connstr, string sql)
        {
            DataTable result = new DataTable();

            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql))
                    {
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
                if (dt != null)
                {
                    result = dt;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public string execnonquerySql(string connstr, string sql)
        {
            string result = "";

            try
            {
                using (SqlConnection con = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public string execscalarSql(string connstr, string sql)
        {
            string result = "";

            try
            {
                using (SqlConnection con = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql))
                    {
                        cmd.Connection = con;
                        con.Open();
                        result = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public bool testConnection(string connstr)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connstr))

                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        connection.Close();
                    }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
