using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Filter
    {
        public int? RecordNo { get; set; }
        public string Area { get; set; }
        public int? Marla { get; set; }
        public int? Quantity { get; set; }
        public int? PlatterId { get; set; }
        public string Type { get; set; }
        public string Project { get; set; }
    }
}
