using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models
{
    public class SDK_ShopOfflineConfigModel
    {
        public bool success { get; set; } = false;
        public string message { get; set; } = "";
        public string ShopId { get; set; } = "";
        public string ShopName { get; set; } = "";
        public string ShopPlatform { get; set; } = "";
        public string Description { get; set; } = "";

        public string QYPMEnum { get; set; } = "";
        public bool DefaultShop { get; set; } = false;
        public bool SkipPOSync { get; set; } = false;

    }
}
