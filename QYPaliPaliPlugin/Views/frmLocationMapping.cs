using AutoCount.Authentication;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Newtonsoft.Json;
using QYPaliPaliPlugin.General;
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

namespace QYPaliPaliPlugin.Views
{
    [AutoCount.Application.SingleInstanceThreadForm]
    [AutoCount.PlugIn.MenuItem("Location Mapping", 1, false, "", "", ShowAsDialog = false)]

    public partial class frmLocationMapping : XtraForm
    {
        private UserSession userSession;
        private DataTable dt = new DataTable();
        private DataTable dtQY = new DataTable();
        private string[] colMap = { "Tick", "Status", "Location", "QYId", "QYName" };
        private string[] colMapCaption = { "Select", "Status", "AutoCount Location", "QY Id", "QY Location" };
        RepositoryItemLookUpEdit repLoc = new RepositoryItemLookUpEdit();

        public frmLocationMapping(UserSession us)
        {
            InitializeComponent();
            userSession = us;
        }

        private void generateGrid()
        {
            LookupEditBuilderHelper.Instance.buildREPLUE_Location(userSession, repLoc, out repLoc);
            repLoc.Appearance.BackColor = Color.Honeydew;
            EditorButton btnRepDel = new EditorButton();
            btnRepDel.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnRepDel.Visible = true;
            repLoc.Buttons.Add(btnRepDel);
            repLoc.ButtonPressed += RepLoc_ButtonPressed;

            for (int i = 0; i < colMap.Length; i++)
            {
                GridColumn gc = new GridColumn();
                gc.FieldName = colMap[i];
                gc.Caption = colMapCaption[i];
                gc.OptionsColumn.AllowEdit = (colMap[i] == "Location" || colMap[i] == "Tick");
                gc.Visible = true;

                if (colMap[i] == "Location")
                {
                    gc.ColumnEdit = repLoc;
                    gc.AppearanceCell.BackColor = Color.Honeydew;
                }

                gridView1.Columns.Add(gc);
            }

        }

        private void RepLoc_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                dr["Location"] = 0;
            }
        }

        private void frmLocationMapping_Load(object sender, EventArgs e)
        {
            generateGrid();
            gridView2.OptionsBehavior.Editable = false;
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
                dtQY = new DataTable();

                string sql = "SELECT cast(0 as bit) AS Tick, l.Description, l.Desc2, CASE WHEN l.IsActive='T' THEN cast(1 as bit) ELSE cast(0 as bit) END AS IsActive, " +
                    "m.Location, m.QYId, m.QYName, 'Mapped' AS Status " +
                    "FROM " + SDK_Constants.tbl_Flex_LocMap + " m " +
                    "INNER JOIN " + SDK_Constants.tbl_location + " l on l.AutoKey=m.Location ";
                dt = userSession.DBSetting.GetDataTable(sql, false);

                int currentPage = 1;
                int totalPage = 1;
                SDK_APIWarehouse_ListReqModel req = new SDK_APIWarehouse_ListReqModel();

                while (currentPage <= totalPage)
                {
                    req = new SDK_APIWarehouse_ListReqModel();
                    req.page = currentPage;
                    req.pageSize = SDK_Constants.api_pagesize;
                    var r = SDK_APIHelper.Instance.post_getWarehouse(PluginConstants.myConfig.s_api_url, PluginConstants.myConfig.s_api_accesskey, PluginConstants.myConfig.s_api_accesssecret, req).GetAwaiter().GetResult();
                    if (r.success)
                    {
                        SDK_APIWarehouse_ListResModel res = JsonConvert.DeserializeObject<SDK_APIWarehouse_ListResModel>(r.message);
                        foreach (var p in res.result)
                        {
                            DataRow dr = dt.Select("QYId='" + p.id + "'  ").FirstOrDefault();
                            if (dr != null)
                            {
                                dr["QYName"] = p.name;
                            }
                            else
                            {
                                DataRow drNew = dt.NewRow();
                                drNew["Tick"] = false;
                                drNew["Location"] = 0;
                                drNew["Description"] = "";
                                drNew["Desc2"] = "";
                                drNew["IsActive"] = false;
                                drNew["QYId"] = p.id;
                                drNew["QYName"] = p.name;
                                drNew["Status"] = "Not Map";
                                dt.Rows.Add(drNew);
                            }
                        }

                        string j = JsonConvert.SerializeObject(res.result);
                        dtQY.Merge(JsonConvert.DeserializeObject<DataTable>(j));

                        if (currentPage == 1)
                        {
                            if (res.total <= SDK_Constants.api_pagesize)
                            {
                                totalPage = 1;
                            }
                            else
                            {
                                totalPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(res.total) / SDK_Constants.api_pagesize));
                            }
                        }
                    }
                    currentPage = currentPage + 1;
                }

                dt.DefaultView.Sort = "QYName asc";
                dt = dt.DefaultView.ToTable();

                dtQY.DefaultView.Sort = "name asc";
                dtQY = dtQY.DefaultView.ToTable();

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
            gridControl2.DataSource = dtQY;
            btnGenerate.Enabled = true;
            btnSave.Enabled = true;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                if (e.CellValue.ToString() == "Mapped")
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt.Select("Tick=1").Length == 0)
            {
                AutoCount.AppMessage.ShowWarningMessage("Please select at lease 1 order to update.");
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
                    long.TryParse(dr["Location"] == DBNull.Value ? "0" : dr["Location"].ToString(), out autoKey);
                    MappingHelper.Instance.update_LocationMap(autoKey, dr["QYId"].ToString(), dr["QYName"].ToString());
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
