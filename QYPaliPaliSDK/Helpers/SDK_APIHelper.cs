using Newtonsoft.Json;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Models;
using QYPaliPaliSDK.Models.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_APIHelper
    {
        #region singleton
        private static readonly Lazy<SDK_APIHelper> lazy = new Lazy<SDK_APIHelper>(() => new SDK_APIHelper());
        public static SDK_APIHelper Instance { get { return lazy.Value; } }
        private SDK_APIHelper() { }
        #endregion

        public async Task<SDK_ServiceResponseModel> post_getShop(string url, string appId, string appSecret)
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();

                using (var client = new HttpClient())
                {
                    string bizParam = "{\"page\":\"1\", \"pageSize\":\"200\"}";
                    long timeStamp = Stopwatch.GetTimestamp();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_getShopList, timeStamp, appSecret);
                    // create the form data content
                    //var formData = new MultipartFormDataContent();
                    //formData.Add(new StringContent("appId"), appId);
                    //formData.Add(new StringContent("serviceType"), SDK_Constants.api_servicetype_getShopList);
                    //formData.Add(new StringContent("timestamp"), timeStamp.ToString());
                    //if (bizParam != "")
                    //{
                    //    formData.Add(new StringContent("bizParam"), bizParam);
                    //}
                    //formData.Add(new StringContent("sign"), sign);
                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_getShopList),
                        new KeyValuePair<string, string>("timestamp", timeStamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign)
                    });

                    //set up client
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = new Uri(SDK_Constants.api_post_shop, UriKind.Relative);
                    var task = client.PostAsync(requestUri, body);
                    var response = task.GetAwaiter().GetResult();   
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);
                }

                if (res.state == "success")
                {
                    responseModel.success = true;
                    responseModel.message = res.bizContent;
                }
                else
                {
                    responseModel.message = res.errorCode + " :: " + res.errorMsg;
                }

            }
            //catch (Exception ex)
            //{
            //    responseModel.Message = ex.Message;
            //    auditLog.ResponseTime = DateTime.Now;
            //    auditLog.Exception = ex.Message;

            //}
            catch (HttpRequestException ex)
            {
                responseModel.message = ex.InnerException.Message;
            }

            return responseModel;
        }

        public async Task<SDK_ServiceResponseModel> post_getStock(string url, string appId, string appSecret, SDK_APIStock_ListReqModel req, string connStr)
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();

                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(req);
                    string bizParam = json;
                    long timeStamp = Stopwatch.GetTimestamp();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_getStockList, timeStamp, appSecret);
                    // create the form data content
                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_getStockList),
                        new KeyValuePair<string, string>("timestamp", timeStamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign)
                    });
                    
                    //set up client
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
                    client.Timeout = TimeSpan.FromSeconds(10);

                    SDK_LogHelper.Instance.insert_SyncLogDB(connStr, SDK_Enums.EnumLogInfoType.INF, json, "send " + appId, "post_getStock", "SDK_APIHelper");

                    var requestUri = new Uri(SDK_Constants.api_post_stock, UriKind.Relative);
                    var response = await client.PostAsync(requestUri, body);
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);

                    SDK_LogHelper.Instance.insert_SyncLogDB(connStr, SDK_Enums.EnumLogInfoType.INF, result, "receive", "post_getStock", "SDK_APIHelper");

                }

                if (res.state == "success")
                {
                    responseModel.success = true;
                    responseModel.message = res.bizContent;
                }
                else
                {
                    responseModel.message = res.errorCode + " :: " + res.errorMsg;
                }

            }
            //catch (Exception ex)
            //{
            //    responseModel.Message = ex.Message;
            //    auditLog.ResponseTime = DateTime.Now;
            //    auditLog.Exception = ex.Message;

            //}
            catch (HttpRequestException ex)
            {
                responseModel.message = ex.InnerException.Message;
            }

            return responseModel;
        }

        public async Task<SDK_ServiceResponseModel> post_getWarehouse(string url, string appId, string appSecret, SDK_APIWarehouse_ListReqModel req)
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();

                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(req);
                    string bizParam = json;
                    long timeStamp = Stopwatch.GetTimestamp();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_getWarehouseList, timeStamp, appSecret);
                    // create the form data content
                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_getWarehouseList),
                        new KeyValuePair<string, string>("timestamp", timeStamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign)
                    });

                    //set up client
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = new Uri(SDK_Constants.api_post_warehouse, UriKind.Relative);
                    var response = await client.PostAsync(requestUri, body);
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);
                }

                if (res.state == "success")
                {
                    responseModel.success = true;
                    responseModel.message = res.bizContent;
                }
                else
                {
                    responseModel.message = res.errorCode + " :: " + res.errorMsg;
                }

            }
            //catch (Exception ex)
            //{
            //    responseModel.Message = ex.Message;
            //    auditLog.ResponseTime = DateTime.Now;
            //    auditLog.Exception = ex.Message;

            //}
            catch (HttpRequestException ex)
            {
                responseModel.message = ex.InnerException.Message;
            }

            return responseModel;
        }

        public async Task<SDK_ServiceResponseModel> post_getSalesOrder(string url, string appId, string appSecret, SDK_APISalesOrder_ListReqModel req)
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();

                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(req);
                    string bizParam = json;
                    long timeStamp = Stopwatch.GetTimestamp();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_getSalesOrderList, timeStamp, appSecret);
                    // create the form data content
                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_getSalesOrderList),
                        new KeyValuePair<string, string>("timestamp", timeStamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign)
                    });

                    //set up client
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = new Uri(SDK_Constants.api_post_salesOrder, UriKind.Relative);
                    var response = await client.PostAsync(requestUri, body);
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);
                }

                if (res.state == "success")
                {
                    responseModel.success = true;
                    responseModel.message = res.bizContent;
                }
                else
                {
                    responseModel.message = res.errorCode + " :: " + res.errorMsg;
                }

            }
            //catch (Exception ex)
            //{
            //    responseModel.Message = ex.Message;
            //    auditLog.ResponseTime = DateTime.Now;
            //    auditLog.Exception = ex.Message;

            //}
            catch (HttpRequestException ex)
            {
                responseModel.message = ex.InnerException.Message;
            }

            return responseModel;
        }

        public async Task<SDK_ServiceResponseModel> post_createSalesOrder(string url, string appId, string appSecret, SDK_APISalesOrder_CreateReqModel req, string connStr)
        {
            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();
                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(req);
                    string bizParam = json;
                    long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_createSalesOrder, timestamp, appSecret);

                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_createSalesOrder),
                        new KeyValuePair<string, string>("timestamp", timestamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign),
                    });

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = new Uri(SDK_Constants.api_post_salesOrder, UriKind.Relative);

                    var task = client.PostAsync(requestUri, body);
                    var response = task.GetAwaiter().GetResult();
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);

                    SDK_LogHelper.Instance.insert_SyncLogDB(connStr, SDK_Enums.EnumLogInfoType.INF, json, result, "post_createSalesOrder", "");

                    if (res.state == "success")
                    {
                        if (res.bizContent.Contains("result"))
                        {
                            SDK_LogHelper.Instance.insert_SyncRecordDB(connStr, json, result, "");

                            var biz = JsonConvert.DeserializeObject<SDK_API_SO_ResSuccessInfoModel>(res.bizContent);
                            responseModel.success = true;
                            responseModel.message = biz.result.orderNumber;
                        }
                        else
                        {
                            var biz = JsonConvert.DeserializeObject<SDK_API_ResErrorInfoModel>(res.bizContent);
                            responseModel.message = biz.errorCode + ":" + biz.errorMsg;
                        }
                    }
                    else
                    {
                        responseModel.message = res.errorCode + ":" + res.errorMsg;
                    }
                }
            } 
            catch (Exception ex)
            {
                responseModel.message = ex.Message;
                responseModel.description = ex.InnerException == null ? "" : ex.InnerException.Message;
            }
            return responseModel;
        }

        public async Task<SDK_ServiceResponseModel> post_getInboundOrder(string url, string appId, string appSecret, SDK_APIInboundOrder_ListReqModel req)
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();

                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(req);
                    string bizParam = json;
                    long timeStamp = Stopwatch.GetTimestamp();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_getInboundOrderList, timeStamp, appSecret);
                    // create the form data content
                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_getInboundOrderList),
                        new KeyValuePair<string, string>("timestamp", timeStamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign)
                    });

                    //set up client
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = new Uri(SDK_Constants.api_post_inboundOrder, UriKind.Relative);
                    var response = await client.PostAsync(requestUri, body);
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);
                }

                if (res.state == "success")
                {
                    responseModel.success = true;
                    responseModel.message = res.bizContent;
                }
                else
                {
                    responseModel.message = res.errorCode + " :: " + res.errorMsg;
                }

            }
            //catch (Exception ex)
            //{
            //    responseModel.Message = ex.Message;
            //    auditLog.ResponseTime = DateTime.Now;
            //    auditLog.Exception = ex.Message;

            //}
            catch (HttpRequestException ex)
            {
                responseModel.message = ex.InnerException.Message;
            }

            return responseModel;
        }

        public async Task<SDK_ServiceResponseModel> post_createInboundOrder(string url, string appId, string appSecret, SDK_APIInboundOrder_CreateReqModel req, string connStr)
        {
            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();
                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(req);
                    string bizParam = json;
                    long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_createInboundOrder, timestamp, appSecret);

                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_createInboundOrder),
                        new KeyValuePair<string, string>("timestamp", timestamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign),
                    });

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = new Uri(SDK_Constants.api_post_inboundOrder, UriKind.Relative);

                    var task = client.PostAsync(requestUri, body);
                    var response = task.GetAwaiter().GetResult();
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);

                    SDK_LogHelper.Instance.insert_SyncLogDB(connStr, SDK_Enums.EnumLogInfoType.INF, json, result, "post_createInboundOrder", "");

                    if (res.state == "success")
                    {
                        if (res.bizContent.Contains("result"))
                        {
                            SDK_LogHelper.Instance.insert_SyncRecordDB(connStr, json, result, "");

                            var biz = JsonConvert.DeserializeObject<SDK_API_IO_ResSuccessInfoModel>(res.bizContent);
                            responseModel.success = true;
                            responseModel.message = biz.result.asnNumber;
                        }
                        else
                        {
                            var biz = JsonConvert.DeserializeObject<SDK_API_ResErrorInfoModel>(res.bizContent);
                            responseModel.message = biz.errorCode + ":" + biz.errorMsg;
                        }
                    }
                    else
                    {
                        responseModel.message = res.errorCode + ":" + res.errorMsg;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.message = ex.Message;
                responseModel.description = ex.InnerException == null ? "" : ex.InnerException.Message;
            }
            return responseModel;
        }

        //public async Task<SDK_ServiceResponseModel> post_createPurchaseOrder(string url, string appId, string appSecret, SDK_APIPurchaseOrder_CreateReqModel req)
        //{
        //    SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

        //    try
        //    {
        //        SDK_API_ResModel res = new SDK_API_ResModel();

        //        using (var client = new HttpClient())
        //        {
        //            string json = JsonConvert.SerializeObject(req);
        //            string bizParam = json;
        //            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        //            string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_createPurchaseOrder, timestamp, appSecret);

        //            var body = new FormUrlEncodedContent(new[]
        //            {
        //                new KeyValuePair<string, string>("appId", appId),
        //                new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_createPurchaseOrder),
        //                new KeyValuePair<string, string>("timestamp", timestamp.ToString()),
        //                new KeyValuePair<string, string>("bizParam", bizParam),
        //                new KeyValuePair<string, string>("sign", sign),
        //            });

        //            client.BaseAddress = new Uri(url);
        //            client.DefaultRequestHeaders.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            var requestUri = new Uri(SDK_Constants.api_post_purchaseOrder, UriKind.Relative);

        //            var task = client.PostAsync(requestUri, body);
        //            var response = task.GetAwaiter().GetResult();

        //            var result = await response.Content.ReadAsStringAsync();
        //            res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);

        //            if (res.state == "success")
        //            {
        //                if (res.bizContent.Contains("result"))
        //                {
        //                    var biz = JsonConvert.DeserializeObject<SDK_API_ResSuccessInfoModel>(res.bizContent);
        //                    responseModel.success = true;
        //                    responseModel.message = biz.result;
        //                }
        //                else
        //                {
        //                    var biz = JsonConvert.DeserializeObject<SDK_API_ResErrorInfoModel>(res.bizContent);
        //                    responseModel.message = biz.errorCode + ":" + biz.errorMsg;
        //                }
        //            }
        //            else
        //            {
        //                responseModel.message = res.errorCode + " :: " + res.errorMsg;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel.message = ex.InnerException.Message;
        //    }
        //    return responseModel;
        //}


        public async Task<SDK_ServiceResponseModel> post_getShopeeOrder(string url, string appId, string appSecret, SDK_APIShopeeTrx_ReqModel req)
        {
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            SDK_ServiceResponseModel responseModel = new SDK_ServiceResponseModel();

            try
            {
                SDK_API_ResModel res = new SDK_API_ResModel();

                using (var client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(req);
                    string bizParam = json;
                    long timeStamp = Stopwatch.GetTimestamp();
                    string sign = SDK_APISignHelper.Instance.calcSign(appId, bizParam, SDK_Constants.api_servicetype_getShopeeTransaction, timeStamp, appSecret);
                    // create the form data content
                    var body = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("appId", appId),
                        new KeyValuePair<string, string>("serviceType", SDK_Constants.api_servicetype_getShopeeTransaction),
                        new KeyValuePair<string, string>("timestamp", timeStamp.ToString()),
                        new KeyValuePair<string, string>("bizParam", bizParam),
                        new KeyValuePair<string, string>("sign", sign)
                    });

                    //set up client
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = new Uri(SDK_Constants.api_post_report, UriKind.Relative);
                    var response = await client.PostAsync(requestUri, body);
                    var result = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<SDK_API_ResModel>(result);
                }

                if (res.state == "success")
                {
                    responseModel.success = true;
                    responseModel.message = res.bizContent;
                }
                else
                {
                    responseModel.message = res.errorCode + " :: " + res.errorMsg;
                }

            }
            //catch (Exception ex)
            //{
            //    responseModel.Message = ex.Message;
            //    auditLog.ResponseTime = DateTime.Now;
            //    auditLog.Exception = ex.Message;

            //}
            catch (HttpRequestException ex)
            {
                responseModel.message = ex.InnerException.Message;
            }

            return responseModel;
        }

        public void insert_SyncRevision(string connStr, string docType, long docKey, int revision)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connStr);
                System.Data.SqlClient.SqlCommand sqlCmd = new System.Data.SqlClient.SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.Connection.Open();

                Guid obj = Guid.NewGuid();
                string sql = "";
                sql = string.Format(@"IF NOT EXISTS (SELECT 1 FROM {0} WHERE DocType = '{1}' AND DocKey = '{2}' )
                                    BEGIN
                                       INSERT INTO {0} (id, created_at, DocType, DocKey, NextRevision) 
                                            values ('{4}', GETDATE(), '{1}','{2}', '{3}')
                                    END  
                                ELSE 
                                    BEGIN
                                        UPDATE {0} SET NextRevision='{3}' WHERE DocType = '{1}' AND DocKey = '{2}'
                                    END ", SDK_Constants.tbl_Flex_SyncRevision, docType, docKey, revision, obj.ToString());

                sqlCmd.CommandText = sql;  

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();

                return;

            }
            catch (Exception ex)
            {
                SDK_LogHelper.Instance.insert_LogDB(connStr, SDK_Enums.EnumLogInfoType.ERR, ex.Message, ex.InnerException == null ? "" : ex.InnerException.Message, "insert_SyncRevision", "");
                //AppMessage.ShowErrorMessage(ex.Message);
                return;
            }

        }

        public int get_SyncRevision(string connStr, string docType, long docKey)
        {
            int result = 0;
            try
            {
                string sql = "SELECT * FROM " + SDK_Constants.tbl_Flex_SyncRevision + " " +
                    "WHERE DocType='" + docType.Replace("'", "''") + "' AND DocKey=" + docKey+ " ";
                DataRow dr = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
                if (dr == null)
                {
                    //
                }
                else
                {
                    result = Convert.ToInt32(dr["NextRevision"]);
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

    }
}
