using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Bikeshop_Project.Validation
{
    // Class is used to validate zip codes
    public class ZipCodeValidation : ValidationAttribute
    {
        private Regex reg = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");

        /// <summary>
        /// Validate that a zip code is of the proper format
        /// </summary>
        /// <param name="value">zip code</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            string zipCode = "";

            try
            {
                zipCode = value.ToString();
            }
            // if converting user input to string throws an error, it is obviouslt not a valid zip code, return false
            catch (Exception)
            {
                return false;
            }

            // if user input matches the pattern, it is a phone number, return true
            if (reg.IsMatch(zipCode))
                return true;
            else
                return false;
        }
    }
}
