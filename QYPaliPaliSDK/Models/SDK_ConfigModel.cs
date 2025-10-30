using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models
{
    public class SDK_ConfigModel
    {
        public bool s_isStart { get; set; } = false;
        public DateTime? s_dateStart { get; set; }
        public DateTime? s_lastSyncDate { get; set; }
        public DateTime? s_restartSyncDate { get; set; }

        public string s_api_url { get; set; } = "";
        public string s_api_accesskey { get; set; } = "";
        public string s_api_accesssecret { get; set; } = "";
        public int s_api_pageSize { get; set; } = 100;

        public int dayDeleteAppLog { get; set; } = 15;
        public int dayDeleteSyncLog { get; set; } = 5;

    }
}
