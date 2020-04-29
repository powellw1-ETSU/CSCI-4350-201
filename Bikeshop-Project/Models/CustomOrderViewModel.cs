using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Models
{
    public class CustomOrderViewModel
    {


        public decimal OrderID { get; set; }

        public decimal bike_quantity { get; set; }

        public decimal bike_price { get; set; }

        public decimal spare_kits_quantity { get; set; }

        public decimal spare_price { get; set; }

        public IEnumerable<Paint> Paints { get; set; }
           public IEnumerable<LetterStyle> LetterStyles { get; set; }
           public IEnumerable<ModelType> ModelTypes { get; set; }

    }
}
