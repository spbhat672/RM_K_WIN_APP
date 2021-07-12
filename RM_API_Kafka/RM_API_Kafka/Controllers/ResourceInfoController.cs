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
        [System.Web.Http.Route("ResourceApi")]
        public HttpResponseMessage ResourceApi([FromBody] ResourceGetRequestModel model)
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetResource")]
        public HttpResponseMessage GetResource([FromUri]long? id)
        {
            try
            {
                List<ResourceWithValue> resourceList = ResourceRepository.GetResourceInfo(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resourceList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching resource Information");
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostResource")]
        public HttpResponseMessage PostResource([FromBody]ResourceAddModel model)
        {
            try
            {
                List<ResourceWithValue> resList = ModelDataConversion.GetResourceListForDataInsert(model);
                ResourceRepository.AddResourceInfo(resList);
                KafkaService.PostResource(resList);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)            
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/PutResource")]
        public HttpResponseMessage PutResource([FromBody]ResourceAddModel model)
        {
            try
            {
                List<ResourceWithValue> resList = ModelDataConversion.GetResourceListForDataUpdate(model);
                ResourceRepository.UpdateResourceInfo(resList);
                //KafkaService.PostResource(resList);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, ex);
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/DeleteResource")]
        public HttpResponseMessage DeleteResource([FromUri] long id)
        {
            try
            {
                ResourceRepository.DeleteResourceInfo(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, ex);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetTypeList")]
        public HttpResponseMessage GetTypeList()
        {
            try
            {
                var typeList = new List<Models.Type>();
                typeList = ResourceRepository.GetTypeInfo();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, typeList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching type data");
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetResourceDetails")]
        public HttpResponseMessage GetResourceDetails()
        {
            try
            {
                List<ResourceModel> resourceList = ResourceRepository.GetResourceDetails();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resourceList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching resource Information");
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetTagDetails")]
        public HttpResponseMessage GetTagDetails([FromUri] long resourceId)
        {
            try
            {
                List<Tag> resourceList = ResourceRepository.GetTagDetails(resourceId);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resourceList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching resource Information");
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetStatusList")]
        public HttpResponseMessage GetStatusList()
        {
            try
            {
                var statusList = new List<Models.Status>();
                statusList = ResourceRepository.GetStatusInfo();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, statusList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching status data");
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostTagValue")]
        public HttpResponseMessage PostTagValue([FromBody] ResourceWithValue model)
        {
            try
            {
                ResourceRepository.AddTagValue(model);
                //KafkaService.PostResource(new List<ResourceWithValue>() { model});
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostType")]
        public HttpResponseMessage PostType([FromBody]Models.Type model)
        {
            try
            {
                ResourceRepository.AddTypeInfo(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostStatus")]
        public HttpResponseMessage PostStatus([FromBody] Models.Status model)
        {
            try
            {
                ResourceRepository.AddStatusInfo(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostRegisterTag")]
        public HttpResponseMessage PostRegisterTag([FromBody] TagRegistrationModel model)
        {
            try
            {
                ResourceRepository.RegisterTag(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostResourceDetails")]
        public HttpResponseMessage PostResourceDetails([FromBody] ResourceModel model)
        {
            try
            {
                ResourceRepository.AddResource(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, 202);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/PostIsResourceExist")]
        public HttpResponseMessage PostIsResourceExist([FromBody]long id)
        {
            try
            {
                bool isResourceExist = ResourceRepository.CheckForResourceExistance(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, isResourceExist);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Server - Error Fetching resource Information");
            }
        }
    }
}