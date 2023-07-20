using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Dealer
    {
        public int DealerID { get; set; }
        public string DealerName { get; set; }
        public string DealerContact { get; set; }
        public string DealerCnic { get; set; }
        public string DealerAddress { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? Site { get; set; }
        public int? TenantId { get; set; }
    }
}
