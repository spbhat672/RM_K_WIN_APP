using RM_API_Kafka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.WebMethod
{
    public static class ModelDataConversion
    {
        private const string dateFormat = "dd-MM-yyyy HH:mm:ss";

        public static string DataModelToGetResponseModel(ResourceGetRequestModel request, List<Resource3DXWithValue> resList)
        {
            string jsonStr1 = @"{  
                                    'header': {
                                                'sourceRequest': {
                                                                   'requestId': " + request.header.requestId + @",                                                                
                                                                   'requestType': '" + request.header.requestType + @"',  
                                                                   'version': '1.0'  
	                                                             },
                                                'messageType':'" + request.header.requestType + @"', 
                                                'version': '1.0',
	                                            'dateMsg':	'" + request.header.dateMsg.ToString("yyyy-MM-dd HH:mm:ss") + @"',                                                
	                                     },
	                                'body':{
                                                'resourceState': [";
            string jsonStr2 = "";
            int itemIteration = 0;
            int itemCount = resList.Select(p => p.ResourceId).Distinct().Count();
            foreach (var resItems in resList.GroupBy(x => x.ResourceId).ToList())
            {
                long itemId = resItems.Key;
                jsonStr2 += @"{
                              'id': '" + itemId + @"',
			                  'updateDataDate': '" + (Convert.ToDateTime(resItems.Where(x => x.ResourceId == itemId).FirstOrDefault().Date)).ToString("yyyy-MM-dd HH:mm:ss") + @"',
						      'tags': {
                    ";
                int subItemIteration = 0;
                int subItemCount = resItems.Where(x => x.ResourceId == itemId).ToList().Count();
                foreach (var subItem in resItems.Where(x => x.ResourceId == itemId))
                {
                    if (subItem.Name == "Status")
                    {
                        jsonStr2 += @"*" + subItem.Name + "*: {*value*: *" + subItem.Value + "*}" + Environment.NewLine;
                    }
                    else if (subItem.Name == "Speed")
                    {
                        jsonStr2 += @"*" + subItem.Name + "*: {*value*: " + subItem.Value + ", *uom*: *" + subItem.UOM + "*}" + Environment.NewLine;
                    }
                    else
                    {
                        jsonStr2 += @"*" + subItem.Name + "*: {*value*: *[" + subItem.Value + "]*, *uom*: *" + subItem.UOM + "*}" + Environment.NewLine;
                    }
                    jsonStr2 += (subItemIteration < subItemCount) ? ("," + Environment.NewLine) : String.Empty;
                    subItemCount++;
                }
                jsonStr2 += (itemIteration < itemCount) ? ("}," + Environment.NewLine) : ("," + Environment.NewLine);
                itemCount++;
            }
            jsonStr2 += itemCount > 0 ? Environment.NewLine + "}" + Environment.NewLine : String.Empty;

            string jsonStr3 = @"]
                                    }
                                }";

            string jsonString = jsonStr1 + jsonStr2 + jsonStr3;
            jsonString = jsonString.Replace('\'', '\"');
            jsonString = jsonString.Replace('*', '\"');
            jsonString = jsonString.Replace("\n", "").ToString();
            jsonString = jsonString.Replace("\t", "").ToString();
            jsonString = jsonString.Replace("\r", "").ToString();
            jsonString = jsonString.Trim('\t');
            return jsonString;
        }

        public static string AddModelToResponseModel(List<ResourceWithValue> resList)
        {
            string jsonStr1 = @"{  
                                    'header': {
                                                'messageType':'resourceState', 
                                                'version': '1.0',
	                                            'dateMsg':	'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',                                                
	                                     },
	                                'body':{
                                                'resourceState': [";
            string jsonStr2 = "";

            jsonStr2 += @"{
                              'id': '" + resList.FirstOrDefault().ResourceId + @"',
			                  'updateDataDate': '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
						      'tags': {
                    ";
            int subItemIteration = 0;
            int subItemCount = resList.Count();
            foreach (var subItem in resList)
            {
                if (subItem.TagName == "Status")
                {
                    jsonStr2 += @"*" + subItem.TagName + "*: {*value*: *" + subItem.TagValue + "*}" + Environment.NewLine;
                }
                else if (subItem.TagName == "Speed")
                {
                    jsonStr2 += @"*" + subItem.TagName + "*: {*value*: " + subItem.TagValue + ", *uom*: *" + subItem.TagUOM + "*}" + Environment.NewLine;
                }
                else
                {
                    jsonStr2 += @"*" + subItem.TagName + "*: {*value*: [" + subItem.TagValue + "], *uom*: *" + subItem.TagUOM + "*}" + Environment.NewLine;
                }
                jsonStr2 += (subItemIteration < subItemCount) ? ("," + Environment.NewLine) : String.Empty;
                subItemCount++;
            }

            jsonStr2 += Environment.NewLine + "}" + Environment.NewLine + Environment.NewLine + "}";

            string jsonStr3 = @"]
                                    }
                                }";

            string jsonString = jsonStr1 + jsonStr2 + jsonStr3;
            jsonString = jsonString.Replace('\'', '\"');
            jsonString = jsonString.Replace('*', '\"');
            jsonString = jsonString.Replace("\n", "").ToString();
            jsonString = jsonString.Replace("\t", "").ToString();
            jsonString = jsonString.Replace("\r", "").ToString();
            jsonString = jsonString.Trim('\t');
            return jsonString;
        }

        public static string AddModelToResponseModel(List<ExcelTagInput> resList)
        {
            string jsonStr1 = @"{  
                                    'header': {
                                                'messageType':'resourceState', 
                                                'version': '1.0',
	                                            'dateMsg':	'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',                                                
	                                     },
	                                'body':{
                                                'resourceState': [";
            string jsonStr2 = "";

            jsonStr2 += @"{
                              'id': '" + resList.FirstOrDefault().ResourceId + @"',
			                  'updateDataDate': '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',
						      'tags': {
                    ";
                int subItemIteration = 0;
                int subItemCount = resList.Count();
                foreach (var subItem in resList)
                {

                    jsonStr2 += @"*" + subItem.TagName + "*: {*value*: " + subItem.TagValue + ", *uom*: *" + subItem.TagUOM + "*}" + Environment.NewLine;
                    jsonStr2 += (subItemIteration < subItemCount) ? ("," + Environment.NewLine) : String.Empty;
                    subItemCount++;
                }

            jsonStr2 += Environment.NewLine + "}" + Environment.NewLine + Environment.NewLine + "}";

            string jsonStr3 = @"]
                                    }
                                }";

            string jsonString = jsonStr1 + jsonStr2 + jsonStr3;
            jsonString = jsonString.Replace('\'', '\"');
            jsonString = jsonString.Replace('*', '\"');
            jsonString = jsonString.Replace("\n", "").ToString();
            jsonString = jsonString.Replace("\t", "").ToString();
            jsonString = jsonString.Replace("\r", "").ToString();
            jsonString = jsonString.Trim('\t');
            return jsonString;
        }

        public static string AddExcelImportAsResponse(List<ExcelTagInput> excelInput)
        {
            string jsonStr1 = @"{  
                                    'header': {
                                                'messageType':'resourceState', 
                                                'version': '1.0',
	                                            'dateMsg':	'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"',                                                
	                                     },
	                                'body':{
                                                'resourceState': [";

            string jsonStr2 = "";
            foreach (ExcelTagInput tagIn in excelInput)
            {
                jsonStr2 += @"{
                              'id': '" + tagIn.ResourceId + @"',
			                  'updateDataDate': '" + tagIn.TagCreationDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
						      'tags': {
                    ";
                jsonStr2 += "*" + tagIn.TagName + "*:" + "{*value*:*" + tagIn.TagValue + "*,*uom*:*" + tagIn.TagUOM + "*,*ExtId*:*" + tagIn.TagId + "*" + "}";
                jsonStr2 += Environment.NewLine + "}" + Environment.NewLine + Environment.NewLine + "},";
            }
            string jsonStr3 = @"]
                                    }
                                }";

            string jsonString = jsonStr1 + jsonStr2 + jsonStr3;
            jsonString = jsonString.Replace('\'', '\"');
            jsonString = jsonString.Replace('*', '\"');
            jsonString = jsonString.Replace("\n", "").ToString();
            jsonString = jsonString.Replace("\t", "").ToString();
            jsonString = jsonString.Replace("\r", "").ToString();
            jsonString = jsonString.Trim('\t');
            return jsonString;
        }
    }
}