using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.Models
{
    public class Resource3DXWithValue
    {
        public long ResourceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string UOM { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
    }
}