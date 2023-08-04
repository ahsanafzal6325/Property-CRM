using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZameenCRM.Models
{
    public class SignUpVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConPassword { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}
