using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIWarehouse_ListReqModel
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 200;
    }
}
