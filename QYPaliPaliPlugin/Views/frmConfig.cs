using AutoCount.Authentication;
using DevExpress.XtraEditors;
using QYPaliPaliPlugin.General;
using QYPaliPaliPlugin.Helpers;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Helpers;
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
    [AutoCount.PlugIn.MenuItem("Configuration", 100, false, "", "", ShowAsDialog = true)]

    public partial class frmConfig : XtraForm
    {
        private List<Dictionary<string, string>> dataOld = new List<Dictionary<string, string>>();
        private List<Dictionary<string, string>> dataNew = new List<Dictionary<string, string>>();
        private UserSession userSession;
        private bool isN;

        public frmConfig(UserSession us)
        {
            InitializeComponent();
            userSession = us;
        }

        private void loadData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_Config + " ";
            DataTable dt = userSession.DBSetting.GetDataTable(sql, false);

            #region sync setting
            if (dt.Select("ConfigTitle='" + EnumConfiguration.s_isStart.ToString() + "' ").Length > 0)
            {
                bool isStart = dt.Select("ConfigTitle='" + EnumConfiguration.s_isStart.ToString() + "'")[0]["ConfigValue"].ToString() == "1" ? true : false;
                chkStart.Checked = isStart;
                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_isStart.ToString(), chkStart.ToString());
                dataOld.Add(data);
            }
            else
            {
                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_isStart.ToString(), "");
                dataOld.Add(data);
            }

            if (dt.Select("ConfigTitle='" + EnumConfiguration.s_dateStart.ToString() + "' ").Length > 0)
            {
                DateTime? datS;
                if (dt.Select("ConfigTitle='" + EnumConfiguration.s_dateStart.ToString() + "'")[0]["ConfigValue"] == DBNull.Value)
                {
                    datS = null;
                }
                else
                {
                    datS = (DateTime)Convert.ToDateTime(dt.Select("ConfigTitle='" + EnumConfiguration.s_dateStart.ToString() + "'")[0]["ConfigValue"]);
                }
                dtpDateStart.EditValue = datS;
                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_dateStart.ToString(), datS == null ? "" : ((DateTime)datS).ToString("dd-MM-yyyy"));
                dataOld.Add(data);
            }
            else
            {
                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_dateStart.ToString(), "");
                dataOld.Add(data);
            }

            string t = "";
            if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_url.ToString() + "' ").Length > 0)
            {
                if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_url.ToString() + "'")[0]["ConfigValue"] == DBNull.Value)
                {
                    t = "";
                }
                else
                {
                    t = dt.Select("ConfigTitle='" + EnumConfiguration.s_api_url.ToString() + "'")[0]["ConfigValue"].ToString();
                }
                txtAPIUrl.Text = t;
            }
            data = new Dictionary<string, string>();
            data.Add(EnumConfiguration.s_api_url.ToString(), t);
            dataOld.Add(data);
            
            t = "";
            if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_accesskey.ToString() + "' ").Length > 0)
            {
                if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_accesskey.ToString() + "'")[0]["ConfigValue"] == DBNull.Value)
                {
                    t = "";
                }
                else
                {
                    t = dt.Select("ConfigTitle='" + EnumConfiguration.s_api_accesskey.ToString() + "'")[0]["ConfigValue"].ToString();
                }
                txtAPIAccessKey.Text = t;
            }
            data = new Dictionary<string, string>();
            data.Add(EnumConfiguration.s_api_accesskey.ToString(), t);
            dataOld.Add(data);

            t = "";
            if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_accesssecret.ToString() + "' ").Length > 0)
            {
                if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_accesssecret.ToString() + "'")[0]["ConfigValue"] == DBNull.Value)
                {
                    t = "";
                }
                else
                {
                    t = dt.Select("ConfigTitle='" + EnumConfiguration.s_api_accesssecret.ToString() + "'")[0]["ConfigValue"].ToString();
                }
                string pass = t.Trim() == "" ? "" : SDK_EncryptHelper.Instance.Decrypt(t);
                txtAPIAccessSecret.Text = pass;
            }
            data = new Dictionary<string, string>();
            data.Add(EnumConfiguration.s_api_accesssecret.ToString(), t);
            dataOld.Add(data);

            t = SDK_Constants.api_pagesize.ToString();
            if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_pageSize.ToString() + "' ").Length > 0)
            {
                if (dt.Select("ConfigTitle='" + EnumConfiguration.s_api_pageSize.ToString() + "'")[0]["ConfigValue"] == DBNull.Value)
                {
                    t = SDK_Constants.api_pagesize.ToString();
                }
                else
                {
                    t = dt.Select("ConfigTitle='" + EnumConfiguration.s_api_pageSize.ToString() + "'")[0]["ConfigValue"].ToString();
                }
            }
            txtAPIPageSize.Text = t;
            data = new Dictionary<string, string>();
            data.Add(EnumConfiguration.s_api_pageSize.ToString(), t);
            dataOld.Add(data);

            #endregion

            #region log and token
            t = "";
            if (dt.Select("ConfigTitle='" + EnumConfiguration.dayDeleteAppLog.ToString() + "' ").Length > 0)
            {
                if (dt.Select("ConfigTitle='" + EnumConfiguration.dayDeleteAppLog.ToString() + "'")[0]["ConfigValue"] == DBNull.Value)
                {
                    t = "";
                }
                else
                {
                    t = dt.Select("ConfigTitle='" + EnumConfiguration.dayDeleteAppLog.ToString() + "'")[0]["ConfigValue"].ToString();
                }
                txtDelLog.EditValue = t;
            }
            data = new Dictionary<string, string>();
            data.Add(EnumConfiguration.dayDeleteAppLog.ToString(), t);
            dataOld.Add(data);

            t = "";
            if (dt.Select("ConfigTitle='" + EnumConfiguration.dayDeleteSyncLog.ToString() + "' ").Length > 0)
            {

                if (dt.Select("ConfigTitle='" + EnumConfiguration.dayDeleteSyncLog.ToString() + "'")[0]["ConfigValue"] == DBNull.Value)
                {
                    t = "";
                }
                else
                {
                    t = dt.Select("ConfigTitle='" + EnumConfiguration.dayDeleteSyncLog.ToString() + "'")[0]["ConfigValue"].ToString();
                }
                txtDelSyncLog.EditValue = t;
            }
            data = new Dictionary<string, string>();
            data.Add(EnumConfiguration.dayDeleteSyncLog.ToString(), t);
            dataOld.Add(data);
            #endregion
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnCreateToken_Click(object sender, EventArgs e)
        {
            frmConfig_Token f = new frmConfig_Token(userSession);
            f.ShowDialog();
        }

        private bool checkSaveData()
        {
            if (dtpDateStart.EditValue == null)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select Start Date.");
                return false;
            }

            if (txtAPIUrl.Text.Trim() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert API URL.");
                return false;
            }

            if (txtAPIAccessKey.Text.Trim() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert API Access Key.");
                return false;
            }

            if (txtAPIAccessSecret.Text.Trim() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert API Access Secret.");
                return false;
            }

            int t = 0;
            isN = int.TryParse(txtDelLog.Text.ToString(), out t);
            if (!isN)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert number only in Delete App Log. ");
                return false;
            }

            isN = int.TryParse(txtDelSyncLog.Text.ToString(), out t);
            if (!isN)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert number only in Delete Sync Log. ");
                return false;
            }

            isN = int.TryParse(txtAPIPageSize.Text.ToString(), out t);
            if (!isN)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert number only in API Page Size. ");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkSaveData())
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_isStart.ToString(), chkStart.Checked.ToString());
                dataNew.Add(data);

                string dS = dtpDateStart.EditValue != null ? Convert.ToDateTime(dtpDateStart.EditValue).ToString("yyyy-MM-dd") : "";
                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_dateStart.ToString(), dS);
                dataNew.Add(data);

                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_api_url.ToString(), txtAPIUrl.Text);
                dataNew.Add(data);

                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_api_accesskey.ToString(), txtAPIAccessKey.Text);
                dataNew.Add(data);

                string pass2 = txtAPIAccessSecret.Text.Trim() == "" ? "" : SDK_EncryptHelper.Instance.Encrypt(txtAPIAccessSecret.Text.Trim());
                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_api_accesssecret.ToString(), pass2);
                dataNew.Add(data);

                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.s_api_pageSize.ToString(), txtAPIPageSize.Text);
                dataNew.Add(data);

                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.dayDeleteAppLog.ToString(), txtDelLog.Text);
                dataNew.Add(data);

                data = new Dictionary<string, string>();
                data.Add(EnumConfiguration.dayDeleteSyncLog.ToString(), txtDelSyncLog.Text);
                dataNew.Add(data);

                AuditHelper.Instance.save_auditlog(AutoCount.AuditTrail.EventType.Edit, "Configuration", "", dataOld, dataNew);

                var r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.s_isStart, chkStart.Checked ? "1" : "0", false);
                r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.s_dateStart, dS, dS == "");
                r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.s_api_url, txtAPIUrl.Text, false); 
                r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.s_api_accesskey, txtAPIAccessKey.Text, false);
                r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.s_api_accesssecret, pass2, false);
                r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.s_api_pageSize, txtAPIPageSize.Text, false);
                r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.dayDeleteAppLog, txtDelLog.Text, false);
                r = ConfigHelper.Instance.update_Config(userSession, EnumConfiguration.dayDeleteSyncLog, txtDelSyncLog.Text, false);

                PluginConstants.myConfig = SDK_ConfigHelper.Instance.loadConfig(userSession.DBSetting.ConnectionString);

                AutoCount.AppMessage.ShowInformationMessage("Update Done.");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
