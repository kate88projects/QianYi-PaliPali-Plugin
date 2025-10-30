using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models
{
    public class SDK_MapperModel
    {
        public string itemCode { get; set; } = "";
        public string uom { get; set; } = "";
        public long packDocKey { get; set; } = 0;
        public string location { get; set; } = "";
        public string currency { get; set; } = "";
        public string sku { get; set; } = "";
        public List<SDK_Mapper_PackDetailModel> packDtl = new List<SDK_Mapper_PackDetailModel>();
    }
    public class SDK_Mapper_PackDetailModel
    {
        public string itemCode { get; set; } = "";
        public string uom { get; set; } = "";
        public double qty { get; set; } = 0;
        public string location { get; set; } = "";
        public double unitPrice { get; set; } = 0;
        public double acUnitPrice { get; set; } = 0;
    }
}
