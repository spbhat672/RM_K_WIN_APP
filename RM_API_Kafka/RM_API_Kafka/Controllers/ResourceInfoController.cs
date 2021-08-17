using Newtonsoft.Json;
using RM_API_Kafka.Models;
using RM_API_Kafka.WebMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RM_API_Kafka.Controllers
{
    [System.Web.Http.RoutePrefix("ResourceInfo")]
    public class ResourceInfoController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ResourceOperationInfo_WS")]
        public HttpResponseMessage ResourceOperationInfo_WS([FromBody] ResourceGetRequestModel model)
        {
            try
            {
                ResourceGetRequestModel myModel = model;
                var resourceList = new List<Resource3DXWithValue>();
                resourceList = ResourceRepository.GetResourceInfoFor3ds(model);
                var response = ModelDataConversion.DataModelToGetResponseModel(myModel, resourceList);
                var obj = JsonConvert.DeserializeObject<ResourceGetResponse3DXModel>(response);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, obj);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching resource Information");
            }
        }



        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/ResourceOperationInfo_Kafka")]
        public HttpResponseMessage ResourceOperationInfo_Kafka([FromBody] ResourceWithValue model)
        {
            try
            {
                    ResourceRepository.AddTagValue(model);
                    KafkaService.PostResource(new List<ResourceWithValue>() { model });
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
        }




        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostResourceAndTag")]
        public HttpResponseMessage PostResourceAndTag([FromBody] List<ExcelTagInput> reslist)
        {
            try
            {
                String OPMessage = ResourceRepository.AddExcelResource(reslist);
                KafkaService.PostResource(reslist);
                if (OPMessage.Length == 0)
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
                else
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, OPMessage);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
        }




    }
}