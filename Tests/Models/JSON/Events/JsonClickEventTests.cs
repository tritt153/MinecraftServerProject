using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Test_Utilities.Helper_Methods;

namespace MinecraftServerTests.Models.JSON.Events
{
    public class JsonClickEventTests
    {
        private const string VALID_STRING_INPUT = "Test Input";
        private const string EXPECTED_JSON_SERIALIZATION = $"{{\"value\":\"{VALID_STRING_INPUT}\",\"action\":\"{JsonClickEvent.RUN_COMMAND}\"}}";
        private const string INVALID_JSON_SERIALIZATION = $"{{\"value\":\"{""}\",\"action\":\"{JsonClickEvent.RUN_COMMAND}\"}}";

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
        public void Constructor_InvalidStringInput_ThrowsExpectedException(string? sTestString, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent oTestEvent = new JsonClickEvent(VALID_STRING_INPUT, sTestString!);
            });
        }

        [Fact]
        public void Constructor_ValidStringInput_CreatesObject()
        {
            JsonClickEvent oTestEvent = new JsonClickEvent(VALID_STRING_INPUT, VALID_STRING_INPUT);

            Assert.Equal(VALID_STRING_INPUT, oTestEvent.Action);
            Assert.Equal(VALID_STRING_INPUT, oTestEvent.Value);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
        public void RunCommand_InvalidStringInput_ThrowsExpectedException(string? sTestString, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonClickEvent.RunCommand(sTestString!);
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
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
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
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
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
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
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
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
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
            JsonClickEvent oTestSerialize = JsonClickEvent.RunCommand(VALID_STRING_INPUT);

            Assert.Equal(EXPECTED_JSON_SERIALIZATION, JsonSerializerWrapper.Serialize(oTestSerialize));
        }

        [Fact]
        public void Json_SerializedObject_ShouldDeserializeIntoSameObject()
        {
            JsonClickEvent oExpectedEvent = JsonClickEvent.RunCommand(VALID_STRING_INPUT);

            JsonClickEvent? oActualEvent = JsonSerializerWrapper.Deserialize<JsonClickEvent>
                                         (JsonSerializerWrapper.Serialize(oExpectedEvent));

            Assert.NotNull(oActualEvent);
            Assert.Equal(oExpectedEvent.Action, oActualEvent.Action);
            Assert.Equal(oExpectedEvent.Value, oActualEvent.Value);
        }

        [Fact]
        public void Json_ValidJson_DeserializesCorrectly()
        {
            JsonClickEvent? oTestDeserialize = JsonSerializerWrapper.Deserialize<JsonClickEvent>(EXPECTED_JSON_SERIALIZATION);

            Assert.NotNull(oTestDeserialize);
            Assert.Equal(JsonClickEvent.RUN_COMMAND, oTestDeserialize.Action);
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
                JsonSerializerWrapper.Deserialize<JsonClickEvent>(INVALID_JSON_SERIALIZATION);
            });
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
        public void Validate_InvalidValue_ThrowsExpectedException(string? sTestValue, Type tExpectedExceptionType)
        {
            JsonClickEvent oInvalidEvent = new JsonClickEvent()
            {
                Action = VALID_STRING_INPUT,
                Value = sTestValue!
            };

            ExceptionAssert.Throws(tExpectedExceptionType, oInvalidEvent.Validate);
        }
    }
}
