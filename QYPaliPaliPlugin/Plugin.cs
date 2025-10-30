using AutoCount.PlugIn;
using QYPaliPaliPlugin.General;
using QYPaliPaliPlugin.Helpers;
using QYPaliPaliSDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliPlugin
{
    class PluginInit : BasePlugIn
    {
        public PluginInit() : base(new Guid("6357841C-D4BE-403C-8714-FCE2A7221372"), PluginConstants.aflex_plugin_name, "1.0.0.1", "info@flexsoftware.com.my")
        {
            SetManufacturer("Flex Software Consulting Sdn Bhd");
            SetManufacturerUrl("http://www.flexsoftware.com.my");
            SetCopyright("Copyright 2016 @ Flex Software Consulting Sdn Bhd");
            SetSalesPhone("1-300-88-3539");
            SetSupportPhone("1-300-88-3539");
            SetMinimumAccountingVersionRequired("2.2.0.7");
            SetDevExpressComponentVersionRequired("22.2.7");
        }

        public override bool BeforeLoad(BeforeLoadArgs e)
        {
            e.MainMenuCaption = PluginConstants.aflex_plugin_name;

            // assign global value
            PluginConstants.myUserSession = e.UserSession;
            PluginConstants.myProductId = AutoCount.Settings.LicenseSetting.GetOrCreate(e.DBSetting).AccountingProductID;
            if (PluginConstants.myProductId == null) { PluginConstants.myProductId = ""; }

            // ready sql table and script
            bool flag = PluginHelper.Instance.RunEmbeddedDatabaseSchema(e.DBSetting, "CreateFlexDatabase.sql");
            if (flag) { }
            else { AutoCount.AppMessage.ShowMessage("Table Load Failed"); }

            // register autocount script
            PluginHelper.Instance.RegisterAppScript(e.DBSetting);

            // register autocount udf
            PluginHelper.Instance.RegisterUDF(e.DBSetting);

            //// Load System Report File
            //e.SystemReportFilename = "report.dat";

            // load setting
            PluginConstants.myConfig = SDK_ConfigHelper.Instance.loadConfig(e.DBSetting.ConnectionString);
            //PluginConstants.myConfig.s_api_url = "https://www.qianyierp.com"; // "http://gerp-test1.800best.com";
            //PluginConstants.myConfig.s_api_accesskey = "QY376068";// "16017361349"; //"openApi_TEST"; //
            //PluginConstants.myConfig.s_api_accesssecret = "b1792623719c322986f3acdc604c1e651";// "89193262951b49d1a7eef6364fb43061"; //"openApi_TOKEN"; //

            // help clear log file
            SDK_LogHelper.Instance.delete_LogDB(e.UserSession.DBSetting.ConnectionString, PluginConstants.myConfig.dayDeleteAppLog);
            SDK_LogHelper.Instance.delete_SyncLogDB(e.UserSession.DBSetting.ConnectionString, PluginConstants.myConfig.dayDeleteSyncLog);

            return base.BeforeLoad(e);
        }

        public override bool BeforeUninstall(BaseArgs e)
        {
            //var result = AutoCount.AppMessage.ShowConfirmMessage("Do you want to remove entire PalletIDWMS plugin Dependencies & Database?");

            //if (result)
            //{
            //    PluginHelper.Instance.RunEmbeddedDatabaseSchema(e.DBSetting, "DropFlexDatabase.sql");
            //}

            return base.BeforeUninstall(e);
        }

    }
}
