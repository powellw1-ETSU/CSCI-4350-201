using System;
using System.Collections.Generic;
using System.Text;
using Bikeshop_Project.Validation;
using Xunit;

namespace Bikeshop_Project.Tests
{
    public class ZipCodeValidationTests
    {
        private readonly ZipCodeValidation _validation;

        public ZipCodeValidationTests()
        {
            _validation = new ZipCodeValidation();
        }

        /// <summary>
        /// This will test ZipCodeValidation's method "IsValid" to ensure it is correctly
        /// identifying correct zipcodes. All InlineData are of valid format and should return true
        /// </summary>
        /// <param name="zipCode">the zip code</param>
        [Theory]
        [InlineData("37645")]
        [InlineData("81243")]
        [InlineData("12345")]
        [InlineData("33801-1101")]
        [InlineData("12345-6789")]
        public void ZipCode_IsValid_True(string zipCode)
        {
            Assert.True(_validation.IsValid(zipCode));
        }

        /// <summary>
        /// This method will ensure that all invalid zip Codes are correctly detected by ZipCodeValidation
        /// </summary>
        /// <param name="zipCode">the zip code</param>
        [Theory]
        [InlineData("not a zip code")]
        [InlineData("1234")]
        [InlineData("123456")]
        [InlineData("1234a")]
        [InlineData("12345-10000")]
        [InlineData("12345-aaaa")]
        public void ZipCode_IsValid_False(string zipCode)
        {
            Assert.False(_validation.IsValid(zipCode));
        }
    } 
}
