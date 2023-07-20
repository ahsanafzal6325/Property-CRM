using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZameenCRM.Models
{
    public class AddBlockVM
    {
        public string BlockName { get; set; }
        public string BlockAddress { get; set; }
        public int? Site { get; set; }
    }
}
