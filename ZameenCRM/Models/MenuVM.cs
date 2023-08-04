using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZameenCRM.Models
{
    public class MenuVM
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public int? Site { get; set; }
        public int? TenantId { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EdiDate { get; set; }
    }
}
