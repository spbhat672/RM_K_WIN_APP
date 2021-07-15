using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.Models
{
    public class Tag
    {
        public string TagName { get; set; }
        public long TagResourceId { get; set; }
        public long TagId { get; set; }
    }
}