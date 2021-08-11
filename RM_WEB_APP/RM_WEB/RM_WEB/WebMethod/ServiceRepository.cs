using Newtonsoft.Json;
using RM_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace RM_WEB.WebMethod
{
    public class ServiceRepository
    {
        public static List<Models.Type> GetTypeList()
        {
            List<Models.Type> responseObj = new List<Models.Type>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync($"api/GetTypeList/").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resourceJsonString = response.Content.ReadAsStringAsync().Result;
                        var deserialized = JsonConvert.DeserializeObject(resourceJsonString, typeof(List<Models.Type>));
                        responseObj = (List<Models.Type>)deserialized;
                        responseObj.Insert(0, new Models.Type() { Id = -9999, Name = "Choose One Type" });
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return responseObj;
        }

        public static List<ResourceModel> GetResourceDetails()
        {
            List<ResourceModel> responseObj = new List<ResourceModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync($"api/GetResourceDetails").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resourceJsonString = response.Content.ReadAsStringAsync().Result;
                        var deserialized = JsonConvert.DeserializeObject(resourceJsonString, typeof(List<ResourceModel>));
                        responseObj = (List<ResourceModel>)deserialized;
                        responseObj.Insert(0, new Models.ResourceModel() { ResourceId = -9999, ResourceName = "Choose One Resource" });
                    }
                }
            }
            catch (Exception ex) { }
            return responseObj;
        }

        public static List<Tag> GetTagDetails(long resourceId)
        {
            List<Tag> responseObj = new List<Tag>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync($"api/GetTagDetails?resourceId={resourceId}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resourceJsonString = response.Content.ReadAsStringAsync().Result;
                        var deserialized = JsonConvert.DeserializeObject(resourceJsonString, typeof(List<Tag>));
                        responseObj = (List<Tag>)deserialized;
                        responseObj.Insert(0, new Models.Tag() { TagResourceId = -9999, TagName = "Choose One Tag" });
                    }
                }
            }
            catch (Exception ex) { }
            return responseObj;
        }

        public static List<Tag> GetTagNamesDetails()
        {
            List<Tag> responseObj = new List<Tag>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync($"api/GetTagNameDetails").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resourceJsonString = response.Content.ReadAsStringAsync().Result;
                        var deserialized = JsonConvert.DeserializeObject(resourceJsonString, typeof(List<Tag>));
                        responseObj = (List<Tag>)deserialized;
                        responseObj.Insert(0, new Models.Tag() { TagResourceId = -9999, TagName = "Choose One Tag" });
                    }
                }
            }
            catch (Exception ex) { }
            return responseObj;
        }

        public static void SaveTagName(Tag tagModel)
        {

        }
    }
}