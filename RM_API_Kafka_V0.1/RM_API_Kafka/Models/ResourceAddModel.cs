using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM_API_Kafka.Models
{
    public class ResourceAddModel
    {
        public long? ResourceId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public long? PositionTagId { get; set; }
        public string PositionValue { get; set; }
        public string PositionUOM { get; set; }
        public DateTime PositionCreationDate { get; set; }
        public long? OrientationTagId { get; set; }
        public string OrientationValue { get; set; }
        public string OrientationUOM { get; set; }
        public DateTime OrientationCreationDate { get; set; }
        public long? SpeedTagId { get; set; }
        public string SpeedValue { get; set; }
        public string SpeedUOM { get; set; }
        public DateTime SpeedCreationDate { get; set; }
        public long? StatusTagId { get; set; }
        public string StatusValue { get; set; }
        public DateTime StatusCreationDate { get; set; }
    }
}