using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Utilities;
using MinecraftServerTests.Targets.Models.Common.JSON.Messages.Test_Data;
using MinecraftServerTests.Utilities;
using static MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data.JsonHoverEventTestsData;
using static MinecraftServerTests.Utilities.Constants;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Events.Tests
{
    /// <summary>
    /// Contains unit testing logic for <see cref="JsonHoverEvent"/>.
    /// </summary>
    /// <seealso cref="JsonHoverEvent"/>
    public class JsonHoverEventTests
    {
        #region Public Methods - Tests

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void Constructor_InvalidStringInput_ThrowsExpectedException(string? sStringInput, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonHoverEvent oHoverEvent = new JsonHoverEvent(sStringInput!, JsonMessageSegmentTestsData.GetMinimallyValidInstance());
            });
        }

        [Fact]
        public void Constructor_NullJsonMessage_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                JsonHoverEvent oHoverEvent = new JsonHoverEvent(VALID_STRING_INPUT, null!);
            });
        }

        [Fact]
        public void Constructor_InvalidJsonMessage_ThrowsInvalidOperationException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                JsonHoverEvent oHoverEvent = new JsonHoverEvent(VALID_STRING_INPUT, JsonMessageTestsData.CreateUnsafeInstance(
                                                                                    JsonMessageSegmentTestsData.CreateUnsafeInstance(null)));
            });
        }

        [Fact]
        public void Constructor_ValidInput_CreatesObject()
        {
            JsonHoverEvent oHoverEvent = new JsonHoverEvent(VALID_STRING_INPUT,
                                                            JsonMessageTestsData.GetMinimallyValidInstance());
            
            Assert.NotNull(oHoverEvent);
            Assert.Equal(VALID_STRING_INPUT, oHoverEvent.Action);

            Assert.True(JsonMessageTestsData.IsMinimallyValidInstance(oHoverEvent.Contents));
        }

        [Fact]
        public void ShowText_NullJsonMessage_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                JsonHoverEvent oHoverEvent = JsonHoverEvent.ShowText(null!);
            });
        }

        [Fact]
        public void ShowText_InvalidJsonMessage_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                JsonHoverEvent oHoverEvent = JsonHoverEvent.ShowText(JsonMessageTestsData.CreateUnsafeInstance(
                                                                     JsonMessageSegmentTestsData.CreateUnsafeInstance(null)));
            });
        }

        [Fact]
        public void ShowText_ValidJsonMessage_CreatesObject()
        {
            JsonHoverEvent oHoverEvent = JsonHoverEvent.ShowText(JsonMessageTestsData.GetMinimallyValidInstance());

            Assert.NotNull(oHoverEvent);
            Assert.Equal(JsonHoverEvent.SHOW_TEXT, oHoverEvent.Action);

            Assert.True(JsonMessageTestsData.IsMinimallyValidInstance(oHoverEvent.Contents));
        }

        [Fact]
        public void Json_Serializes_Correctly()
        {
            JsonHoverEvent oTestSerialize = GetMinimallyValidInstance();

            Assert.Equal(EXPECTED_JSON, JsonSerializerWrapper.Serialize(oTestSerialize));
        }

        [Fact]
        public void Json_SerializedObject_ShouldDeserializeIntoSameObject()
        {
            JsonHoverEvent oExpectedEvent = GetMinimallyValidInstance();

            JsonHoverEvent? oActualEvent = JsonSerializerWrapper.Deserialize<JsonHoverEvent>
                                         (JsonSerializerWrapper.Serialize(oExpectedEvent));

            Assert.NotNull(oActualEvent);
            Assert.Equal(oExpectedEvent.Action, oActualEvent.Action);

            Assert.Single(oExpectedEvent.Contents.Segments);
            Assert.Single(oActualEvent.Contents.Segments);
            Assert.True(JsonMessageTestsData.IsMinimallyValidInstance(oExpectedEvent.Contents));
            Assert.True(JsonMessageTestsData.IsMinimallyValidInstance(oActualEvent.Contents));
        }

        [Fact]
        public void Json_ValidJson_DeserializesCorrectly()
        {
            JsonHoverEvent? oTestDeserialize = JsonSerializerWrapper.Deserialize<JsonHoverEvent>(EXPECTED_JSON);

            Assert.NotNull(oTestDeserialize);
            Assert.Equal(VALID_STRING_INPUT, oTestDeserialize.Action);

            Assert.True(JsonMessageTestsData.IsMinimallyValidInstance(oTestDeserialize.Contents));
        }

        [Fact]
        public void Json_InvalidJson_DeserializeThrowsArgumentException()
        {
            //
            // The invalid JSON contains string.Empty as the Action, which should throw an error.
            //
            Assert.Throws<ArgumentException>(() =>
            {
                JsonSerializerWrapper.Deserialize<JsonHoverEvent>(INVALID_JSON);
            });
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void Validate_InvalidAction_ThrowsExpectedException(string? sTestValue, Type tExpectedExceptionType)
        {
            JsonHoverEvent oInvalidEvent = CreateUnsafeInstance(sTestValue!, JsonMessageTestsData.GetMinimallyValidInstance());

            ExceptionAssert.Throws(tExpectedExceptionType, oInvalidEvent.Validate);
        }

        [Fact]
        public void Validate_InvalidContents_ThrowsExpectedException()
        {
            JsonHoverEvent oInvalidEvent = CreateUnsafeInstance(VALID_STRING_INPUT, JsonMessageTestsData.CreateUnsafeInstance(
                                                                                    JsonMessageSegmentTestsData.CreateUnsafeInstance(null)));

            Assert.NotNull(oInvalidEvent);
            Assert.Throws<ArgumentNullException>(oInvalidEvent.Validate);
        }

        #endregion // Public Methods - Tests
    }
}
