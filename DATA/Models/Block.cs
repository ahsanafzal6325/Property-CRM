using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Block
    {
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public string BlockAddress { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? Site { get; set; }
        public int? TenantId { get; set; }
        public int? SiteId { get; set; }
    }
}
