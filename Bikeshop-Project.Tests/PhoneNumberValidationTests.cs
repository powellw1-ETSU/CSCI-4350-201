using System;
using Xunit;
using Bikeshop_Project.Validation;

namespace Bikeshop_Project.Tests
{
    public class PhoneNumberValidationTests
    {
        private readonly PhoneNumberValidation _validation;
        public PhoneNumberValidationTests()
        {
            _validation = new PhoneNumberValidation();
        }

        /// <summary>
        /// This tests our phone number validation class's method (isVald) with a list of phone numbers that are valid
        /// and should be returned "True" and thus accepted by our program
        /// </summary>
        /// <param name="phoneNumber">phone number provided</param>
        [Theory]
        [InlineData("1234567890")]
        [InlineData("(123)4567890")]
        [InlineData("(123)456-7890")]
        [InlineData("(123) 456-7890")]
        [InlineData("123 456 7890")]
        [InlineData("123-456-7890")]
        [InlineData("(123)-456-7890")]
        public void PhoneNumber_IsValid_True(string phoneNumber)
        {
            Assert.True(_validation.IsValid(phoneNumber));
        }

        /// <summary>
        /// This tests the PhoneNumberValidation class's (IsValid) method to ensure that all incorrectly
        /// entered phone numbers will be detected as such and return false when validating
        /// </summary>
        /// <param name="phoneNumber">entered phone number</param>
        [Theory]
        [InlineData("this is not a phone number")]
        [InlineData("123456789")]
        [InlineData("1 2 3 4 5 6 7 8 9 0")]
        [InlineData("(123)_456_7890")]
        [InlineData("123-4&5-7890")]
        public void PhoneNumber_IsValid_False(string phoneNumber)
        {
            Assert.False(_validation.IsValid(phoneNumber));
        }
    }
}
