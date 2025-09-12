using MinecraftServer.Common.General;
using MinecraftServerTests.Test_Utilities;
using static MinecraftServerTests.Test_Utilities.Constants;

namespace MinecraftServerTests.Common.Data_Validation
{
    public class StringValidatorTests
    {
        #region Public Method - Tests

        [Theory]
        [InlineData(null)]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES)]
        [InlineData(STRING_INPUT_TABS)]
        [InlineData(VALID_STRING_INPUT)]
        public void CheckEmpty_StringInput_ThrowsNothingOrThrowsExpectedException(string? sStringCheck, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                StringValidator.CheckEmpty(sStringCheck);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData(STRING_INPUT_EMPTY)]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        [InlineData(VALID_STRING_INPUT)]
        public void CheckWhiteSpace_StringInput_ThrowsNothingOrThrowsExpectedException(string? sStringCheck, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                StringValidator.CheckWhiteSpace(sStringCheck);
            });
        }

        #endregion // Public Method - Tests
    }
}
