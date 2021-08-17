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
            string connectionStr = @"Data Source=LP5-SBT25-IND\MSSQLSERVER01;Initial Catalog=RM_K_DB_V2.1;Integrated Security=True";
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
                            value += " AND tag.Id = " + tagItem.tagId + " AND tag.Name = '" + tagItem.name + "' ";
                        else if (!String.IsNullOrEmpty(tagItem.tagId) && String.IsNullOrEmpty(tagItem.name))
                            value += " AND tag.Id = " + tagItem.tagId + " ";
                        else if (String.IsNullOrEmpty(tagItem.tagId) && !String.IsNullOrEmpty(tagItem.name))
                            value += " AND tag.Name = '" + tagItem.name + "' ";
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
                    cmd.CommandText = @"select tag.ResourceId as ResourceId, res.Type as Type, tag.Name as Name ,tag.UOM as UOM,
                                        tag.Value as Value,tag.CreationDate as Date,tag.Id as TagId,tag.Name as TagName from
										ResourceTable as res LEFT JOIN
                                        TagTable as tag ON res.Id = tag.ResourceId
										Left Join ResourceAndTagRegistrationTable as reg ON
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


        #region Add Tag Value
        public static void AddTagValue(Models.ResourceWithValue resourceTag)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[TagTable](Id,Name,Value,UOM,CreationDate,ResourceId) " +
                        "Values(" + resourceTag.TagId + ",'" + resourceTag.TagName + "','" + resourceTag.TagValue + "','" + resourceTag.TagUOM +
                        "','" + resourceTag.TagCreationDate + "'," + resourceTag.ResourceId + ")";
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        #endregion


        #region Add Excel File Resource Tag
        public static string AddExcelResource(List<ExcelTagInput> resourceTag)
        {
            string alreadyRegisteredResource = "";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    List<ExcelTagInput> filteredIp = new List<ExcelTagInput>();
                    foreach (ExcelTagInput tag in resourceTag)
                    {
                        cmd.CommandText = "Select COUNT(*) as Number from [RM_K_DB_V2.1].[dbo].[TagTable] where ResourceId = " + tag.ResourceId + " AND Id = " + tag.TagId +"";
                        var res = cmd.ExecuteScalar();
                        if (((int)res) == 1)
                        {                            
                            alreadyRegisteredResource += "-(Id:-" + tag.ResourceId + ",Tag:-" + tag.TagId + ")";                            
                        }
                        else
                        {
                            cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[TagTable](Id,Name,Value,UOM,CreationDate,ResourceId) " +
                        "Values(" + tag.TagId + ",'" + tag.TagName + "','" + tag.TagValue + "','" + tag.TagUOM +
                        "','" + tag.TagCreationDate + "'," + tag.ResourceId + ")";
                            cmd.ExecuteNonQuery();
                            filteredIp.Add(tag);
                        }
                    }

                    List<ExcelTagInput> ipList = new List<ExcelTagInput>();

                    foreach (ExcelTagInput tag in resourceTag)
                    {
                        cmd.CommandText = "Select COUNT(*) as Number from [RM_K_DB_V2.1].[dbo].[ResourceAndTagRegistrationTable] where ResourceId = " + tag.ResourceId + " AND TagId = " + tag.TagId + "";
                        var res = cmd.ExecuteScalar();
                        if (((int)res) == 1)
                        {
                            ipList.Add(tag);                            
                        }
                        else
                        {
                            cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[ResourceAndTagRegistrationTable](TypeName,TypeId,TagName,ResourceId,ResourceName) " +
                        "Values('" + tag.TypeName + "'," + tag.TypeId + ",'" + tag.TagName + "'," + tag.ResourceId +
                        ",'" + tag.ResourceName + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }

                    //foreach (ExcelTagInput tag in ipList)
                    //{
                    //    cmd.CommandText = "Insert into [RM_K_DB_V2.1].[dbo].[TagTable](Id,Name,Value,UOM,CreationDate,ResourceId) " +
                    //    "Values(" + tag.TagId + ",'" + tag.TagName + "','" + tag.TagValue + "','" + tag.TagUOM +
                    //    "','" + tag.TagCreationDate + "'," + tag.ResourceId + ")";
                    //    cmd.ExecuteNonQuery();
                    //}

                    string jsonPayload = ModelDataConversion.AddExcelImportAsResponse(filteredIp);
                    KafkaService.PostExcelResource(jsonPayload);
                }
                con.Close();
            }
            return alreadyRegisteredResource;
        }
        #endregion

    }
}