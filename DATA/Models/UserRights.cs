using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class UserRights
    {
        public int UserRightId { get; set; }
        public int? UserId { get; set; }
        public int? ParentId { get; set; }
        public int? MenuId { get; set; }
        public bool? IsActive { get; set; }
        public int? Site { get; set; }
        public int? TenantId { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
