using AutoCount.Authentication;
using DevExpress.CodeParser;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
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
    public partial class frmShop_Edit : XtraForm
    {
        private UserSession userSession;
        private long id = 0;
        private DataRow drOld;
        private List<Dictionary<string, string>> dataOld = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> dataNew = new List<Dictionary<string, string>>();
        public bool success = false;

        private string selectedShopName;
        private string selectedShopPlatform;

        public frmShop_Edit(UserSession us, long ID)
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

            LookupEditBuilderHelper.Instance.buildSRLUE_Debtor(userSession, lueDebtor, out lueDebtor);
            LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, luePlatformRebate, out luePlatformRebate);
            LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, lueSellerDiscount, out lueSellerDiscount);
            LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, lueBuyerPaidShipFee, out lueBuyerPaidShipFee);
            LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, lueBundleVariance, out lueBundleVariance);
            //LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, lueDPlatformDiscount, out lueDPlatformDiscount);
            //LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, lueDPromotionDiscount, out lueDPromotionDiscount);
            //LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, lueDShippingPrice, out lueDShippingPrice);
            //LookupEditBuilderHelper.Instance.buildSRLUE_ItemUOM(userSession, lueDTotalDiscount, out lueDTotalDiscount);
            LookupEditBuilderHelper.Instance.buildLUE_PaymentMethod(userSession, luePaymentMethod, out luePaymentMethod);
        }

        private void loadData()
        {
            if (id == 0) { return; }

            drOld = userSession.DBSetting.GetFirstDataRow("SELECT * FROM " + SDK_Constants.tbl_Flex_ShopConfig + " WHERE Id=" + id);
            if (drOld == null)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please refresh the list.");
                Close();
                return;
            }

            Dictionary<string, string> data = new Dictionary<string, string>();

            lueShop.EditValue = drOld["ShopId"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shopId.ToString(), drOld["ShopId"].ToString());
            dataOld.Add(data);

            txtDescription.Text = drOld["Description"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shop_desc.ToString(), drOld["Description"].ToString());
            dataOld.Add(data);

            lueDebtor.EditValue = drOld["Debtor"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shop_debtor.ToString(), drOld["Debtor"].ToString());
            dataOld.Add(data);

            luePlatformRebate.EditValue = drOld["PlatformRebate"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.platformRebate.ToString(), drOld["PlatformRebate"].ToString());
            dataOld.Add(data);

            //luePlatformRebateforWook.EditValue = drOld["PlatformRebateForWook"].ToString();
            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.platformRebateForWook.ToString(), drOld["PlatformRebateForWook"].ToString());
            //dataOld.Add(data);

            lueSellerDiscount.EditValue = drOld["SellerDiscount"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.sellerDiscount.ToString(), drOld["SellerDiscount"].ToString());
            dataOld.Add(data);

            //lueSellerDiscountforWook.EditValue = drOld["SellerDiscountForWook"].ToString();
            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.sellerDicsountForWook.ToString(), drOld["SellerDiscountForWook"].ToString());
            //dataOld.Add(data);

            lueBuyerPaidShipFee.EditValue = drOld["BuyerPaidShipFee"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.buyerPaidShipFee.ToString(), drOld["BuyerPaidShipFee"].ToString());
            dataOld.Add(data);

            lueBundleVariance.EditValue = drOld["BundleVariance"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.bundleVariance.ToString(), drOld["BundleVariance"].ToString());
            dataOld.Add(data);

            //lueDPlatformDiscount.EditValue = drOld["D_PlatformDiscount"].ToString();
            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_platformDiscount.ToString(), drOld["D_PlatformDiscount"].ToString());
            //dataOld.Add(data);

            //lueDPromotionDiscount.EditValue = drOld["D_PromotionDiscount"].ToString();
            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_platformDiscount.ToString(), drOld["D_PromotionDiscount"].ToString());
            //dataOld.Add(data);

            //lueDShippingPrice.EditValue = drOld["D_Shipping"].ToString();
            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_shipping.ToString(), drOld["D_Shipping"].ToString());
            //dataOld.Add(data);

            //lueDTotalDiscount.EditValue = drOld["D_TotalDiscount"].ToString();
            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_totalDiscount.ToString(), drOld["D_TotalDiscount"].ToString());
            //dataOld.Add(data);

            chkCreateAR.Checked = Convert.ToBoolean(drOld["AutoCreateARPayment"]);
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.autoCreateARPay.ToString(), drOld["AutoCreateARPayment"].ToString());
            dataOld.Add(data);

            luePaymentMethod.EditValue = Convert.ToInt64(drOld["PaymentMethod"]) == 0 ? null : drOld["PaymentMethod"].ToString();
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.paymentMethod.ToString(), drOld["PaymentMethod"].ToString());
            dataOld.Add(data);

            //if (luePaymentMethod.EditValue != null)
            //{
            //    chkCreateAR.Checked = true;
            //}
            //else
            //{
            //    luePaymentMethod.Enabled = false;
            //}

            chkDraft.Checked = Convert.ToBoolean(drOld["ShopDraft"]);
            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shop_draft.ToString(), drOld["ShopDraft"].ToString());
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
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_ShopConfig + " WHERE ShopId = " + lueShop.EditValue + " AND id<>" + id + " ";
                DataRow  drShop = userSession.DBSetting.GetFirstDataRow(sql);

                if (drShop != null)
                {
                    AutoCount.AppMessage.ShowWarningMessage("This shop has already been added. Please edit the existing entry.");
                    return false;
                }
            }

            if (lueDebtor.EditValue == null)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Debtor.");
                return false;
            }
            if (lueDebtor.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Debtor.");
                return false;
            }
            if (luePlatformRebate.EditValue == null || luePlatformRebate.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Platform Rebate.");
                return false;
            }
            if (lueSellerDiscount.EditValue == null || lueSellerDiscount.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Seller Discount");
                return false;
            }
            if (lueBuyerPaidShipFee.EditValue == null || lueBuyerPaidShipFee.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Buyer Paid Ship Fee.");
            }
            if (lueBundleVariance.EditValue == null || lueBundleVariance.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Bundle Variance.");
            }
            //if (lueDPlatformDiscount.EditValue == null || lueDPlatformDiscount.EditValue.ToString() == "")
            //{
            //    AutoCount.AppMessage.ShowWarningMessage("Please select Detail - Platform Discount.");
            //    return false;
            //}
            //if (lueDPromotionDiscount.EditValue == null || lueDPromotionDiscount.EditValue.ToString() == "")
            //{
            //    AutoCount.AppMessage.ShowWarningMessage("Please select Detail - Promotion Discount.");
            //    return false;
            //}
            //if (lueDShippingPrice.EditValue == null || lueDShippingPrice.EditValue.ToString() == "")
            //{
            //    AutoCount.AppMessage.ShowWarningMessage("Please select Detail - Shipping Price.");
            //    return false;
            //}
            //if (lueDTotalDiscount.EditValue == null || lueDTotalDiscount.EditValue.ToString() == "")
            //{
            //    AutoCount.AppMessage.ShowWarningMessage("Please select Detail - Total Discount.");
            //    return false;
            //}
            //if (chkCreateAR.Checked)
            //{
            if (luePaymentMethod.EditValue == null || luePaymentMethod.EditValue.ToString() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Payment Method.");
                return false;
            }
            //}

            return true;
        }

        private void saveData()
        {
            SDK_ShopConfigModel shopConfig = new SDK_ShopConfigModel();
            shopConfig.ShopId = lueShop.EditValue.ToString();
            shopConfig.ShopName = selectedShopName;
            shopConfig.ShopPlatform = selectedShopPlatform;
            shopConfig.Description = string.IsNullOrEmpty(txtDescription.Text) ? "" : txtDescription.Text;
            shopConfig.Debtor = Convert.ToInt64(lueDebtor.EditValue);
            shopConfig.PlatformRebate = Convert.ToInt64(luePlatformRebate.EditValue);
            shopConfig.SellerDiscount = Convert.ToInt64(lueSellerDiscount.EditValue);
            shopConfig.BuyerPaidShipFee = Convert.ToInt64(lueBuyerPaidShipFee.EditValue);
            shopConfig.BundleVariance = Convert.ToInt64(lueBundleVariance.EditValue);
            //shopConfig.D_PlatformDiscount = Convert.ToInt64(lueDPlatformDiscount.EditValue);
            //shopConfig.D_PromotionDiscount = Convert.ToInt64(lueDPromotionDiscount.EditValue);
            //shopConfig.D_Shipping = Convert.ToInt64(lueDShippingPrice.EditValue);
            //shopConfig.D_TotalDiscount = Convert.ToInt64(lueDTotalDiscount.EditValue);
            shopConfig.AutoCreateARPayment = chkCreateAR.Checked;
            shopConfig.PaymentMethod = Convert.ToInt64(luePaymentMethod.EditValue);
            shopConfig.ShopDraft = chkDraft.Checked;

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shopId.ToString(), lueShop.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shop_desc.ToString(), txtDescription.Text);
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shop_debtor.ToString(), lueDebtor.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.platformRebate.ToString(), luePlatformRebate.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.sellerDiscount.ToString(), lueSellerDiscount.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.buyerPaidShipFee.ToString(), lueBuyerPaidShipFee.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.bundleVariance.ToString(), lueBundleVariance.EditValue.ToString());
            dataNew.Add(data);

            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_platformDiscount.ToString(), lueDPlatformDiscount.EditValue.ToString());
            //dataNew.Add(data);

            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_promotionDiscount.ToString(), lueDPromotionDiscount.EditValue.ToString());
            //dataNew.Add(data);

            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_shipping.ToString(), lueDShippingPrice.EditValue.ToString());
            //dataNew.Add(data);

            //data = new Dictionary<string, string>();
            //data.Add(EnumShopConfig.d_totalDiscount.ToString(), lueDTotalDiscount.EditValue.ToString());
            //dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.autoCreateARPay.ToString(), chkCreateAR.Checked.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.paymentMethod.ToString(), luePaymentMethod.EditValue == null ? "0" : luePaymentMethod.EditValue.ToString());
            dataNew.Add(data);

            data = new Dictionary<string, string>();
            data.Add(EnumShopConfig.shop_draft.ToString(), chkDraft.Checked.ToString());
            dataNew.Add(data);

            if (id > 0)
            {
                AuditHelper.Instance.save_auditlog(AutoCount.AuditTrail.EventType.Edit, "Shop", shopConfig.ShopId, dataOld, dataNew);
            }
            else
            {
                AuditHelper.Instance.save_auditlog(AutoCount.AuditTrail.EventType.New, "Shop", shopConfig.ShopId, dataOld, dataNew);
            }

            var updateResult = ShopConfigHelper.Instance.update_shopConfig(id, shopConfig);
            success = updateResult.success;
        }

        private void frmShop_Edit_Load(object sender, EventArgs e)
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

        private void chkCreateAR_CheckedChanged(object sender, EventArgs e)
        {
            //luePaymentMethod.Enabled = chkCreateAR.Checked;
            //if (chkCreateAR.Checked == false)
            //{
            //    luePaymentMethod.EditValue = null;
            //}
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
