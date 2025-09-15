using MinecraftServer.Common.Data_Validation;
using MinecraftServerTests.Utilities;
using Moq;
using static MinecraftServerTests.Utilities.Constants;

namespace MinecraftServerTests.Common.Data_Validation
{
    public class ValidatorTests
    {
        #region Public Method - Tests

        [Fact]
        public void CheckNull_NullParamter_ThrowsArgumentNullException()
        {
            object? oNullObject = null;

            Assert.Throws<ArgumentNullException>(() => Validator.CheckNull(oNullObject));
        }

        [Fact]
        public void ValidateParams_NullParameterList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Validator.ValidateParams(string.Empty, null!));
        }

        [Fact]
        public void ValidateParams_OneNullParameters_ThrowsArgumentNullException()
        {
            IValidatable? oNullObj1 = null;

            Assert.Throws<ArgumentNullException>(() => Validator.ValidateParams(string.Empty, oNullObj1!));
        }


        [Fact]
        public void ValidateParams_AllNullParameters_ThrowsArgumentNullException()
        {
            IValidatable? oNullObj1 = null;
            IValidatable? oNullObj2 = null;

            Assert.Throws<ArgumentNullException>(() => Validator.ValidateParams(string.Empty, oNullObj1!, oNullObj2!));
        }

        [Fact]
        public void ValidateParams_SomeNullParameters_ThrowsArgumentNullException()
        {
            Mock<IValidatable> oRealObj = new();
            IValidatable? oNullObj = null;

            Assert.Throws<ArgumentNullException>(() => Validator.ValidateParams(string.Empty, oRealObj.Object, oNullObj!));
        }

        [Fact]
        public void ValidateParams_ValidParameter_CallsValidateOnce()
        {
            Mock<IValidatable> oMockValidatable = new();

            Validator.ValidateParams(string.Empty, oMockValidatable.Object);

            oMockValidatable.Verify(x => x.Validate(), Times.Once);
        }

        [Fact]
        public void ValidateParams_ValidParameters_CallsValidateOnce()
        {
            Mock<IValidatable> oMockValidatable1 = new();
            Mock<IValidatable> oMockValidatable2 = new();
            Mock<IValidatable> oMockValidatable3 = new();

            Validator.ValidateParams(string.Empty, oMockValidatable1.Object);
            Validator.ValidateParams(string.Empty, oMockValidatable2.Object);
            Validator.ValidateParams(string.Empty, oMockValidatable3.Object);

            oMockValidatable1.Verify(x => x.Validate(), Times.Once);
            oMockValidatable2.Verify(x => x.Validate(), Times.Once);
            oMockValidatable3.Verify(x => x.Validate(), Times.Once);
        }

        [Fact]
        public void ValidateParam_ValidParameter_CallsValidateOnce()
        {
            Mock<IValidatable> oMockValidatable = new();

            Validator.ValidateParam(oMockValidatable.Object);

            oMockValidatable.Verify(x => x.Validate(), Times.Once);
        }

        [Theory]
        [InlineData(Validator.eStringValidationOptions.NotNull, typeof(ArgumentNullException))]
        [InlineData(Validator.eStringValidationOptions.NotEmpty)]
        [InlineData(Validator.eStringValidationOptions.NotWhiteSpace)]
        [InlineData(Validator.eStringValidationOptions.NotNullNotEmpty, typeof(ArgumentNullException))]
        [InlineData(Validator.eStringValidationOptions.NotNullNotWhitespace, typeof(ArgumentNullException))]
        [InlineData(Validator.eStringValidationOptions.All, typeof(ArgumentNullException))]
        public void ValidateString_NullString_ThrowsArgumentNullException(Validator.eStringValidationOptions eOptions, Type? tExpectedExceptionType = null)
        {
            string? sNullString = null;

            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                Validator.ValidateString(sNullString, eOptions);
            });
        }

        [Theory]
        [InlineData(Validator.eStringValidationOptions.NotNull)]
        [InlineData(Validator.eStringValidationOptions.NotEmpty, typeof(ArgumentException))]
        [InlineData(Validator.eStringValidationOptions.NotWhiteSpace)]
        [InlineData(Validator.eStringValidationOptions.NotNullNotEmpty, typeof(ArgumentException))]
        [InlineData(Validator.eStringValidationOptions.NotNullNotWhitespace)]
        [InlineData(Validator.eStringValidationOptions.All, typeof(ArgumentException))]
        public void ValidateString_EmptyString_ValidatesOrThrowsExpectedException(Validator.eStringValidationOptions eOptions, Type? tExpectedExceptionType = null)
        {
            string sEmptyString = STRING_INPUT_EMPTY;

            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                Validator.ValidateString(sEmptyString, eOptions);
            });
        }

        [Theory]
        [InlineData(Validator.eStringValidationOptions.NotNull)]
        [InlineData(Validator.eStringValidationOptions.NotEmpty)]
        [InlineData(Validator.eStringValidationOptions.NotWhiteSpace, typeof(ArgumentException))]
        [InlineData(Validator.eStringValidationOptions.NotNullNotEmpty)]
        [InlineData(Validator.eStringValidationOptions.NotNullNotWhitespace, typeof(ArgumentException))]
        [InlineData(Validator.eStringValidationOptions.All, typeof(ArgumentException))]
        public void ValidateString_WhiteSpaceString_ValidatesOrThrowsArgumentException(Validator.eStringValidationOptions eOptions, Type? tExpectedExceptionType = null)
        {
            string sWhiteSpaceString = STRING_INPUT_SPACES + STRING_INPUT_TABS;

            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                Validator.ValidateString(sWhiteSpaceString, eOptions);
            });
        }

        [Theory]
        [InlineData(Validator.eStringValidationOptions.NotNull)]
        [InlineData(Validator.eStringValidationOptions.NotEmpty)]
        [InlineData(Validator.eStringValidationOptions.NotWhiteSpace)]
        [InlineData(Validator.eStringValidationOptions.NotNullNotEmpty)]
        [InlineData(Validator.eStringValidationOptions.NotNullNotWhitespace)]
        [InlineData(Validator.eStringValidationOptions.All)]
        public void ValidateString_ValidString_ThrowsNothing(Validator.eStringValidationOptions eOptions)
        {
            string sValidString = VALID_STRING_INPUT;

            ExceptionAssert.DoesNotThrow(() =>
            {
                Validator.ValidateString(sValidString, eOptions);
            });
        }

        #endregion // Public Method - Tests
    }
}
