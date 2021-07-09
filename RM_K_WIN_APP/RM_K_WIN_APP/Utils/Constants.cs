using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_K_WIN_APP.Utils
{
    public static class Constants
    {
        /// <summary>
        /// Dictionary<TagType,TagUOM>
        /// </summary>
        public static Dictionary<string, string> tagUOM = new Dictionary<string, string>()
       {
           {"Position","m" },
           {"Orientation","rad" },
           {"Speed","m/s" },
           {"Status",null }
       };

        /// <summary>
        /// tag names
        /// </summary>
        public static Dictionary<string, string> tagNames = new Dictionary<string, string>()
        {
            {"Choose one tag name","Choose one tag name"},
           {"Position","Position" },
           {"Orientation","Orientation" },
           {"Speed","Speed" },
           {"Status","Status" }
        };
    }
}
