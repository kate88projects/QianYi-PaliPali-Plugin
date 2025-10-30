using AutoCount.Authentication;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;
using QYPaliPaliPlugin.General;
using QYPaliPaliPlugin.Helpers;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Helpers;
using QYPaliPaliSDK.Models;
using QYPaliPaliSDK.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QYPaliPaliSDK.General.SDK_Enums;

namespace QYPaliPaliPlugin.Views
{
    public partial class frmShopOffline_Edit : XtraForm
    {
        private UserSession userSession;
        private long id = 0;
        private DataRow drOld;
        private List<Dictionary<string, string>> dataOld = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> dataNew = new List<Dictionary<string, string>>();
        public bool success = false;

        private string selectedShopName;
        private string selectedShopPlatform;

        public frmShopOffline_Edit(UserSession us, long ID)
        {
            InitializeComponent();
            userSession = us;
            id = ID;
        }

        private void loadCombo()
        {
            var r = SDK_APIHelper.Instance.post_getShop(PluginConstants.myConfig.s_api_url, PluginConstants.myConfig.s_api_accesskey, PluginConstants.myConfig.s_api_accesssecret).GetAwaiter().GetResult();
            if (r.success)
            {
                SDK_APIShop_ListResModel res = JsonConvert.DeserializeObject<SDK_APIShop_ListResModel>(r.message);
                string shop = JsonConvert.SerializeObject(res.result);
                DataTable dtCombo = JsonConvert.DeserializeObject<DataTable>(shop);
                lueShop.Properties.DataSource = dtCombo;
                lueShop.Properties.ValueMember = "shopId";
                lueShop.Properties.DisplayMember = "name";
                lueShop.Properties.Columns.Add(new LookUpColumnInfo("shopId", "shopId"));
                lueShop.Properties.Columns.Add(new LookUpColumnInfo("name", "name"));
                lueShop.Properties.Columns.Add(new LookUpColumnInfo("platform", "platform"));
                lueShop.Properties.Columns.Add(new LookUpColumnInfo("status", "status"));
            }

            LookupEditBuilderHelper.Instance.buildLUE_QYPaymentMethod(userSession, luePaymentMethod, out luePaymentMethod);
        }

        private void loadData()
        {
            if (id == 0) { return; }

            drOld = userSession.DBSetting.GetFirstDataRow("SELECT * FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " WHERE Id=" + id);
            if (drOld == null)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please refresh the list.");
                Close();
                return;
            }

            Dictionary<string, string> data = new Dictionary<string, string>();

            lueShop.EditValue = drOld["ShopId"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.shopId.ToString(), drOld["ShopId"].ToString());
            dataOld.Add(data);

            txtDescription.Text = drOld["Description"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.shop_desc.ToString(), drOld["Description"].ToString());
            dataOld.Add(data);

            luePaymentMethod.EditValue = drOld["QYPMEnum"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.paymentMethod.ToString(), drOld["QYPMEnum"].ToString());
            dataOld.Add(data);

            chkDef.Checked = drOld["DefaultShop"].ToString() == "True";
            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.defaultShop.ToString(), drOld["DefaultShop"].ToString());
            dataOld.Add(data);

            chkSkipPOSync.Checked = drOld["SkipPOSync"].ToString() == "True";
            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.skipPOSync.ToString(), drOld["SkipPOSync"].ToString());
            dataOld.Add(data);
        }

        private bool checkSaveData()
        {
            if (lueShop.EditValue == null || lueShop.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Shop.");
                return false;
            }
            else
            {
                //check duplicate shopId
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " WHERE ShopId = " + lueShop.EditValue + " AND id<>" + id + " ";
                DataRow drShop = userSession.DBSetting.GetFirstDataRow(sql);

                if (drShop != null)
                {
                    AutoCount.AppMessage.ShowWarningMessage("This shop has already been added. Please edit the existing entry.");
                    return false;
                }
            }

            if (luePaymentMethod.EditValue == null || luePaymentMethod.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Payment Method.");
                return false;
            }

            if (chkDef.Checked)
            {
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_ShopOfflineConfig + " WHERE DefaultShop=1 AND id<>" + id + " ";
                DataRow drShop = userSession.DBSetting.GetFirstDataRow(sql);

                if (drShop != null)
                {
                    bool confirm = AutoCount.AppMessage.ShowConfirmMessage("Default shop have set in [" + drShop["ShopId"] + "], are you sure want set this shop as default?");
                    if (confirm  == false)
                        return false;
                }

            }

            return true;
        }

        private void saveData()
        {
            SDK_ShopOfflineConfigModel shopConfig = new SDK_ShopOfflineConfigModel();
            shopConfig.ShopId = lueShop.EditValue.ToString();
            shopConfig.ShopName = selectedShopName;
            shopConfig.ShopPlatform = selectedShopPlatform;
            shopConfig.Description = string.IsNullOrEmpty(txtDescription.Text) ? "" : txtDescription.Text;
            shopConfig.QYPMEnum = luePaymentMethod.EditValue.ToString();
            shopConfig.DefaultShop = chkDef.Checked;
            shopConfig.SkipPOSync = chkSkipPOSync.Checked;

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.shopId.ToString(), lueShop.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.shop_desc.ToString(), txtDescription.Text);
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.paymentMethod.ToString(), luePaymentMethod.EditValue == null ? "0" : luePaymentMethod.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.defaultShop.ToString(), chkDef.Checked ? "True" : "False");
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopOfflineConfig.skipPOSync.ToString(), chkSkipPOSync.Checked ? "True" : "False");
            dataNew.Add(data);

            if (id > 0)
            {
                AuditHelper.Instance.save_auditlog(AutoCount.AuditTrail.EventType.Edit, "Shop", shopConfig.ShopId, dataOld, dataNew);
            }
            else
            {
                AuditHelper.Instance.save_auditlog(AutoCount.AuditTrail.EventType.New, "Shop", shopConfig.ShopId, dataOld, dataNew);
            }

            var updateResult = ShopOfflineConfigHelper.Instance.update_shopConfig(id, shopConfig);
            success = updateResult.success;
        }

        private void frmShopOffline_Edit_Load(object sender, EventArgs e)
        {
            loadCombo();
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkSaveData())
            {
                saveData();
                AutoCount.AppMessage.ShowMessage("Update done.");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lueShop_EditValueChanged(object sender, EventArgs e)
        {
            var selectedShop = lueShop.GetSelectedDataRow();
            if (selectedShop != null)
            {
                var dataRow = selectedShop as DataRowView;
                if (dataRow != null)
                {
                    var shop = new SDK_APIShop_InfoModel
                    {
                        name = dataRow["name"].ToString(),
                        platform = dataRow["platform"].ToString(),

                    };
                    selectedShopName = shop.name;
                    selectedShopPlatform = shop.platform;
                }

            }
        }
    }
}
