using CoinJarGK.Application.Common.Exceptions;
using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CoinJarGK.Application.UnitTests.Common.Exceptions
{
    public class  CustomValidationExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new CustomValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Test]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Amount", "must be greater than 0"),
            };

            var actual = new CustomValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Amount" });
            actual["Amount"].Should().BeEquivalentTo(new string[] { "must be greater than 0" });
        }
    }
}
