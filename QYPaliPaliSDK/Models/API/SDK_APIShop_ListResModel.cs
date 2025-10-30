using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIShop_ListResModel
    {
        public bool notSuccess { get; set; }
        public List<SDK_APIShop_InfoModel> result { get; set; }
        public string state { get; set; }
        public int total { get; set; }  
    }

    public class SDK_APIShop_InfoModel
    {
        public string name { get; set; }
        public string platform { get; set; }
        public long shopId { get; set; }
    }
}
