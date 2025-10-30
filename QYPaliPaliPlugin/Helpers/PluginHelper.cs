using AutoCount.Data;
using AutoCount.UDF;
using AutoCount;
using QYPaliPaliSDK.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliPlugin.Helpers
{
    internal class PluginHelper
    {
        #region singleton
        private static readonly Lazy<PluginHelper> lazy = new Lazy<PluginHelper>(() => new PluginHelper());
        public static PluginHelper Instance { get { return lazy.Value; } }
        private PluginHelper() { }
        #endregion

        internal void RegisterAppScript(DBSetting dbSetting)
        {
            AutoCount.Scripting.ScriptManager script = AutoCount.Scripting.ScriptManager.GetOrCreate(dbSetting);
            //script.RegisterByType("SO", typeof(SalesOrderScript));
            //script.RegisterByType("PO", typeof(PurchaseOrderScript));
        }

        internal bool RunEmbeddedDatabaseSchema(DBSetting dbSetting, string fileName)
        {
            string text = this.ReadEmbeddedDatabaseSchema(fileName);

            bool result;
            try
            {
                DBUtils dbUtils = DBUtils.Create(dbSetting);
                dbUtils.ExecuteDDLText(text);
                result = true;
            }
            catch (AppException ex)
            {
                //StandardExceptionHandler.WriteExceptionToErrorLog(ex);
                AppMessage.ShowErrorMessage(null, ex.Message);
                result = false;
            }

            return result;
        }

        internal string ReadEmbeddedDatabaseSchema(string fileName)
        {
            string result = "";
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string text = "QYPaliPaliPlugin.General.DBScripts." + fileName;

            try
            {
                Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text);

                if (manifestResourceStream == null)
                {
                    throw new AppException(string.Format("Unable to get manifest resource {0}.", text));
                }
                using (StreamReader streamReader = new StreamReader(manifestResourceStream))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                AutoCount.AppMessage.ShowMessage(ex.ToString());
            }

            return result;
        }

        internal enum UDFSystemType
        {
            Account, Area, Debtor, Creditor, Item, none
        }

        internal void RegisterUDF(DBSetting dbSetting)
        {
            try
            {
                //if (IsCreatedUDF(dbSetting, "IV", SDK_Constants.udf_iv_qydocno) == false)
                //{
                //    CreateRequiredUDF("IV", SDK_Constants.udf_iv_qydocno, "QianYi Doc No", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}

                //if (IsCreatedUDF(dbSetting, "SO", SDK_Constants.udf_so_delcountry) == false)
                //{
                //    CreateRequiredUDFList("SO", SDK_Constants.udf_so_delcountry, "Delivery Country", 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "SO", SDK_Constants.udf_so_delcprovince) == false)
                //{
                //    CreateRequiredUDF("SO", SDK_Constants.udf_so_delcprovince, "Delivery Province", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "SO", SDK_Constants.udf_so_delcity) == false)
                //{
                //    CreateRequiredUDF("SO", SDK_Constants.udf_so_delcity, "Delivery City", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "SO", SDK_Constants.udf_so_delpostcode) == false)
                //{
                //    CreateRequiredUDF("SO", SDK_Constants.udf_so_delpostcode, "Delivery PostCode", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "SO", SDK_Constants.udf_so_posteddate) == false)
                //{
                //    CreateRequiredUDF("SO", SDK_Constants.udf_so_posteddate, "QY Posted Date", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "SO", SDK_Constants.udf_so_orderno) == false)
                //{
                //    CreateRequiredUDF("SO", SDK_Constants.udf_so_orderno, "QY Order No", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "SODTL", SDK_Constants.udf_sodtl_posteddate) == false)
                //{
                //    CreateRequiredUDF("SODTL", SDK_Constants.udf_sodtl_posteddate, "QY Posted Date", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}

                //if (IsCreatedUDF(dbSetting, "PI", SDK_Constants.udf_pi_qydocno) == false)
                //{
                //    CreateRequiredUDF("PI", SDK_Constants.udf_pi_qydocno, "QianYi Doc No", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}

                //if (IsCreatedUDF(dbSetting, "PO", SDK_Constants.udf_po_posteddate) == false)
                //{
                //    CreateRequiredUDF("PO", SDK_Constants.udf_po_posteddate, "QY Posted Date", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "PO", SDK_Constants.udf_po_orderno) == false)
                //{
                //    CreateRequiredUDF("PO", SDK_Constants.udf_po_orderno, "QY Order No", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "PODTL", SDK_Constants.udf_podtl_posteddate) == false)
                //{
                //    CreateRequiredUDF("PODTL", SDK_Constants.udf_podtl_posteddate, "QY Posted Date", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}

                //if (IsCreatedUDF(dbSetting, "Debtor", SDK_Constants.udf_so_delcountry) == false)
                //{
                //    CreateRequiredUDFList("Debtor", SDK_Constants.udf_so_delcountry, "Delivery Country", 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "Debtor", SDK_Constants.udf_so_delcprovince) == false)
                //{
                //    CreateRequiredUDF("Debtor", SDK_Constants.udf_so_delcprovince, "Delivery Province", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "Debtor", SDK_Constants.udf_so_delcity) == false)
                //{
                //    CreateRequiredUDF("Debtor", SDK_Constants.udf_so_delcity, "Delivery City", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "Debtor", SDK_Constants.udf_so_delpostcode) == false)
                //{
                //    CreateRequiredUDF("Debtor", SDK_Constants.udf_so_delpostcode, "Delivery PostCode", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}

                //if (IsCreatedUDF(dbSetting, "Branch", SDK_Constants.udf_so_delcountry) == false)
                //{
                //    CreateRequiredUDFList("Branch", SDK_Constants.udf_so_delcountry, "Delivery Country", 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "Branch", SDK_Constants.udf_so_delcprovince) == false)
                //{
                //    CreateRequiredUDF("Branch", SDK_Constants.udf_so_delcprovince, "Delivery Province", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "Branch", SDK_Constants.udf_so_delcity) == false)
                //{
                //    CreateRequiredUDF("Branch", SDK_Constants.udf_so_delcity, "Delivery City", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
                //if (IsCreatedUDF(dbSetting, "Branch", SDK_Constants.udf_so_delpostcode) == false)
                //{
                //    CreateRequiredUDF("Branch", SDK_Constants.udf_so_delpostcode, "Delivery PostCode", UDFType.Text, UDFSystemType.none, 255, dbSetting);
                //}
            }
            catch (Exception ex)
            {

            }
        }

        internal bool IsValidDatabase(DBSetting dbSet, string dbTableName)
        {
            object obj = dbSet.ExecuteScalar(string.Format("select count(*) from dbo.sysobjects where name='" + dbTableName + "' "));

            return obj != null && obj != DBNull.Value && System.Convert.ToInt32(obj) > 0;
        }

        internal bool IsCreatedUDF(DBSetting dbSetting, string tableName, string requiredUDF)
        {
            bool returnVal = true;

            if (dbSetting != null)
            {
                AutoCount.UDF.UDFTable ut = new AutoCount.UDF.UDFTable(tableName, dbSetting);
                DataRow dr = ut.Table.Rows.Find(new object[] { tableName, requiredUDF });
                returnVal = (dr == null) ? false : true;
            }

            return returnVal;
        }

        internal void CreateRequiredUDF(string tableName, string requiredUDF, string UDFDisplayText, UDFType uType, UDFSystemType systemType, int size, DBSetting dbSet)
        {
            AutoCount.UDF.UDFTable ut = new AutoCount.UDF.UDFTable(tableName, dbSet);

            DataRow dr = ut.Table.Rows.Find(new object[] { tableName, requiredUDF });

            if (dr == null)
            {
                AutoCount.UDF.Field f = new AutoCount.UDF.Field();
                f.Name = requiredUDF;
                f.Caption = UDFDisplayText;
                f.Type = uType;

                if (uType == AutoCount.UDF.UDFType.Text)
                {
                    f.TextProperties.Size = size;
                    f.TextProperties.Unique = false;
                    f.TextProperties.Required = false;
                }
                else if (uType == AutoCount.UDF.UDFType.Decimal)
                {
                    f.DecimalProperties.Scale = size;
                }
                else if (uType == AutoCount.UDF.UDFType.Date)
                {
                    f.DateProperties.DateType = AutoCount.UDF.DateType.Date;
                }
                else if (uType == AutoCount.UDF.UDFType.Boolean) { }
                else if (uType == AutoCount.UDF.UDFType.System)
                {
                    f.SystemProperties.CustomDataType = systemType.ToString();
                    f.SystemProperties.ShowLabel = true;
                }
                else
                {
                    throw new Exception("The provided UDF Type is not supported in this coding.");

                }

                try
                {
                    ut.Add(f);
                    ut.Save();
                }
                catch (Exception ex)
                {
                    AutoCount.AppMessage.ShowMessage(string.Format("Error while creating new UDF '{0}'.\n\n{1}", f.Name, ex.Message));
                }
            }
        }

        private void CreateRequiredUDFList(string TableName, string RequiredUDF, string UDFCaption, int Size, AutoCount.Data.DBSetting DBSet)
        {
            //UDF Table 
            AutoCount.UDF.UDFTable ut = new AutoCount.UDF.UDFTable(TableName, DBSet);
            DataRow r = ut.Table.Rows.Find(new object[] { TableName, RequiredUDF });
            //UDF List 
            AutoCount.UDF.UDFList udfList = new AutoCount.UDF.UDFList(DBSet);
            //UDF ListItem 
            AutoCount.UDF.List list = new AutoCount.UDF.List();

            string resultList = "none";

            if (IsCreatedUDF(DBSet, TableName, RequiredUDF) == false)
            {
                string[] checkList = udfList.GetNames();
                //Check List Existing 
                for (int i = 0; i < checkList.Length; i++)
                {
                    if (checkList[i] == RequiredUDF)
                    {
                        resultList = "exist";
                    }
                }

                if (resultList == "none" && RequiredUDF != "")
                {
                    AutoCount.UDF.UDFList udfList2 = new AutoCount.UDF.UDFList(DBSet);
                    AutoCount.UDF.List list2 = new AutoCount.UDF.List();

                    list2.Name = RequiredUDF;
                    string[] item = { "MY", "CN", "SG", "TH" };
                    list2.SetItems(item);

                    udfList2.Add(list2);
                    udfList2.Save();
                }
                else
                {
                    // AutoCount.AppMessage.ShowErrorMessage("Error occured, please contact us for assistant.");
                }
                CreateRequiredUDFCountry(TableName, RequiredUDF, UDFCaption, Size, DBSet);
            }

        }

        private void CreateRequiredUDFCountry(string TableName, string RequiredUDF, string UDFCaption, int size, AutoCount.Data.DBSetting DBSet)
        {
            AutoCount.UDF.UDFTable ut = new AutoCount.UDF.UDFTable(TableName, DBSet);
            DataRow r = ut.Table.Rows.Find(new object[] { TableName, RequiredUDF });

            AutoCount.UDF.Field f = new AutoCount.UDF.Field();
            f.Name = RequiredUDF;
            f.Caption = UDFCaption;
            f.Type = AutoCount.UDF.UDFType.Text;
            f.TextProperties.Size = size;

            f.TextProperties.ListName = RequiredUDF;

            try
            {
                ut.Add(f);
                ut.Save();
            }
            catch (Exception ex)
            {
                AutoCount.AppMessage.ShowErrorMessage(string.Format("Error while creating new UDF '{0}'.\n\n{1}", f.Name, ex.Message));
            }
        }

    }
}
