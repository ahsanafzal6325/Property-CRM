using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? EnterBy { get; set; }
        public DateTime? EnterDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
