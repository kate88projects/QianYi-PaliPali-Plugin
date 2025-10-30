using AutoCount.Authentication;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using QYPaliPaliPlugin.Helpers;
using QYPaliPaliSDK.General;
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
    //[AutoCount.Application.SingleInstanceThreadForm]
    //[AutoCount.PlugIn.MenuItem("Payment Method Mapping", 1, false, "", "", ShowAsDialog = false)]

    public partial class frmPaymentMethodMapping : XtraForm
    {
        private UserSession userSession;
        private DataTable dt = new DataTable();
        private DataTable dtQY = new DataTable();
        private string[] colMap = { "Tick", "Status", "QYEnum", "PaymentMethod" };
        private string[] colMapCaption = { "Select", "Status", "QY PaymentMethod", "AutoCount PaymentMethod" };
        RepositoryItemLookUpEdit repPaymentMethod = new RepositoryItemLookUpEdit();

        public frmPaymentMethodMapping(UserSession us)
        {
            InitializeComponent();
            userSession = us;
        }

        private void generateGrid()
        {
            LookupEditBuilderHelper.Instance.buildREPLUE_QYPaymentMethod(userSession, repPaymentMethod, out repPaymentMethod);
            repPaymentMethod.Appearance.BackColor = Color.Honeydew;
            EditorButton btnRepDel = new EditorButton();
            btnRepDel.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnRepDel.Visible = true;
            repPaymentMethod.Buttons.Add(btnRepDel);
            repPaymentMethod.ButtonPressed += RepPaymentMethod_ButtonPressed;

            for (int i = 0; i < colMap.Length; i++)
            {
                GridColumn gc = new GridColumn();
                gc.FieldName = colMap[i];
                gc.Caption = colMapCaption[i];
                gc.OptionsColumn.AllowEdit = (colMap[i] == "QYEnum" || colMap[i] == "Tick");
                gc.Visible = true;

                if (colMap[i] == "QYEnum")
                {
                    gc.ColumnEdit = repPaymentMethod;
                    gc.AppearanceCell.BackColor = Color.Honeydew;
                }

                gridView1.Columns.Add(gc);
            }

        }

        private void RepPaymentMethod_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                dr["QYEnum"] = "";
            }
        }

        private void frmPaymentMethodMapping_Load(object sender, EventArgs e)
        {
            generateGrid();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            btnSave.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                dt = new DataTable();

                string sql = "SELECT cast(0 as bit) AS Tick,  " +
                    "CASE WHEN p.IsActive='T' THEN cast(1 as bit) ELSE cast(0 as bit) END AS IsActive, " +
                    "p.PaymentMethod, m.PaymentMethod AS AutoKey, m.QYEnum, " +
                    "CASE WHEN m.QYEnum = '' THEN 'Not Map' ELSE 'Mapped' END AS Status " +
                    "FROM " + SDK_Constants.tbl_Flex_PaymentMap + " m " +
                    "INNER JOIN " + SDK_Constants.tbl_paymentmethod + " p on p.AutoKey=m.PaymentMethod ";
                dt = userSession.DBSetting.GetDataTable(sql, false);

                DataTable dtPM = userSession.DBSetting.GetDataTable("SELECT * FROM " + SDK_Constants.tbl_paymentmethod + " ", false);
                foreach (DataRow drPM in dtPM.Rows)
                {
                    if (dt.Select("AutoKey=" + drPM["AutoKey"]).Count() == 0)
                    {
                        DataRow drNew = dt.NewRow();
                        drNew["Tick"] = false;
                        drNew["IsActive"] = drPM["IsActive"].ToString() == "T" ? true : false;
                        drNew["PaymentMethod"] = drPM["PaymentMethod"];
                        drNew["AutoKey"] = drPM["AutoKey"];
                        drNew["QYEnum"] = "";
                        drNew["Status"] = "Not Map";
                        dt.Rows.Add(drNew);
                    }
                }

                dt.DefaultView.Sort = "PaymentMethod asc";
                dt = dt.DefaultView.ToTable();

            }
            catch (Exception ex)
            {
                AutoCount.AppMessage.ShowWarningMessage(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
            btnGenerate.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt.Select("Tick=1").Length == 0)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select at lease 1 payment method to update.");
                return;
            }

            btnGenerate.Enabled = false;
            btnSave.Enabled = false;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                long autoKey = 0;
                DataRow[] drTick = dt.Select("Tick=1");
                foreach (DataRow dr in drTick)
                {
                    long.TryParse(dr["AutoKey"] == DBNull.Value ? "0" : dr["AutoKey"].ToString(), out autoKey);
                    MappingHelper.Instance.update_PaymentMethodMap(autoKey, dr["QYEnum"].ToString());
                }
            }
            catch (Exception ex)
            {
                AutoCount.AppMessage.ShowWarningMessage(ex.Message);
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AutoCount.AppMessage.ShowMessage("Update done.");
            btnGenerate.Enabled = true;
            btnSave.Enabled = true;

            btnGenerate.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Select("Tick=1").Length > 0)
                {
                    bool confirm = AutoCount.AppMessage.ShowConfirmMessage("This form not yet save, are you sure want to close?");
                    if (confirm)
                    {
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }
            catch
            {
                Close();
            }
        }

    }
}
