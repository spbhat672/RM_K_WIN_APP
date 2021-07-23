using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM_K_WIN_APP.Models
{
    public class ExcelTagInput
    {
        public long ResourceId { get; set; }
        public string   TagUOM { get; set; }
        public long TagId { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }
        public DateTime TagCreationDate { get; set; }

        public static ExcelTagInput FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            ExcelTagInput tagInputValues = new ExcelTagInput();
            tagInputValues.ResourceId = Convert.ToInt64(values[0].ToString());
            tagInputValues.TagId = Convert.ToInt64(values[2].ToString());
            tagInputValues.TagName = Convert.ToString(values[3]);
            tagInputValues.TagValue = Convert.ToString(values[4]);
            tagInputValues.TagCreationDate = Convert.ToDateTime(values[5]);
            return tagInputValues;
        }
    }
}
