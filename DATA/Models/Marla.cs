using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Marla
    {
        public int MarlaID { get; set; }
        public int? MarlName { get; set; }
        public int? PlanId { get; set; }
        public long? MarlaPrice { get; set; }
        public int? SiteId { get; set; }
        public int? TenantId { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
