using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class FileTab
    {
        public int FileId { get; set; }
        public int? FileNo { get; set; }
        public int? Marla { get; set; }
        public int? Sarsai { get; set; }
        public int? Area { get; set; }
        public long? Amount { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? Site { get; set; }
        public int? TenantId { get; set; }
        public int? ProjectId { get; set; }
        public int? BlockId { get; set; }
    }
}
