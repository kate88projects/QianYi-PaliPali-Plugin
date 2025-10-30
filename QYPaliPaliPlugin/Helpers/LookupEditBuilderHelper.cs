using AutoCount.Authentication;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using QYPaliPaliSDK.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliPlugin.Helpers
{
    class LookupEditBuilderHelper
    {
        #region singleton
        private static readonly Lazy<LookupEditBuilderHelper> lazy = new Lazy<LookupEditBuilderHelper>(() => new LookupEditBuilderHelper());
        public static LookupEditBuilderHelper Instance { get { return lazy.Value; } }
        private LookupEditBuilderHelper() { }
        #endregion

        public void buildSRLUE_Debtor(UserSession userSession, SearchLookUpEdit lue, out SearchLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT AccNo, CompanyName, AutoKey FROM " + SDK_Constants.tbl_debtor + " WHERE IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.Properties.DataSource = dtCombo;
                lue.Properties.ValueMember = "AutoKey";
                lue.Properties.DisplayMember = "AccNo";

                if (lue.Properties.View.Columns.Count == 0)
                {
                    GridColumn column = lue.Properties.View.Columns.AddField("AccNo");
                    column.Visible = true;
                    column = lue.Properties.View.Columns.AddField("CompanyName");
                    column.Visible = true;
                }

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildLUE_Location(UserSession userSession, LookUpEdit lue, out LookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT Location, AutoKey FROM " + SDK_Constants.tbl_location + " WHERE IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.Properties.DataSource = dtCombo;
                lue.Properties.ValueMember = "AutoKey";
                lue.Properties.DisplayMember = "Location";
                lue.Properties.Columns.Add(new LookUpColumnInfo("Location", "Location"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildREPLUE_Location(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT Location, AutoKey FROM " + SDK_Constants.tbl_location + " WHERE IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.DataSource = dtCombo;
                lue.ValueMember = "AutoKey";
                lue.DisplayMember = "Location";
                lue.Columns.Add(new LookUpColumnInfo("Location", "Location"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildSRLUE_ItemUOM(UserSession userSession, SearchLookUpEdit lue, out SearchLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT 'False' AS SelectItem, i.ItemCode, u.UOM, u.AutoKey, CONCAT(i.ItemCode, '-', u.UOM) AS Display, " +
                "i.Description, i.Desc2, i.FurtherDescription, i.ItemGroup, i.ItemType, i.IsActive, i.StockControl " +
                "FROM " + SDK_Constants.tbl_item + " i " +
                "INNER JOIN " + SDK_Constants.tbl_itemuom + " u ON i.ItemCode=u.ItemCode " +
                "WHERE i.ItemCode IS NOT NULL AND i.IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.Properties.DataSource = dtCombo;
                lue.Properties.ValueMember = "AutoKey";
                lue.Properties.DisplayMember = "Display";

                if (lue.Properties.View.Columns.Count == 0)
                {
                    GridColumn column = lue.Properties.View.Columns.AddField("ItemCode");
                    column.Visible = true;
                    column = lue.Properties.View.Columns.AddField("UOM");
                    column.Visible = true;
                    column = lue.Properties.View.Columns.AddField("Description");
                    column.Visible = true;
                }

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildREPSRLUE_ItemUOM(UserSession userSession, RepositoryItemSearchLookUpEdit lue, out RepositoryItemSearchLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT 'False' AS SelectItem, i.ItemCode, u.UOM, u.AutoKey, CONCAT(i.ItemCode, '-', u.UOM) AS Display, " +
                "i.Description, i.Desc2, i.FurtherDescription, i.ItemGroup, i.ItemType, i.IsActive, i.StockControl " +
                "FROM " + SDK_Constants.tbl_item + " i " +
                "INNER JOIN " + SDK_Constants.tbl_itemuom + " u ON i.ItemCode=u.ItemCode " +
                "WHERE i.ItemCode IS NOT NULL AND i.IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.DataSource = dtCombo;
                lue.ValueMember = "AutoKey";
                lue.DisplayMember = "Display";

                if (lue.View.Columns.Count == 0)
                {
                    GridColumn column = lue.View.Columns.AddField("ItemCode");
                    column.Visible = true;
                    column = lue.View.Columns.AddField("UOM");
                    column.Visible = true;
                    column = lue.View.Columns.AddField("Description");
                    column.Visible = true;
                }

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildREPLUE_Package(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT PackageCode, Description, DocKey FROM " + SDK_Constants.tbl_pack + " WHERE IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.DataSource = dtCombo;
                lue.ValueMember = "DocKey";
                lue.DisplayMember = "PackageCode";
                lue.Columns.Add(new LookUpColumnInfo("PackageCode", "Package Code"));
                lue.Columns.Add(new LookUpColumnInfo("Description", "Package Desc"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildLUE_PaymentMethod(UserSession userSession, LookUpEdit lue, out LookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT PaymentMethod, AutoKey FROM " + SDK_Constants.tbl_paymentmethod + " WHERE IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.Properties.DataSource = dtCombo;
                lue.Properties.ValueMember = "AutoKey";
                lue.Properties.DisplayMember = "PaymentMethod";
                lue.Properties.Columns.Add(new LookUpColumnInfo("PaymentMethod", "PaymentMethod"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildREPLUE_PaymentMethod(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT PaymentMethod, AutoKey FROM " + SDK_Constants.tbl_paymentmethod + " WHERE IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.DataSource = dtCombo;
                lue.ValueMember = "AutoKey";
                lue.DisplayMember = "PaymentMethod";
                lue.Columns.Add(new LookUpColumnInfo("PaymentMethod", "PaymentMethod"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildREPLUE_QYPaymentMethod(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                DataTable dtCombo = new DataTable();
                dtCombo.Columns.Add("QYEnum");
                foreach (var name in Enum.GetNames(typeof(SDK_Enums_QianYi.EnumQY_SOPaymentMethod)))
                {
                    DataRow dr = dtCombo.NewRow();
                    dr[0] = name;
                    dtCombo.Rows.Add(dr);
                }

                lue.DataSource = dtCombo;
                lue.ValueMember = "QYEnum";
                lue.DisplayMember = "QYEnum";

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildLUE_QYPaymentMethod(UserSession userSession, LookUpEdit lue, out LookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                DataTable dtCombo = new DataTable();
                dtCombo.Columns.Add("QYEnum");
                foreach (var name in Enum.GetNames(typeof(SDK_Enums_QianYi.EnumQY_SOPaymentMethod)))
                {
                    DataRow dr = dtCombo.NewRow();
                    dr[0] = name;
                    dtCombo.Rows.Add(dr);
                }

                lue.Properties.DataSource = dtCombo;
                lue.Properties.ValueMember = "QYEnum";
                lue.Properties.DisplayMember = "QYEnum";

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildREPLUE_QYCurrency(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                DataTable dtCombo = new DataTable();
                dtCombo.Columns.Add("QYEnum");
                foreach (var name in Enum.GetNames(typeof(SDK_Enums_QianYi.EnumQY_Currency)))
                {
                    DataRow dr = dtCombo.NewRow();
                    dr[0] = name;
                    dtCombo.Rows.Add(dr);
                }

                lue.DataSource = dtCombo;
                lue.ValueMember = "QYEnum";
                lue.DisplayMember = "QYEnum";

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildREPLUE_Creditor(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT AutoKey, AccNo, CompanyName FROM " + SDK_Constants.tbl_creditor + " WHERE IsActive='T' ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.DataSource = dtCombo;
                lue.ValueMember = "AutoKey";
                lue.DisplayMember = "AccNo";
                lue.Columns.Add(new LookUpColumnInfo("AccNo", "AccNo"));
                lue.Columns.Add(new LookUpColumnInfo("CompanyName", "CompanyName"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildLUE_ShopOffline(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT ShopId, ShopName, DefaultShop FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + "  ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.DataSource = dtCombo;
                lue.ValueMember = "ShopName";
                lue.DisplayMember = "ShopName";
                lue.Columns.Add(new LookUpColumnInfo("ShopId", "Shop Id"));
                lue.Columns.Add(new LookUpColumnInfo("ShopName", "Shop Name"));
                lue.Columns.Add(new LookUpColumnInfo("DefaultShop", "Default"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

        public void buildLUE_QYWarehouse(UserSession userSession, RepositoryItemLookUpEdit lue, out RepositoryItemLookUpEdit lueR)
        {
            lueR = lue;
            try
            {
                string sql = "SELECT m.*, l.Location AS LocationCode " +
                    "FROM " + SDK_Constants.tbl_Flex_LocMap + " m " +
                    "INNER JOIN " + SDK_Constants.tbl_location + " l ON m.Location=l.AutoKey   ";
                DataTable dtCombo = userSession.DBSetting.GetDataTable(sql, false);
                lue.DataSource = dtCombo;
                lue.ValueMember = "QYName";
                lue.DisplayMember = "QYName";
                lue.Columns.Add(new LookUpColumnInfo("QYName", "Warehouse Name"));
                lue.Columns.Add(new LookUpColumnInfo("LocationCode", "AC Location"));

                lueR = lue;
            }
            catch (Exception ex)
            {

            }
        }

    }
}
