using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Models
{
    public class OrderMetric
    {
        public Decimal totalCost { get; set; }

        public DateTime purchaseDate { get; set; }

        public Decimal bicycleID { get; set; }

        public Decimal customerID { get; set; }

        
    }
}
