using MinecraftServer.Common.General;
using MinecraftServerTests.Test_Utilities.Helper_Methods;

namespace MinecraftServerTests.Common.Data_Validation
{
    public class StringValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ")]
        [InlineData("\t\t\t")]
        [InlineData("Test Input")]
        public void CheckEmpty_StringInput_ThrowsNothingOrThrowsExpectedException(string? sStringCheck, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                StringValidator.CheckEmpty(sStringCheck);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
        [InlineData("Test Input")]
        public void CheckWhiteSpace_StringInput_ThrowsNothingOrThrowsExpectedException(string? sStringCheck, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                StringValidator.CheckWhiteSpace(sStringCheck);
            });
        }
    }
}
