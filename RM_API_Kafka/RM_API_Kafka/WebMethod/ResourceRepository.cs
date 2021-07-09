using RM_API_Kafka.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.WebMethod
{
    public class ResourceRepository
    {
        private static string conString = ConfigurationManager.ConnectionStrings["conString"].ToString();

        #region Get Resource Information for 3ds client
        public static List<Resource3DXWithValue> GetResourceInfoFor3ds(ResourceGetRequestModel model)
        {
            string connectionStr = @"Data Source=LP5-SBT25-IND\MSSQLSERVER01;Initial Catalog=RM_K_DB_V2;Integrated Security=True";
            List<Resource3DXWithValue> resourceList = new List<Resource3DXWithValue>();
            string filter = " where ";
            List<string> filterValue = new List<string>();
            if (model.body.itemSet.items.Length > 0)
            {
                foreach (var resItem in model.body.itemSet.items)
                {
                    long extReourceId = Convert.ToInt64(resItem.id);
                    foreach (var tagItem in resItem.tags)
                    {
                        string value = "(tag.ResourceId = " + extReourceId + " ";
                        if (!String.IsNullOrEmpty(tagItem.tagId) && !String.IsNullOrEmpty(tagItem.name))
                            value += " AND tag.Id = " + tagItem.tagId + " AND reg.TagName = '" + tagItem.name + "' ";
                        else if (!String.IsNullOrEmpty(tagItem.tagId) && String.IsNullOrEmpty(tagItem.name))
                            value += " AND tag.Id = " + tagItem.tagId + " ";
                        else if (String.IsNullOrEmpty(tagItem.tagId) && !String.IsNullOrEmpty(tagItem.name))
                            value += " AND reg.TagName = '" + tagItem.name + "' ";
                        value += ")";
                        filterValue.Add(value);
                    }
                }
            }

            filter = (filterValue != null && filterValue.Count > 0) ? (filter + String.Join(" OR ", filterValue)) : String.Empty;
            string dateFilter = model.body.dates.Length > 0 ? " AND tag.CreationDate IN ('" + String.Join("','", model.body.dates) + "')" : String.Empty;
            filter += dateFilter;

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"select tag.ResourceId as ResourceId, reg.TypeName as Type, tag.Name as Name ,reg.TagUOM as UOM,
                                        tag.Value as Value,tag.CreationDate as Date from
                                        TagTable as tag Left Join ResourceAndTagRegistrationTable as reg ON
                                        reg.TagId = tag.Id" + filter;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            resourceList.Add(
                                new Resource3DXWithValue
                                {
                                    ResourceId = Convert.ToInt64(row["ResourceId"]),
                                    Name = Convert.ToString(row["Name"]),
                                    Type = Convert.ToString(row["Type"]),
                                    UOM = Convert.ToString(row["UOM"]),
                                    Value = Convert.ToString(row["Value"]),
                                    Date = Convert.ToString(row["Date"])
                                }
                                );
                        }
                    }
                }
                con.Close();
            }
            return resourceList;
        }
        #endregion

        #region Add Resource Information
        public static long AddResourceInfo(List<Models.ResourceWithValue> resList)
        {
            long resourceID = 0;
            int loopCount = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;

                    foreach(ResourceWithValue model in resList)
                    {
                        if(loopCount == 0)
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "Insert into [RM_K_DB_V2].[dbo].[ResourceTable](Id,Name,Type,TypeId,CreationDate) Values("
                               + model.ResourceId + ",'" + model.Name + "','" + model.Type + "'," + model.TypeId + ",'" + model.TagCreationDate + "')";
                            cmd.ExecuteNonQuery();
                            loopCount++;
                        }

                        cmd.CommandText = "SELECT TOP 1 Id FROM [RM_K_DB_V2].[dbo].[ResourceTable] ORDER BY ID DESC";
                        long lastResourceId = (long)cmd.ExecuteScalar();

                        cmd.CommandText = "select Count(*) from  [RM_K_DB_V2].[dbo].[ResourceAndTagRegistrationTable]";
                        var tagCount = cmd.ExecuteScalar();
                        long tagId = Convert.ToInt64(tagCount) + 1;

                        cmd.CommandText = "Insert into [RM_K_DB_V2].[dbo].[TagTable](Id,Name,Value,UOM,CreationDate,ResourceId) Values(" + tagId + ",'"
                            + model.TagName + "','" + model.TagValue + "','" + model.TagUOM + "','" + model.TagCreationDate + "'," + lastResourceId + ")";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT TOP 1 Id FROM [RM_K_DB_V2].[dbo].[TagTable] ORDER BY ID DESC";
                        long lastTagId = (long)cmd.ExecuteScalar();

                        cmd.CommandText = "Insert into [RM_K_DB_V2].[dbo].[ResourceAndTagRegistrationTable](TypeName,TypeId,TagName,TagId,TagUOM) Values('"
                            + model.Type + "'," + model.TypeId + ",'" + model.TagName + "'," + lastTagId + ",'" + model.TagUOM + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "SELECT TOP 1 Id FROM [3DX_RMkafkaDB].[dbo].[ResourceTable] ORDER BY ID DESC";
                        resourceID = (long)cmd.ExecuteScalar();
                    }                    
                }
                con.Close();
            }
            return resourceID;
        }
        #endregion

        #region Get Resource Information
        public static List<ResourceWithValue> GetResourceInfo(long? id)
        {
            List<ResourceWithValue> resourceList = new List<ResourceWithValue>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select tag.ResourceId,r.Name,r.TypeId,r.Type,tag.Id as TagId,tag.Name as TagName,tag.Value as TagValue,tag.UOM as TagUOM,tag.CreationDate as TagCreationDate" +
                                      " from [RM_K_DB_V2].[dbo].[ResourceTable] r left join [RM_K_DB_V2].[dbo].[ResourceAndTagRegistrationTable] reg " +
                                      "on r.TypeId = reg.TypeId " +
                                      "left join [RM_K_DB_V2].[dbo].[TagTable] tag on reg.TagId = tag.Id ";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            resourceList.Add(
                                new ResourceWithValue
                                {

                                    ResourceId = Convert.ToInt64(row["ResourceId"]),
                                    Name = Convert.ToString(row["Name"]),
                                    TypeId = Convert.ToInt32(row["TypeId"]),
                                    Type = Convert.ToString(row["Type"]),                                                                        
                                    TagId = Convert.ToInt64(row["TagId"]),
                                    TagName = Convert.ToString(row["TagName"]),
                                    TagValue = Convert.ToString(row["TagValue"]),
                                    TagUOM = Convert.ToString(row["TagUOM"]),
                                    TagCreationDate = Convert.ToDateTime(row["TagCreationDate"])
                                }
                                );
                        }
                    }
                }
                con.Close();
            }
            if (id == null)
                return resourceList;
            else
                return new List<ResourceWithValue>() { resourceList.Find(x => x.TagId == id) };
        }
        #endregion

        #region Update Resource Information
        public static void UpdateResourceInfo(List<ResourceWithValue> resList)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;

                    foreach(ResourceWithValue model in resList)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Update [RM_K_DB_V2].[dbo].[TagTable] set Value = '" + model.TagValue + "' ,CreationDate = '" + model.TagCreationDate +
                             "' where Id = " + model.TagId + "";
                        cmd.ExecuteNonQuery();
                    }                   
                }
                con.Close();
            }
        }
        #endregion

        #region Delete Resource Information
        public static void DeleteResourceInfo(long id)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Delete from [RM_K_DB_V2].[dbo].[TagTable] where Id = " + id + "";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Delete from [RM_K_DB_V2].[dbo].[ResourceAndTagRegistrationTable] where TagId = " + id + "";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        #endregion

        #region Get Type Information
        public static List<Models.Type> GetTypeInfo()
        {
            List<Models.Type> typeList = new List<Models.Type>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from [RM_K_DB_V2].[dbo].[TypeTable]";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            typeList.Add(
                                new Models.Type
                                {
                                    Id = Convert.ToInt32(row["Id"]),
                                    Name = Convert.ToString(row["Name"])
                                });
                        }
                    }
                }
                con.Close();
            }
            return typeList;
        }
        #endregion

        #region Get Status Information
        public static List<Models.Status> GetStatusInfo()
        {
            List<Models.Status> statusList = new List<Models.Status>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from [RM_K_DB_V2].[dbo].[StatusTable]";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            statusList.Add(
                                new Models.Status
                                {
                                    Id = Convert.ToInt32(row["Id"]),
                                    Name = Convert.ToString(row["Name"])
                                });
                        }
                    }
                }
                con.Close();
            }
            return statusList;
        }
        #endregion

        #region Add Type Information
        public static void AddTypeInfo(Models.Type typeObj)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2].[dbo].[TypeTable](Id,Name) Values(" + typeObj.Id + ",'"+ typeObj.Name +"')";
                        cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        #endregion

        #region Add Status Information
        public static void AddStatusInfo(Models.Status statusObj)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2].[dbo].[StatusTable](Id,Name) Values(" + statusObj.Id + ",'" + statusObj.Name + "')";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        #endregion

        #region CheckForResourceExistance
        public static bool CheckForResourceExistance(long resourceId)
        {
            bool isResourceExist = false;
            using(SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Select Count(*) as count from [RM_K_DB_V2].[dbo].[ResourceTable] where Id = " + resourceId;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int count = Convert.ToInt32(dt.Rows[0][0]);
                        if (count == 1)
                            isResourceExist = true;
                    }
                }
            }
            return isResourceExist;
        }
        #endregion
    }
}