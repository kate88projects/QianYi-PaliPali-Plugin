using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Helpers
{

    class SDK_APISignHelper
    {
        #region singleton
        private static readonly Lazy<SDK_APISignHelper> lazy = new Lazy<SDK_APISignHelper>(() => new SDK_APISignHelper());
        public static SDK_APISignHelper Instance { get { return lazy.Value; } }
        private SDK_APISignHelper() { }
        #endregion

        public static string EQUAL_SIGN = "=";
        public static string APP_ID = "appId";
        public static string SERVICE_TYPE = "serviceType";
        public static string BIZ_PARAM = "bizParam";
        public static string TIMESTAMP = "timestamp";

        public string calcSign(string appId, string bizParam, string serviceType, long timestamp, string secret)
        { 
            string r = GetMd5HashAsHex(buildSignStr(appId, bizParam, serviceType, timestamp, secret));
            return r;
        }

        private string GetMd5HashAsHex(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private string buildSignStr(string appId, string bizParam, string serviceType, long timestamp, string secret)
        {
            string checkStr = "";
            checkStr = APP_ID + EQUAL_SIGN + appId + BIZ_PARAM + EQUAL_SIGN + bizParam + SERVICE_TYPE + EQUAL_SIGN + serviceType +
                    TIMESTAMP + EQUAL_SIGN + timestamp + secret;
            return checkStr;
        }
    }
}
