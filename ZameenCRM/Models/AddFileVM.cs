using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZameenCRM.Models
{
    public class AddFileVM
    {
        public int FileId { get; set; }
        public int? FileNo { get; set; }
        public int? Marla { get; set; }
        public int? Sarsai { get; set; }
        public int Area { get; set; }
        public int? Amount { get; set; }
        public int? EnterBy { get; set; }
        public int? ProjectId { get; set; }
        public int? BlockId { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? Site { get; set; }
        public int? TenantId { get; set; }
        public int? TypeId { get; set; }
    }
}
