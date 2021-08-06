using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.Models
{
    public class ResourceGetResponse3DXModel
    {
        public Header header { get; set; }
        public Body body { get; set; }

        public class Header
        {
            public SourceRequest sourceRequest { get; set; }
            public string messageType { get; set; }
            public string version { get; set; }
            [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd HH:mm:ss")]
            public DateTime dateMsg { get; set; }
        }

        public class SourceRequest
        {
            public int requestId { get; set; }
            public string requestType { get; set; }
            public string version { get; set; }
        }

        public class Body
        {
            public ResourceState[] resourceState { get; set; }
        }

        public class ResourceState
        {
            public string id { get; set; }
            [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd HH:mm:ss")]
            public DateTime updateDataDate { get; set; }
            public Tags[] tags { get; set; }
        }

        public class Tags
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string value { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string uom { get; set; }
        }
    }
}