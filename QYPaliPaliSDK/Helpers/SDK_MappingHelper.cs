using Newtonsoft.Json;
using QYPaliPaliSDK.General;
using QYPaliPaliSDK.Models;
using QYPaliPaliSDK.Models.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QYPaliPaliSDK.Helpers
{
    public class SDK_MappingHelper
    {
        #region singleton
        private static readonly Lazy<SDK_MappingHelper> lazy = new Lazy<SDK_MappingHelper>(() => new SDK_MappingHelper());
        public static SDK_MappingHelper Instance { get { return lazy.Value; } }
        private SDK_MappingHelper() { }
        #endregion

        public SDK_ServiceResponseModel get_ItemMap(string connStr, string sku, string url, string accessKey, string accessSecret, bool callAPI, Dictionary<string, SDK_MapperModel> bundleDtlList)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            try
            {
                //// ***** TESTING *****
                //SDK_MapperModel mappert = new SDK_MapperModel();
                //mappert.itemCode = "00001";
                //mappert.uom = "PC";
                //result.success = true;
                //result.obj = mappert;
                //return result;
                //// ***** TESTING *****

                if (sku == null)
                {
                    result.message = "SKU is empty.";
                    return result;
                }
                if (sku.Trim() == "")
                {
                    result.message = "SKU is empty.";
                    return result;
                }

                string sql = "";
                //SDK_MapperModel mapper = new SDK_MapperModel();

                // 1. check mapping table
                var rMap1 = map_FlexItem(connStr, sku);
                if (rMap1.success)
                {
                    result.success = true;
                    result.obj = rMap1.obj;
                    return result;
                }

                // 2. check barcode then itemcode then subcode 
                var rMap2 = map_AutoCountItem(connStr, sku);
                if (rMap2.success)
                {
                    result.success = true;
                    result.obj = rMap2.obj;
                    return result;
                }

                if (bundleDtlList.Count > 0)
                {
                    if (bundleDtlList.ContainsKey(sku))
                    {
                        var bundle = bundleDtlList.Where(x => x.Key == sku).FirstOrDefault();
                        result.success = true;
                        result.obj = bundle.Value;
                        return result;
                    }
                }

                // 3. check if is bundle
                if (callAPI)
                {
                    SDK_APIStock_ListReqModel req = new SDK_APIStock_ListReqModel();
                    req.page = 1;
                    req.pageSize = SDK_Constants.api_pagesize;
                    req.skus.Add(sku);

                    var r = SDK_APIHelper.Instance.post_getStock(url, accessKey, accessSecret, req, connStr).GetAwaiter().GetResult();
                    if (r.success)
                    {
                        SDK_APIStock_ListResModel res = JsonConvert.DeserializeObject<SDK_APIStock_ListResModel>(r.message);
                        if (res.result[0].type == "COMBINE")
                        {
                            if (res.result[0].singleSkuList != null)
                            {
                                SDK_MapperModel mapper = new SDK_MapperModel();
                                bool allMapped = true;
                                string err = "";

                                foreach (var singleSKU in res.result[0].singleSkuList)
                                {
                                    if (singleSKU.isDeleted == 0)
                                    {
                                        // 3.1. check mapping table
                                        var rMap3 = map_FlexItem(connStr, singleSKU.sku);
                                        if (rMap3.success)
                                        {
                                            var item = rMap3.obj as SDK_MapperModel;
                                            var pd = new SDK_Mapper_PackDetailModel();
                                            pd.itemCode = item.itemCode;
                                            pd.uom = item.uom;
                                            pd.qty = singleSKU.quantity;
                                            mapper.packDtl.Add(pd);
                                        }
                                        else
                                        {
                                            // 3.2. check barcode then itemcode then subcode 
                                            var rMap4 = map_AutoCountItem(connStr, singleSKU.sku);
                                            if (rMap4.success)
                                            {
                                                var item = rMap4.obj as SDK_MapperModel;
                                                var pd = new SDK_Mapper_PackDetailModel();
                                                pd.itemCode = item.itemCode;
                                                pd.uom = item.uom;
                                                pd.qty = singleSKU.quantity;
                                                mapper.packDtl.Add(pd);
                                            }
                                            else
                                            {
                                                allMapped = false;
                                                err = err + "Bundle [" + res.result[0].title + "] item [" + singleSKU.sku + "] is not map.";
                                            }
                                        }
                                    }
                                }

                                if (allMapped == true)
                                {
                                    result.success = true;
                                    result.obj = mapper;
                                    return result;
                                }
                                else
                                {
                                    result.success = false;
                                    result.message = err;
                                    return result;
                                }
                            }
                        }
                    }
                }
                else
                {
                    result.message = "SKU [" + sku + "] is not map.";
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.description = ex.InnerException != null ? ex.InnerException.Message : "";
            }
            return result;
        }

        public SDK_ServiceResponseModel recalculate_UnitPrice(string connStr, List<SDK_Mapper_PackDetailModel> packDtlList, double sellingQty, double sellingUP)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            try
            {
                if (packDtlList.Count == 1)
                {
                    packDtlList[0].unitPrice = sellingUP / packDtlList[0].qty;
                }
                else
                {
                    // 1. get total oripack from ac item maintenance
                    DataRow drGet;
                    double ttlAC = 0;

                    foreach (var pd in packDtlList)
                    {
                        drGet = SDK_SqlHelper.Instance.getFirstDataRow(connStr, "SELECT ISNULL(Price, 0) AS Price FROM " + SDK_Constants.tbl_itemuom + " WHERE ItemCode='" + pd.itemCode.Replace("'", "''") + "' AND UOM='" + pd.uom.Replace("'", "''") + "' ");
                        if (drGet != null)
                        {
                            pd.acUnitPrice = Convert.ToDouble(drGet["Price"].ToString());
                            ttlAC = ttlAC + Convert.ToDouble(drGet["Price"].ToString()) * pd.qty;
                        }
                    }

                    if (ttlAC == 0)
                    {
                        result.message = "Total AutoCount amount zero.";
                        return result;
                    }

                    // 2. get ratio
                    double ratio = (sellingQty * sellingUP) / ttlAC;

                    // 3. recalculate unitprice
                    foreach (var pd in packDtlList)
                    {
                        pd.unitPrice = pd.acUnitPrice * ratio;
                    }
                }

                result.success = true;
                result.obj = packDtlList;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.description = ex.InnerException != null ? ex.InnerException.Message : "";
            }
            return result;
        }

        public SDK_ServiceResponseModel map_AutoCountItem(string connStr, string sku)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            SDK_MapperModel mapper = new SDK_MapperModel();
            DataRow drItem = null;

            string sql = "SELECT * FROM " + SDK_Constants.tbl_itemuom + " WHERE Barcode='" + sku.Replace("'", "''") + "' ";
            drItem = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
            if (drItem == null)
            {
                sql = "SELECT * FROM " + SDK_Constants.tbl_item + " WHERE ItemCode='" + sku.Replace("'", "''") + "' ";
                drItem = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
                if (drItem == null)
                {
                    sql = "SELECT i.* FROM " + SDK_Constants.tbl_itemsubcode + " s INNER JOIN " + SDK_Constants.tbl_item + " i ON s.ItemCode=i.ItemCode " +
                        "WHERE s.SubCode='" + sku.Replace("'", "''") + "' ";
                    drItem = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
                    if (drItem == null)
                    {
                        //
                    }
                    else
                    {
                        mapper.itemCode = drItem["ItemCode"].ToString();
                        mapper.uom = drItem["SalesUOM"].ToString();
                    }
                }
                else
                {
                    mapper.itemCode = drItem["ItemCode"].ToString();
                    mapper.uom = drItem["SalesUOM"].ToString();
                }
            }
            else
            {
                mapper.itemCode = drItem["ItemCode"].ToString();
                mapper.uom = drItem["UOM"].ToString();
            }
            if (drItem != null)
            {
                result.success = true;
                result.obj = mapper;
            }
            else
            {
                result.message = "Item [" + sku + "] not map.";
            }

            return result;
        }

        public SDK_ServiceResponseModel map_FlexItem(string connStr, string sku)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            SDK_MapperModel mapper = new SDK_MapperModel();
            DataRow drMap = null;

            string sql = "SELECT m.*, " +
                "CASE WHEN u.ItemCode IS NOT NULL THEN u.ItemCode ELSE '' END AS ItemCode, " +
                "CASE WHEN u.UOM IS NOT NULL THEN u.UOM ELSE '' END AS UOM " +
                "FROM " + SDK_Constants.tbl_Flex_ItemMap + " m  " +
                "LEFT OUTER JOIN " + SDK_Constants.tbl_itemuom + " u on u.AutoKey=m.Item " +
                "LEFT OUTER JOIN " + SDK_Constants.tbl_item + " i on i.ItemCode=u.ItemCode " +
                "LEFT OUTER JOIN " + SDK_Constants.tbl_pack + " p on p.DocKey=m.ItemPackage " +
                "WHERE m.QYSKU='" + sku.Replace("'", "''") + "' ";
            drMap = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
            if (drMap != null)
            {
                long itemKey = 0;
                long packKey = 0;
                long.TryParse(drMap["Item"] == DBNull.Value ? "0" : drMap["Item"].ToString(), out itemKey);
                long.TryParse(drMap["ItemPackage"] == DBNull.Value ? "0" : drMap["ItemPackage"].ToString(), out packKey);

                if (itemKey == 0 && packKey == 0)
                {
                    drMap = null;
                }
                else
                {
                    if (itemKey > 0)
                    {
                        mapper.itemCode = drMap["ItemCode"].ToString();
                        mapper.uom = drMap["UOM"].ToString();
                    }
                    else
                    {
                        mapper.packDocKey = packKey;
                    }
                    result.success = true;
                    result.obj = mapper;
                }
            }

            return result;
        }

        public SDK_ServiceResponseModel get_LocationMap(string connStr, string warehouse)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            try
            {
                if (warehouse.Trim() == "")
                {
                    result.message = "Warehouse is empty.";
                    return result;
                }

                SDK_MapperModel mapper = new SDK_MapperModel();

                string sql = "SELECT l.* FROM " + SDK_Constants.tbl_Flex_LocMap + " m INNER JOIN " + SDK_Constants.tbl_location + " l ON m.Location=l.AutoKey " +
                    "WHERE m.QYName='" + warehouse.Replace("'", "''") + "' ";
                DataRow drItem = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
                if (drItem == null)
                {
                    //
                }
                else
                {
                    mapper.location = drItem["Location"].ToString();
                }
                if (drItem != null)
                {
                    result.success = true;
                    result.obj = mapper;
                }
                else
                {
                    result.message = "Warehouse [" + warehouse + "] not map.";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.description = ex.InnerException != null ? ex.InnerException.Message : "";
            }
            return result;
        }

        public SDK_ServiceResponseModel get_ACCurrencyMap(string connStr, string cur)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            try
            {
                if (cur.Trim() == "")
                {
                    result.message = "Currency is empty.";
                    return result;
                }

                SDK_MapperModel mapper = new SDK_MapperModel();

                string sql = "SELECT m.* FROM " + SDK_Constants.tbl_Flex_CurrencyMap + " m " +
                    "INNER JOIN " + SDK_Constants.tbl_currency + " c on c.Guid=m.Currency " +
                    "WHERE c.CurrencyCode='" + cur.Replace("'", "''") + "' ";
                DataRow drItem = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
                if (drItem == null)
                {
                    //
                }
                else
                {
                    mapper.currency = drItem["QYEnum"].ToString();
                }
                if (drItem != null)
                {
                    result.success = true;
                    result.obj = mapper;
                }
                else
                {
                    result.message = "Currency [" + cur + "] not map.";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.description = ex.InnerException != null ? ex.InnerException.Message : "";
            }
            return result;
        }

        public SDK_ServiceResponseModel get_ACLocationMap(string connStr, string location)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            try
            {
                if (location.Trim() == "")
                {
                    result.message = "Location is empty.";
                    return result;
                }

                SDK_MapperModel mapper = new SDK_MapperModel();

                string sql = "SELECT m.* FROM " + SDK_Constants.tbl_Flex_LocMap + " m INNER JOIN " + SDK_Constants.tbl_location + " l ON m.Location=l.AutoKey " +
                    "WHERE l.Location='" + location.Replace("'", "''") + "' ";
                DataRow drItem = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
                if (drItem == null)
                {
                    //
                }
                else
                {
                    mapper.location = drItem["QYName"].ToString();
                }
                if (drItem != null)
                {
                    result.success = true;
                    result.obj = mapper;
                }
                else
                {
                    result.message = "Location [" + location + "] not map.";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.description = ex.InnerException != null ? ex.InnerException.Message : "";
            }
            return result;
        }

        public SDK_ServiceResponseModel map_SOPO_FlexItem(string connStr, string itemCode, string uom)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            SDK_MapperModel mapper = new SDK_MapperModel();

            string sql = "SELECT m.* " + 
                "FROM " + SDK_Constants.tbl_Flex_ItemMap + " m  " +
                "INNER JOIN " + SDK_Constants.tbl_itemuom + " u on u.AutoKey=m.Item " +
                "INNER JOIN " + SDK_Constants.tbl_item + " i on i.ItemCode=u.ItemCode " +
                "WHERE u.ItemCode='" + itemCode.Replace("'", "''") + "' AND u.UOM='" + uom.Replace("'", "''") + "' ";
            DataRow drMap = SDK_SqlHelper.Instance.getFirstDataRow(connStr, sql);
            if (drMap != null)
            {
                mapper.sku = drMap["QYSKU"].ToString();
                result.success = true;
                result.obj = mapper;
            }

            return result;
        }

        public SDK_ServiceResponseModel check_ItemMap(string connStr, string sku)
        {
            SDK_ServiceResponseModel result = new SDK_ServiceResponseModel();
            try
            {
                if (sku == null)
                {
                    result.message = "SKU is empty.";
                    return result;
                }
                if (sku.Trim() == "")
                {
                    result.message = "SKU is empty.";
                    return result;
                }

                string sql = "";

                // 1. check barcode then itemcode then subcode 
                var rMap2 = map_AutoCountItem(connStr, sku);
                if (rMap2.success)
                {
                    result.success = true;
                    result.obj = rMap2.obj;
                    return result;
                }
                else
                {
                    result.message = "Not Map";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.description = ex.InnerException != null ? ex.InnerException.Message : "";
            }
            return result;
        }

    }
}
