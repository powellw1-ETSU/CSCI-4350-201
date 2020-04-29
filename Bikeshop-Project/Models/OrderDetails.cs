using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Models
{
    public class OrderDetails
    {

        public Decimal paintID { get; set; }

        public String letterStyle { get; set; }

        public String modelType { get; set; }


        public Decimal kitQuantity { get; set; }
    }
}
