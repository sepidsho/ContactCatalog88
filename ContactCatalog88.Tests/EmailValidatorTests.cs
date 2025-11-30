using ContactCatalog88.Services;
using ContactCatalog88.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;

namespace ContactCatalog88.ContactCatalog88.Tests
{


    
        public class EmailValidatorTests
        {
            [Theory]
            [InlineData("test@example.com")]
            [InlineData("anna@domain.se")]
            public void IsValidEmail_Should_Return_True_For_Valid_Emails(string email)
            {
                var result = EmailValidator.IsValidEmail(email);
                Assert.True(result);
            }

            [Theory]
            [InlineData("invalid-email")]
            [InlineData("test@")]
            [InlineData("@domain.com")]
            [InlineData("")]
            [InlineData(null)]
            public void IsValidEmail_Should_Return_False_For_Invalid_Emails(string email)
            {
                var result = EmailValidator.IsValidEmail(email);
                Assert.False(result);
            }
        }
    }

}
}
