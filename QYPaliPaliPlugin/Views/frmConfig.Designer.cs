
namespace QYPaliPaliPlugin.Views
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtAPIAccessSecret = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDateStart = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtAPIAccessKey = new DevExpress.XtraEditors.TextEdit();
            this.txtAPIUrl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.btnCreateToken = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.txtDelSyncLog = new DevExpress.XtraEditors.TextEdit();
            this.txtDelLog = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtAPIPageSize = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIAccessSecret.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIAccessKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelSyncLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIPageSize.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 51);
            this.panel1.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(207, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 31);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(108, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 31);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAPIAccessSecret
            // 
            this.txtAPIAccessSecret.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAPIAccessSecret.EditValue = "";
            this.txtAPIAccessSecret.Location = new System.Drawing.Point(168, 131);
            this.txtAPIAccessSecret.Name = "txtAPIAccessSecret";
            this.txtAPIAccessSecret.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIAccessSecret.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIAccessSecret.Properties.PasswordChar = '*';
            this.txtAPIAccessSecret.Size = new System.Drawing.Size(177, 20);
            this.txtAPIAccessSecret.TabIndex = 58;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl4.Location = new System.Drawing.Point(48, 134);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(97, 13);
            this.labelControl4.TabIndex = 57;
            this.labelControl4.Text = "API Access Secret : ";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDateStart.EditValue = null;
            this.dtpDateStart.Location = new System.Drawing.Point(168, 53);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateStart.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateStart.Size = new System.Drawing.Size(95, 20);
            this.dtpDateStart.TabIndex = 56;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl5.Location = new System.Drawing.Point(48, 56);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 55;
            this.labelControl5.Text = "Date Start : ";
            // 
            // txtAPIAccessKey
            // 
            this.txtAPIAccessKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAPIAccessKey.EditValue = "";
            this.txtAPIAccessKey.Location = new System.Drawing.Point(168, 105);
            this.txtAPIAccessKey.Name = "txtAPIAccessKey";
            this.txtAPIAccessKey.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIAccessKey.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIAccessKey.Size = new System.Drawing.Size(177, 20);
            this.txtAPIAccessKey.TabIndex = 54;
            // 
            // txtAPIUrl
            // 
            this.txtAPIUrl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAPIUrl.EditValue = "";
            this.txtAPIUrl.Location = new System.Drawing.Point(168, 79);
            this.txtAPIUrl.Name = "txtAPIUrl";
            this.txtAPIUrl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIUrl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIUrl.Size = new System.Drawing.Size(177, 20);
            this.txtAPIUrl.TabIndex = 52;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Location = new System.Drawing.Point(48, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 13);
            this.labelControl2.TabIndex = 53;
            this.labelControl2.Text = "API Access Key : ";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl3.Location = new System.Drawing.Point(48, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 51;
            this.labelControl3.Text = "API URL : ";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Location = new System.Drawing.Point(48, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Start sync : ";
            // 
            // chkStart
            // 
            this.chkStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkStart.Location = new System.Drawing.Point(168, 30);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(80, 17);
            this.chkStart.TabIndex = 0;
            this.chkStart.UseVisualStyleBackColor = true;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(403, 278);
            this.xtraTabControl1.TabIndex = 18;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage5});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl6);
            this.xtraTabPage1.Controls.Add(this.txtAPIPageSize);
            this.xtraTabPage1.Controls.Add(this.txtAPIAccessSecret);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.chkStart);
            this.xtraTabPage1.Controls.Add(this.dtpDateStart);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.txtAPIAccessKey);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.txtAPIUrl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(401, 253);
            this.xtraTabPage1.Text = "Sync Setting";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.btnCreateToken);
            this.xtraTabPage5.Controls.Add(this.txtDelSyncLog);
            this.xtraTabPage5.Controls.Add(this.txtDelLog);
            this.xtraTabPage5.Controls.Add(this.labelControl11);
            this.xtraTabPage5.Controls.Add(this.labelControl10);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(401, 253);
            this.xtraTabPage5.Text = "Log and Token";
            // 
            // btnCreateToken
            // 
            this.btnCreateToken.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateToken.Location = new System.Drawing.Point(171, 82);
            this.btnCreateToken.Name = "btnCreateToken";
            this.btnCreateToken.Size = new System.Drawing.Size(95, 13);
            this.btnCreateToken.TabIndex = 55;
            this.btnCreateToken.Text = "Recreate Token File";
            // 
            // txtDelSyncLog
            // 
            this.txtDelSyncLog.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDelSyncLog.EditValue = "15";
            this.txtDelSyncLog.Location = new System.Drawing.Point(171, 56);
            this.txtDelSyncLog.Name = "txtDelSyncLog";
            this.txtDelSyncLog.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDelSyncLog.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDelSyncLog.Size = new System.Drawing.Size(95, 20);
            this.txtDelSyncLog.TabIndex = 54;
            // 
            // txtDelLog
            // 
            this.txtDelLog.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDelLog.EditValue = "15";
            this.txtDelLog.Location = new System.Drawing.Point(171, 30);
            this.txtDelLog.Name = "txtDelLog";
            this.txtDelLog.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDelLog.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDelLog.Size = new System.Drawing.Size(95, 20);
            this.txtDelLog.TabIndex = 52;
            // 
            // labelControl11
            // 
            this.labelControl11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl11.Location = new System.Drawing.Point(51, 59);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(114, 13);
            this.labelControl11.TabIndex = 53;
            this.labelControl11.Text = "Delete Sync Log after : ";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl10.Location = new System.Drawing.Point(51, 33);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(88, 13);
            this.labelControl10.TabIndex = 51;
            this.labelControl10.Text = "Delete Log after : ";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl6.Location = new System.Drawing.Point(48, 160);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(76, 13);
            this.labelControl6.TabIndex = 59;
            this.labelControl6.Text = "API Page Size : ";
            // 
            // txtAPIPageSize
            // 
            this.txtAPIPageSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAPIPageSize.EditValue = "";
            this.txtAPIPageSize.Location = new System.Drawing.Point(168, 157);
            this.txtAPIPageSize.Name = "txtAPIPageSize";
            this.txtAPIPageSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIPageSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtAPIPageSize.Size = new System.Drawing.Size(95, 20);
            this.txtAPIPageSize.TabIndex = 60;
            // 
            // frmConfig
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 329);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIAccessSecret.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIAccessKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage5.ResumeLayout(false);
            this.xtraTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelSyncLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAPIPageSize.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.CheckBox chkStart;
        private DevExpress.XtraEditors.TextEdit txtAPIAccessKey;
        private DevExpress.XtraEditors.TextEdit txtAPIUrl;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtpDateStart;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtAPIAccessSecret;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraEditors.HyperlinkLabelControl btnCreateToken;
        private DevExpress.XtraEditors.TextEdit txtDelSyncLog;
        private DevExpress.XtraEditors.TextEdit txtDelLog;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtAPIPageSize;
    }
}