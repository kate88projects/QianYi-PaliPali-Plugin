using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIStock_ListReqModel
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 200;
        public List<string> skus { get; set; } = new List<string>();
    }
}
