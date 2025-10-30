using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Models.API
{
    public class SDK_API_ResModel
    {
        public string state { get; set; } = "";
        public string errorCode { get; set; } = "";
        public string errorMsg { get; set; } = "";
        public string bizContent { get; set; } = "";
        public string requestId { get; set; } = "";
    }
    public class SDK_API_ResErrorInfoModel
    {
        public string errorCode { get; set; } = "";
        public string errorMsg { get; set; } = "";
        public bool notSuccess { get; set; } = true;
        public string state { get; set; } = "";
    }
    public class SDK_API_SO_ResSuccessInfoModel
    {
        public bool notSuccess { get; set; } = true;
        public SDK_APISalesOrder_InfoModel result { get; set; } = new SDK_APISalesOrder_InfoModel();
    }
    public class SDK_API_IO_ResSuccessInfoModel
    {
        public bool notSuccess { get; set; } = true;
        public SDK_APIInboundOrder_InfoModel result { get; set; } = new SDK_APIInboundOrder_InfoModel();
        public string state { get; set; } = "";
    }
}
