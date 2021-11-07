using CoinJarGK.Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace CoinJarGK.Application.UnitTests.Common.Exceptions
{
    public class VolumeExceedExceptionTests
    {
        [Test]
        public void ShouldCreateSingleElementDetailDictionary() 
        {
            var actual = new CoinJarVolumeExceedException(42).Details;

            actual.Count.Should().Be(1);
            actual.Keys.Should().BeEquivalentTo(new string[] { "Volume" });
        }
    }
}
