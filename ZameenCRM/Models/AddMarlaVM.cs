using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZameenCRM.Models
{
    public class AddMarlaVM
    {
        public int MarlaName { get; set; }
        public int? PlanId { get; set; }
        public long? MarlaPrice { get; set; }
    }
}
