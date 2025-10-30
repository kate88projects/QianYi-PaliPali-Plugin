
namespace QYPaliPaliPlugin.Views
{
    partial class frmShopOffline_Edit
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lueShop = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.luePaymentMethod = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDef = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSkipPOSync = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lueShop.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePaymentMethod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(262, 80);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(288, 27);
            this.txtDescription.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(150, 83);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 19);
            this.label12.TabIndex = 44;
            this.label12.Text = "Description : ";
            // 
            // lueShop
            // 
            this.lueShop.Location = new System.Drawing.Point(262, 44);
            this.lueShop.Margin = new System.Windows.Forms.Padding(4);
            this.lueShop.Name = "lueShop";
            this.lueShop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueShop.Properties.NullText = "Please Select";
            this.lueShop.Size = new System.Drawing.Size(288, 26);
            this.lueShop.TabIndex = 43;
            this.lueShop.EditValueChanged += new System.EventHandler(this.lueShop_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 42;
            this.label1.Text = "Qian Yi Shop : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 258);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 75);
            this.panel1.TabIndex = 46;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(358, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 45);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(210, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 45);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 19);
            this.label4.TabIndex = 47;
            this.label4.Text = "Payment Method : ";
            // 
            // luePaymentMethod
            // 
            this.luePaymentMethod.Location = new System.Drawing.Point(262, 118);
            this.luePaymentMethod.Margin = new System.Windows.Forms.Padding(4);
            this.luePaymentMethod.Name = "luePaymentMethod";
            this.luePaymentMethod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePaymentMethod.Properties.NullText = "Please Select";
            this.luePaymentMethod.Size = new System.Drawing.Size(288, 26);
            this.luePaymentMethod.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "Default Shop : ";
            // 
            // chkDef
            // 
            this.chkDef.Location = new System.Drawing.Point(262, 156);
            this.chkDef.Margin = new System.Windows.Forms.Padding(4);
            this.chkDef.Name = "chkDef";
            this.chkDef.Size = new System.Drawing.Size(120, 25);
            this.chkDef.TabIndex = 50;
            this.chkDef.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "Skip PO Sync : ";
            // 
            // chkSkipPOSync
            // 
            this.chkSkipPOSync.Location = new System.Drawing.Point(262, 195);
            this.chkSkipPOSync.Margin = new System.Windows.Forms.Padding(4);
            this.chkSkipPOSync.Name = "chkSkipPOSync";
            this.chkSkipPOSync.Size = new System.Drawing.Size(95, 21);
            this.chkSkipPOSync.TabIndex = 52;
            this.chkSkipPOSync.UseVisualStyleBackColor = true;
            // 
            // frmShopOffline_Edit
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 333);
            this.Controls.Add(this.chkSkipPOSync);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkDef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.luePaymentMethod);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lueShop);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmShopOffline_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Offline :: Edit";
            this.Load += new System.EventHandler(this.frmShopOffline_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueShop.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luePaymentMethod.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.LookUpEdit lueShop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit luePaymentMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDef;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSkipPOSync;
    }
}