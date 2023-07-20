using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? TenantId { get; set; }
        public int? SiteId { get; set; }
    }
}
