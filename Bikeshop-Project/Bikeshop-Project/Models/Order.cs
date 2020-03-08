using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Models
{
    public class Order
    {
        public decimal OrderID { get; set; }

        public decimal bike_quantity { get; set; }

        public decimal bike_price { get; set; }

        public decimal component_quantity { get; set; }

        public decimal component_price { get; set; }


    }

}
