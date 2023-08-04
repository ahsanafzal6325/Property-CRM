using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public int? UserTypeId { get; set; }
        public int? DesignationId { get; set; }
        public bool? Remember { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? SiteId { get; set; }
        public int? TenantId { get; set; }
        public bool? IsActive { get; set; }
    }
}
