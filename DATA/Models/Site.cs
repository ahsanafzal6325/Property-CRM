using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Site
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
