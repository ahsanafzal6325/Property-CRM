using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Platter
    {
        public int RecId { get; set; }
        public string PlatterName { get; set; }
        public int? Area { get; set; }
        public int? Quantity { get; set; }
        public int? Marla { get; set; }
        public int? PlatterId { get; set; }
        public string Type { get; set; }
        public int? ProjectId { get; set; }
        public int? RebutAmount { get; set; }
        public int? SiteId { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? TenantId { get; set; }
    }
}
