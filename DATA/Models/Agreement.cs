using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Agreement
    {
        public int AgrId { get; set; }
        public int? FileId { get; set; }
        public int? ProjectId { get; set; }
        public int? BlockId { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? Site { get; set; }
        public int? TenantId { get; set; }
    }
}
