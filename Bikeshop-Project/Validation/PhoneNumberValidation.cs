using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Bikeshop_Project.Validation
{
    /// <summary>
    /// Class is used to validate phone numbers
    /// </summary>
    public class PhoneNumberValidation : ValidationAttribute
    {
        private Regex reg = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");


        /// <summary>
        /// Method checks to if a phone number is valid using the regex pattern above
        /// </summary>
        /// <param name="value">phone number entered by the user</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            string phoneNumber = "";

            try
            {
                phoneNumber = value.ToString();
            }
            // if converting user input to string throws an error, it is obviously not a valid phone #, return false
            catch (Exception)
            {
                return false;
            }

            // if user input matches the pattern, it is a phone number, return true
            if (reg.IsMatch(phoneNumber))
                return true;
            else
                return false;
        }
    }
}
