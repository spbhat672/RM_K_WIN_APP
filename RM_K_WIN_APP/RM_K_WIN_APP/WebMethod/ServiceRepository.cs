using Newtonsoft.Json;
using RM_K_WIN_APP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RM_K_WIN_APP.WebMethod
{
    public static class ServiceRepository
    {
        public static List<ResourceWithValue> GetAllResource()
        {
            List<ResourceWithValue> responseObj = new List<ResourceWithValue>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync($"api/GetResource?id={null}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resourceJsonString = response.Content.ReadAsStringAsync().Result;
                        var deserialized = JsonConvert.DeserializeObject(resourceJsonString, typeof(List<ResourceWithValue>));
                        responseObj = (List<ResourceWithValue>)deserialized;
                    }
                }
            }
            catch (Exception ex) { }
            return responseObj;
        }

        public static void SaveResource(ResourceAddModel resModel)
        {
            try
            {
                ResourceWithValue responseObj = new ResourceWithValue();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/PostResource/", resModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("successfully added");
                    }
                    else
                        MessageBox.Show("Error Save data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorrr  " + ex.Message);
            }
        }

        public static bool UpdateResource(ResourceAddModel resModel)
        {
            bool isUpdateSuccess = false;
            ResourceWithValue responseObj = new ResourceWithValue();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.PutAsJsonAsync($"api/PutResource/", resModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        isUpdateSuccess = true;
                    }
                }
            }
            catch (Exception ex) { }
            return isUpdateSuccess;
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

        public static bool DeleteResource(long tagId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.DeleteAsync("api/DeleteResource?id=" + tagId).Result;

                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex) { return false; }
        }

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

        public static List<Status> GetStatusList()
        {
            List<Status> responseObj = new List<Status>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/GetStatusList/").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var resourceJsonString = response.Content.ReadAsStringAsync().Result;
                        var deserialized = JsonConvert.DeserializeObject(resourceJsonString, typeof(List<Models.Status>));
                        responseObj = (List<Models.Status>)deserialized;
                        responseObj.Insert(0, new Models.Status() { Id = -9999, Name = "Choose One Status" });
                    }
                }
            }
            catch (Exception ex) { }
            return responseObj;
        }

        public static void SaveType(Models.Type typeModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/PostType/", typeModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("successfully added");
                    }
                    else
                        MessageBox.Show("Error Save data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorrr  " + ex.Message);
            }
        }

        public static void SaveStatus(Models.Status statusModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/PostStatus/", statusModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("successfully added");
                    }
                    else
                        MessageBox.Show("Error Save data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorrr  " + ex.Message);
            }
        }

        public static void AddResource(Models.ResourceModel resource)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/PostResourceDetails/", resource).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("successfully added resource");
                    }
                    else
                        MessageBox.Show("Error Save data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorrr  " + ex.Message);
            }
        }

        public static void AddTagValue(Models.ResourceWithValue resource)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/PostTagValue/", resource).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("successfully added tag Value");
                    }
                    else
                        MessageBox.Show("Error Save data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorrr  " + ex.Message);
            }
        }

        public static void RegisterNewTag(Models.TagRegistrationModel tagRegModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/PostRegisterTag/", tagRegModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("successfully Registered new Tag");
                    }
                    else
                        MessageBox.Show("Error Save data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorrr  " + ex.Message);
            }
        }

        public static bool IsResourceExist(long resourceId)
        {
            bool isResourceExist = true;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44361/" + "/ResourceInfo/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync($"api/PostIsResourceExist/", resourceId).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        if (response.Content.ReadAsStringAsync() != null && response.Content.ReadAsStringAsync().Result != null)
                        {
                            isResourceExist = Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                    else
                        MessageBox.Show("Error from Server");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errorrr  " + ex.Message);
            }
            return isResourceExist;
        }
    }
}
