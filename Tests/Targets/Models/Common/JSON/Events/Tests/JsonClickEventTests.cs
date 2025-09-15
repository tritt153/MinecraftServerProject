using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Utilities;
using MinecraftServerTests.Utilities;
using static MinecraftServerTests.Utilities.Constants;
using static MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data.JsonClickEventTestsData;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Events.Tests
{
    /// <summary>
    /// Contains unit testing logic for <see cref="JsonClickEvent"/>.
    /// </summary>
    /// <seealso cref="JsonClickEvent"/>
    public class JsonClickEventTests
    {
        #region Public Method - Tests

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void Constructor_InvalidStringInput_ThrowsExpectedException(string? sStringInput, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent oClickEvent = new JsonClickEvent(VALID_STRING_INPUT, sStringInput!);
            });
        }

        [Fact]
        public void Constructor_ValidStringInput_CreatesObject()
        {
            JsonClickEvent oClickEvent = new JsonClickEvent(VALID_STRING_INPUT, VALID_STRING_INPUT);

            Assert.Equal(VALID_STRING_INPUT, oClickEvent.Action);
            Assert.Equal(VALID_STRING_INPUT, oClickEvent.Value);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void RunCommand_InvalidStringInput_ThrowsExpectedException(string? sStringInput, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent.RunCommand(sStringInput!);
            });
        }

        [Fact]
        public void RunCommand_ValidStringInput_ReturnsObject()
        {
            JsonClickEvent oCreateTest = JsonClickEvent.RunCommand(VALID_STRING_INPUT);

            Assert.Equal(JsonClickEvent.RUN_COMMAND, oCreateTest.Action);
            Assert.Equal(VALID_STRING_INPUT, oCreateTest.Value);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void SuggestCommand_InvalidStringInput_ThrowsExpectedException(string? sTestString, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent.SuggestCommand(sTestString!);
            });
        }

        [Fact]
        public void SuggestCommand_ValidStringInput_ReturnsObject()
        {
            JsonClickEvent oCreateTest = JsonClickEvent.SuggestCommand(VALID_STRING_INPUT);

            Assert.Equal(JsonClickEvent.SUGGEST_COMMAND, oCreateTest.Action);
            Assert.Equal(VALID_STRING_INPUT, oCreateTest.Value);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void OpenUrl_InvalidStringInput_ThrowsExpectedException(string? sTestString, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent.OpenUrl(sTestString!);
            });
        }

        [Fact]
        public void OpenUrl_ValidStringInput_ReturnsObject()
        {
            JsonClickEvent oCreateTest = JsonClickEvent.OpenUrl(VALID_STRING_INPUT);

            Assert.Equal(JsonClickEvent.OPEN_URL, oCreateTest.Action);
            Assert.Equal(VALID_STRING_INPUT, oCreateTest.Value);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void ChangePage_InvalidStringInput_ThrowsExpectedException(string? sTestString, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent.ChangePage(sTestString!);
            });
        }

        [Fact]
        public void ChangePage_ValidStringInput_ReturnsObject()
        {
            JsonClickEvent oCreateTest = JsonClickEvent.ChangePage(VALID_STRING_INPUT);

            Assert.Equal(JsonClickEvent.CHANGE_PAGE, oCreateTest.Action);
            Assert.Equal(VALID_STRING_INPUT, oCreateTest.Value);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void CopyToClipboard_InvalidStringInput_ThrowsExpectedException(string? sTestString, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent.CopyToClipboard(sTestString!);
            });
        }

        [Fact]
        public void CopyToClipboard_ValidStringInput_ReturnsObject()
        {
            JsonClickEvent oCreateTest = JsonClickEvent.CopyToClipboard(VALID_STRING_INPUT);

            Assert.Equal(JsonClickEvent.COPY_TO_CLIPBOARD, oCreateTest.Action);
            Assert.Equal(VALID_STRING_INPUT, oCreateTest.Value);
        }

        [Fact]
        public void Json_Serializes_Correctly()
        {
            JsonClickEvent oTestSerialize = GetMinimallyValidInstance();

            Assert.Equal(EXPECTED_JSON, JsonSerializerWrapper.Serialize(oTestSerialize));
        }

        [Fact]
        public void Json_SerializedObject_ShouldDeserializeIntoSameObject()
        {
            JsonClickEvent oExpectedEvent = GetMinimallyValidInstance();

            JsonClickEvent? oActualEvent = JsonSerializerWrapper.Deserialize<JsonClickEvent>
                                         (JsonSerializerWrapper.Serialize(oExpectedEvent));

            Assert.NotNull(oActualEvent);
            Assert.Equal(oExpectedEvent.Action, oActualEvent.Action);
            Assert.Equal(oExpectedEvent.Value, oActualEvent.Value);
        }

        [Fact]
        public void Json_ValidJson_DeserializesCorrectly()
        {
            JsonClickEvent? oTestDeserialize = JsonSerializerWrapper.Deserialize<JsonClickEvent>(EXPECTED_JSON);

            Assert.NotNull(oTestDeserialize);
            Assert.Equal(VALID_STRING_INPUT, oTestDeserialize.Action);
            Assert.Equal(VALID_STRING_INPUT, oTestDeserialize.Value);
        }

        [Fact]
        public void Json_InvalidJson_DeserializeThrowsArgumentException()
        {
            //
            // The invalid JSON contains string.Empty as the Value, which should throw an error.
            //
            Assert.Throws<ArgumentException>(() =>
            {
                JsonSerializerWrapper.Deserialize<JsonClickEvent>(INVALID_JSON);
            });
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void Validate_InvalidValue_ThrowsExpectedException(string? sTestValue, Type tExpectedExceptionType)
        {
            JsonClickEvent oInvalidEvent = CreateUnsafeInstance(VALID_STRING_INPUT, sTestValue!);

            ExceptionAssert.Throws(tExpectedExceptionType, oInvalidEvent.Validate);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void Validate_InvalidAction_ThrowsExpectedException(string? sTestValue, Type tExpectedExceptionType)
        {
            JsonClickEvent oInvalidEvent = CreateUnsafeInstance(sTestValue!, VALID_STRING_INPUT!);

            ExceptionAssert.Throws(tExpectedExceptionType, oInvalidEvent.Validate);
        }

        #endregion // Public Method - Tests
    }
}
