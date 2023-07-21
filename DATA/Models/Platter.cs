using System;
using System.Collections.Generic;

namespace DATA.Models
{
    public partial class Platter
    {
        public int PlatterId { get; set; }
        public string PlatterName { get; set; }
        public int? PlatterDiscount { get; set; }
        public int? PlatterAmount { get; set; }
    }
}
