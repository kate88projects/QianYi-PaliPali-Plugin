using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_APIStock_ListResModel
    {
        public bool notSuccess { get; set; }
        public List<SDK_APIStock_InfoModel> result { get; set; }
        public string state { get; set; }
        public int total { get; set; }
    }
    public class SDK_APIStock_InfoModel
    {
        public string cartonDimensionUnit { get; set; }
        public double cartonHeight { get; set; }
        public double cartonLength { get; set; }
        public double cartonNetWeight { get; set; }
        public double cartonVolume { get; set; }
        public double cartonWeight { get; set; }
        public string cartonWeightUnit { get; set; }
        public double cartonWidth { get; set; }
        public string ccPriceUnit { get; set; }
        public string customsDeclarationPriceUnit { get; set; }
        public string dangerousTransportGoodsType { get; set; }
        public string dimensionUnit { get; set; }
        public int enable { get; set; }
        public double exportTax { get; set; }
        public double height { get; set; }
        public int isDeleted { get; set; }
        public double length { get; set; }
        public bool needQualityInspection { get; set; }
        public double netWeight { get; set; }
        public double packingRate { get; set; }
        public double price { get; set; }
        public string priceUnit { get; set; }
        public string sku { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public double weight { get; set; }
        public string weightUnit { get; set; }
        public double width { get; set; }
        public List<SDK_APIStock_SingleSKUModel> singleSkuList { get; set; }
    }
    public class SDK_APIStock_SingleSKUModel
    {
        public int isDeleted { get; set; }
        public double quantity { get; set; }
        public string sku { get; set; }
        public string title { get; set; }
    }
}
