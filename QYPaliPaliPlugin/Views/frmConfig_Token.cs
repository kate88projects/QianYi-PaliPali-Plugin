using AutoCount.Authentication;
using DevExpress.XtraEditors;
using QYPaliPaliSDK.Helpers;
using QYPaliPaliSDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QYPaliPaliPlugin.Views
{
    public partial class frmConfig_Token : XtraForm
    {
        private UserSession userSession;
        public frmConfig_Token(UserSession us)
        {
            InitializeComponent();
            userSession = us;
        }

        private void frmConfig_Token_Load(object sender, EventArgs e)
        {

        }

        private void btnDefDBLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnRecreate_Click(object sender, EventArgs e)
        {
            if (txtSQLDBUser.Text.Trim() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert db username.");
                return;
            }
            if (txtSQLDBPass.Text.Trim() == "")
            {
                AutoCount.AppMessage.ShowWarningMessage("Please insert db password.");
                return;
            }

            SDK_TokenModel req = new SDK_TokenModel();
            req.connstring = userSession.DBSetting.ConnectionString;
            req.server = userSession.DBSetting.ServerName;
            req.dbname = userSession.DBSetting.DBName;
            req.dbuser = txtSQLDBUser.Text.Trim();
            req.dbpass = txtSQLDBPass.Text.Trim();
            var r = SDK_TokenHelper.Instance.createupdate_TokenFile(req);
            if (!r.success)
            {
                AutoCount.AppMessage.ShowWarningMessage(r.message);
            }
            else
            {
                AutoCount.AppMessage.ShowConfirmMessage("Done Created");
                Close();
            }
        }
    }
}
