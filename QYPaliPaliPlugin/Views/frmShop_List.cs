using AutoCount.Authentication;
using DevExpress.DataAccess.Sql;
using DevExpress.PivotGrid.Criteria.Validation;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using QYPaliPaliPlugin.Helpers;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Helpers;
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

namespace QYPaliPaliSDK.Views
{
    [AutoCount.Application.SingleInstanceThreadForm]
    [AutoCount.PlugIn.MenuItem("Shop List", 20, true, "", "", ShowAsDialog = false)]
    public partial class frmShop_List : XtraForm
    {
        private List<Dictionary<string, string>> dataOld = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> dataNew = new List<Dictionary<string, string>>();
        private UserSession userSession;
        private DataTable dt = new DataTable();

        public frmShop_List(UserSession us)
        {
            InitializeComponent();
            userSession = us;
        }

        private void loadList()
        {
            var r = ShopConfigHelper.Instance.get_ShopList("");
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

        private void frmShop_List_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmShop_Edit f = new frmShop_Edit(userSession, 0);
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

            frmShop_Edit f = new frmShop_Edit(userSession, Convert.ToInt64(dr["Id"]));
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
                var r = ShopConfigHelper.Instance.delete_shopConfig(Convert.ToInt64(dr["Id"].ToString()));
                if (r.success)
                {
                    dataOld = new List<Dictionary<string, string>>();
                    dataNew = new List<Dictionary<String, string>>();
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("shopId", dr["ShopId"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add("shopName", dr["ShopName"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add("shopPlatform", dr["ShopPlatform"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add("Description", dr["Description"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add("Debtor", dr["Debtor"].ToString());
                    dataNew.Add(data);
                    data = new Dictionary<string, string>();
                    data.Add("CompanyName", dr["CompanyName"].ToString());
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
    }
}
