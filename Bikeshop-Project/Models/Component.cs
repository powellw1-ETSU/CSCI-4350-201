namespace Bikeshop_Project.Models
{
    public class Component
    {
        public decimal COMPONENTID { get; set; }

        public decimal MANUFACTURERID { get; set; }

        public string PRODUCTNUMBER { get; set; }

        public string ROAD { get; set; }

        public string CATEGORY { get; set; }

        public double LENGTH { get; set; }

        public double HEIGHT { get; set; }

        public double WIDTH { get; set; }

        public double WEIGHT { get; set; }

        public decimal YEAR { get; set; }

        public decimal ENDYEAR { get; set; }

        public string DESCRIPTION { get; set; }

        public decimal LISTPRICE { get; set; }

        public decimal ESTIMATEDCOST { get; set; }

        public double QUANTITYONHAND { get; set; }
    }
}
