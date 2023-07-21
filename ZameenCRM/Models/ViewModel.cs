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
        public Site site { get; set; }
        public Block block { get; set; }
        public FileTab file { get; set; }
    }
}
