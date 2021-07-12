using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.Models
{
    public class TagRegistrationModel
    {
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public string TagName { get; set; }
        public string TagUOM { get; set; }
    }
}