using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_EncryptHelper
    {
        #region singleton
        private static readonly Lazy<SDK_EncryptHelper> lazy = new Lazy<SDK_EncryptHelper>(() => new SDK_EncryptHelper());
        public static SDK_EncryptHelper Instance { get { return lazy.Value; } }
        private SDK_EncryptHelper() { }
        #endregion

        public string Encrypt(string input)
        {
            //string key = "FLEX-software-consulting-2081-" + MasterConstants.aflex_plugin_name;
            string key = "FLEX-softwar3-consulting";
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return System.Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string input)
        {
            //string key = "FLEX-software-consulting-2081-" + MasterConstants.aflex_plugin_name;
            string key = "FLEX-softwar3-consulting";
            byte[] inputArray = System.Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
