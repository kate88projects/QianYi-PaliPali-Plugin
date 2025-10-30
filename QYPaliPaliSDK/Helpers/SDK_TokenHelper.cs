using Newtonsoft.Json;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_TokenHelper
    {
        #region singleton
        private static readonly Lazy<SDK_TokenHelper> lazy = new Lazy<SDK_TokenHelper>(() => new SDK_TokenHelper());
        public static SDK_TokenHelper Instance { get { return lazy.Value; } }
        private SDK_TokenHelper() { }
        #endregion

        public SDK_ServiceResponseModel createupdate_TokenFile(SDK_TokenModel req)
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();
            string encrypted = "";

            if (Directory.Exists(SDK_Constants.syncservice_path))
            {
                List<SDK_TokenModel> tokens = new List<SDK_TokenModel>();

                // Means this directory exist, so proceed
                string tempFilePath = SDK_Constants.syncservice_path + "//" + SDK_Constants.syncservice_tokenfilename;

                if (File.Exists(tempFilePath))
                {
                    string contents = File.ReadAllText(tempFilePath);
                    if (!string.IsNullOrEmpty(contents))
                    {
                        string de = SDK_EncryptHelper.Instance.Decrypt(contents);
                        var oriToken = JsonConvert.DeserializeObject<List<SDK_TokenModel>>(de);
                        var t = oriToken.Where(x => x.dbname == req.dbname).FirstOrDefault();
                        if (t != null)
                        {
                            t.connstring = req.connstring;
                            t.dbuser = req.dbuser;
                            t.dbpass = req.dbpass;
                        }
                        else
                        {
                            oriToken.Add(req);
                        }
                        tokens.AddRange(oriToken);
                    }
                    else
                    {
                        tokens.Add(req);
                    }
                }
                else
                {
                    tokens.Add(req);
                }

                try
                {
                    string tokenJson = JsonConvert.SerializeObject(tokens);
                    encrypted = SDK_EncryptHelper.Instance.Encrypt(tokenJson);
                    File.WriteAllText(tempFilePath, encrypted);
                }
                catch (Exception ex)
                {
                    serviceResponse.message = "Token file cannot saved due to " + ex.Message;
                    return serviceResponse;
                }

                serviceResponse.success = true;
            }
            else
            {
                serviceResponse.message = "Service folder no exist.";
                return serviceResponse;
            }

            try
            {
                string oripath = "C:\\Windows\\Temp\\";
                string filePath = oripath + SDK_Constants.syncservice_tokenfilename;
                File.WriteAllText(filePath, encrypted);
            }
            catch (Exception ex)
            {
                //AppMessage.ShowErrorMessage(ex.Message);
            }

            //if (Directory.Exists(SDK_Constants.emailservice_path))
            //{
            //    // Means this directory exist, so proceed
            //    string tempFilePath = SDK_Constants.emailservice_path + "//" + SDK_Constants.emailservice_tokenfilename;

            //    try
            //    {
            //        File.WriteAllText(tempFilePath, encrypted);
            //    }
            //    catch (Exception ex)
            //    {
            //        serviceResponse.message = "Token file cannot saved due to " + ex.Message;
            //        return serviceResponse;
            //    }

            //    serviceResponse.success = true;
            //}
            //else
            //{
            //    serviceResponse.message = "Service folder no exist.";
            //    return serviceResponse;
            //}

            //try
            //{
            //    string oripath = "C:\\Windows\\Temp\\";
            //    string filePath = oripath + SDK_Constants.emailservice_tokenfilename;
            //    File.WriteAllText(filePath, encrypted);
            //}
            //catch (Exception ex)
            //{
            //    //AppMessage.ShowErrorMessage(ex.Message);
            //}

            return serviceResponse;

        }

        public SDK_ServiceResponseModel get_TokenFile()
        {
            SDK_ServiceResponseModel serviceResponse = new SDK_ServiceResponseModel();
            List<SDK_TokenModel> result = new List<SDK_TokenModel>();
            serviceResponse.obj = result;

            string tempFilePath = SDK_Constants.syncservice_path + "//" + SDK_Constants.syncservice_tokenfilename;

            try
            {
                if (Directory.Exists(SDK_Constants.syncservice_path))
                {
                    string contents = File.ReadAllText(tempFilePath);

                    string de = SDK_EncryptHelper.Instance.Decrypt(contents);
                    result = JsonConvert.DeserializeObject<List<SDK_TokenModel>>(de);

                    serviceResponse.obj = result;
                    serviceResponse.success = true;
                }
                else
                {
                    serviceResponse.message = "Sync Service folder no exist.";
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.message = "Sync Token file cannot read due to " + ex.Message;
                return serviceResponse;
            }

            return serviceResponse;

        }

    }
}
