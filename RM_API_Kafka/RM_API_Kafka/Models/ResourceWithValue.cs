using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.Models
{
    public class ResourceWithValue
    {
        public long ResourceId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public long TagId { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }
        public string TagUOM { get; set; }
        public DateTime TagCreationDate { get; set; }
    }
}