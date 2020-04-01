using System;
using Bikeshop_Project.Validation;

namespace Bikeshop_Project.Models
{
    public class City
    {
        public string CityId { get; set; }

        [ZipCodeValidation(ErrorMessage = "Please enter a zip code of correct US format")]
        public string ZIPCODE { get; set; }

        public string CITY { get; set; }

        public string STATE { get; set; }

        public string AREACODE { get; set; }

        public decimal POPULATION1990 { get; set; }

        public decimal POPULATION1980 { get; set; }

        public string COUNTRY { get; set; }

        public double LATITUDE { get; set; }

        public double LONGITUDE { get; set; }

        public double POPULATIONCDF { get; set; }

        public bool ShowCityId => !string.IsNullOrEmpty(CityId);
    }
}

