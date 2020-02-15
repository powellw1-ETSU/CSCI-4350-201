using System;

namespace Bikeshop_Project.Models
{
    public class City
    {
        public string CityId { get; set; }

        public string ZIPCODE { get; set; }

        public string CITY { get; set; }

        public string STATE { get; set; }

        public string AREACODE { get; set; }

        public Decimal POPULATION1990 { get; set; }

        public Decimal POPULATION1980 { get; set; }

        public string COUNTRY { get; set; }

        public float LATITUDE { get; set; }

        public float LONGITUDE { get; set; }

        public float POPULATIONCDF { get; set; }

        public bool ShowCityId => !string.IsNullOrEmpty(CityId);
    }
}

