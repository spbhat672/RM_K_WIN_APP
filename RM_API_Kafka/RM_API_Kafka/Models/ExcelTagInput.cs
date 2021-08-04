using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.Models
{
    public class ExcelTagInput
    {
        public long ResourceId { get; set; }
        public string TagUOM { get; set; }
        public long TagId { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }
        public DateTime TagCreationDate { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string ResourceName { get; set; }
    }
}