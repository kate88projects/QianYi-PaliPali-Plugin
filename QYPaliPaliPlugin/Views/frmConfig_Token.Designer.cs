
namespace QYPaliPaliPlugin.Views
{
    partial class frmConfig_Token
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
            this.btnDefDBLogin = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.txtSQLDBPass = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRecreate = new DevExpress.XtraEditors.SimpleButton();
            this.txtSQLDBUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLDBPass.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLDBUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDefDBLogin
            // 
            this.btnDefDBLogin.Location = new System.Drawing.Point(327, 14);
            this.btnDefDBLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnDefDBLogin.Name = "btnDefDBLogin";
            this.btnDefDBLogin.Size = new System.Drawing.Size(79, 13);
            this.btnDefDBLogin.TabIndex = 12;
            this.btnDefDBLogin.Text = "Default DB Login";
            this.btnDefDBLogin.Click += new System.EventHandler(this.btnDefDBLogin_Click);
            // 
            // txtSQLDBPass
            // 
            this.txtSQLDBPass.Location = new System.Drawing.Point(163, 40);
            this.txtSQLDBPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtSQLDBPass.Name = "txtSQLDBPass";
            this.txtSQLDBPass.Size = new System.Drawing.Size(158, 20);
            this.txtSQLDBPass.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRecreate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 53);
            this.panel1.TabIndex = 10;
            // 
            // btnRecreate
            // 
            this.btnRecreate.Location = new System.Drawing.Point(190, 9);
            this.btnRecreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecreate.Name = "btnRecreate";
            this.btnRecreate.Size = new System.Drawing.Size(93, 31);
            this.btnRecreate.TabIndex = 0;
            this.btnRecreate.Text = "Recreate";
            this.btnRecreate.Click += new System.EventHandler(this.btnRecreate_Click);
            // 
            // txtSQLDBUser
            // 
            this.txtSQLDBUser.Location = new System.Drawing.Point(163, 13);
            this.txtSQLDBUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtSQLDBUser.Name = "txtSQLDBUser";
            this.txtSQLDBUser.Size = new System.Drawing.Size(158, 20);
            this.txtSQLDBUser.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(42, 42);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "SQL DB Password :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(42, 16);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "SQL DB User : ";
            // 
            // frmConfig_Token
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 131);
            this.Controls.Add(this.btnDefDBLogin);
            this.Controls.Add(this.txtSQLDBPass);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSQLDBUser);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmConfig_Token";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config :: Create Token";
            this.Load += new System.EventHandler(this.frmConfig_Token_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLDBPass.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSQLDBUser.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.HyperlinkLabelControl btnDefDBLogin;
        private DevExpress.XtraEditors.TextEdit txtSQLDBPass;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnRecreate;
        private DevExpress.XtraEditors.TextEdit txtSQLDBUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}