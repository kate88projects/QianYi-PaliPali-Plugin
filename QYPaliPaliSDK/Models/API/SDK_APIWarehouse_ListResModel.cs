using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIWarehouse_ListResModel
    {
        public bool notSuccess { get; set; }
        public List<SDK_APIWarehouse_InfoModel> result { get; set; }
        public string state { get; set; }
        public int total { get; set; }
    }
    public class SDK_APIWarehouse_InfoModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
        public string providerName { get; set; }
        public string code { get; set; }
        public string codeName { get; set; }
        public string country { get; set; }
        public string timezoneId { get; set; }
    }
}
