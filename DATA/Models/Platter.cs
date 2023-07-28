using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Platter
    {
        public int RecNo { get; set; }
        public int? PlatterNo { get; set; }
        public string Description { get; set; }
        public int? Siteid { get; set; }
        public long? ActualAmount { get; set; }
        public long? RebateAmount { get; set; }
        public long? NetAmount { get; set; }
        public int? TotalAreaSize { get; set; }
        public bool? IsActive { get; set; }
    }
}
