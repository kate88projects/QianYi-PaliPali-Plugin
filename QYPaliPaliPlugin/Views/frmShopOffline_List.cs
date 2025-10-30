using AutoCount.Authentication;
using DevExpress.XtraEditors;
using QYPaliPaliPlugin.Helpers;
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
    [AutoCount.Application.SingleInstanceThreadForm]
    [AutoCount.PlugIn.MenuItem("Shop Offline List", 21, false, "", "", ShowAsDialog = false)]

    public partial class frmShopOffline_List : XtraForm
    {
        private List<Dictionary<string, string>> dataOld = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> dataNew = new List<Dictionary<string, string>>();
        private UserSession userSession;
        private DataTable dt = new DataTable();

        public frmShopOffline_List(UserSession us)
        {
            InitializeComponent();
            userSession = us;
        }

        private void loadList()
        {
            var r = ShopOfflineConfigHelper.Instance.get_ShopList("");
            if (r.success)
            {
                dt = r.dt1;
                gridControl1.DataSource = dt;
            }
            else
            {
                AutoCount.AppMessage.ShowMessage(r.message);
            }
        }

        private void frmShopOffline_List_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmShopOffline_Edit f = new frmShopOffline_Edit(userSession, 0);
            f.ShowDialog();
            if (f.success)
            {
                loadList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) { return; }
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
            {
                return;
            }

            frmShopOffline_Edit f = new frmShopOffline_Edit(userSession, Convert.ToInt64(dr["Id"]));
            f.ShowDialog();
            if (f.success)
            {
                loadList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0) { return; }
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select one record to delete.");
                return;
            }

            bool confirm = AutoCount.AppMessage.ShowConfirmMessage("Are you sure want to delete this shop config?");
            if (confirm)
            {
                var r = ShopOfflineConfigHelper.Instance.delete_shopConfig(Convert.ToInt64(dr["Id"].ToString()));
                if (r.success)
                {
                    dataOld = new List<Dictionary<string, string>>();
                    dataNew = new List<Dictionary<String, string>>();
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(EnumShopOfflineConfig.shopId.ToString(), dr["ShopId"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add("shopName", dr["ShopName"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add("shopPlatform", dr["ShopPlatform"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add(EnumShopOfflineConfig.shop_desc.ToString(), dr["Description"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add(EnumShopOfflineConfig.paymentMethod.ToString(), dr["QYPMEnum"].ToString());
                    dataNew.Add(data);

                    AuditHelper.Instance.save_auditlog(AutoCount.AuditTrail.EventType.Delete, "Shop", dr["shopId"].ToString(), dataOld, dataNew);
                    AutoCount.AppMessage.ShowMessage("Done delete.");
                    loadList();
                }
                else
                {
                    AutoCount.AppMessage.ShowWarningMessage(r.message);
                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadList();
        }
    }
}
