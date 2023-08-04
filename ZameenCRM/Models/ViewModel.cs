using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZameenCRM.Models
{
    public class ViewModel
    {
        public Project pro { get; set; }
        public Plans plan { get; set; }
        public Marla mar { get; set; }
        public Site site { get; set; }
        public Block block { get; set; }
        public FileTab file { get; set; }
        public Platter plat { get; set; }
        public Record rec { get; set; }
        public TypeTab type { get; set; }
    }
}
