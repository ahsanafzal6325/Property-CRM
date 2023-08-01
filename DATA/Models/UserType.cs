using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class UserType
    {
        public int UserTypeId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int? Site { get; set; }
        public int? Tenantid { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
