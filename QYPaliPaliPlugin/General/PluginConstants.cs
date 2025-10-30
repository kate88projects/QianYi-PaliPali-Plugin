using AutoCount.Authentication;
using QYPaliPaliSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliPlugin.General
{
    class PluginConstants
    {
        public static string aflex_plugin_name = "QianYi";

        public static UserSession myUserSession { get; set; }
        public static SDK_ConfigModel myConfig { get; set; }
        public static string myProductId { get; set; } = "";
    }
}
