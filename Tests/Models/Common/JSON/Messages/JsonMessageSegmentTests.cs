using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServer.Models.Common.JSON.Utilities;
using MinecraftServerTests.Test_Utilities;
using static MinecraftServer.Models.Common.JSON.Utilities.JsonTextColor;
using static MinecraftServerTests.Models.Common.JSON.Messages.JsonMessagesTestsData.JsonMessageSegmentTestsData;
using static MinecraftServerTests.Test_Utilities.Constants;

namespace MinecraftServerTests.Models.Common.JSON.Messages
{
    public class JsonMessageSegmentTests
    {
        #region Public Method - Tests

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES)]
        [InlineData(STRING_INPUT_TABS)]
        [InlineData(VALID_STRING_INPUT)]
        public void Constructor_StringInput_ThrowsNothingOrThrowsExpectedException(string? sStringInput, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonMessageSegment oSegment = new JsonMessageSegment(sStringInput!);
            });
        }

        [Fact]
        public void Constructor_MinimalInput_CreatesExpectedObject()
        {
            JsonMessageSegment oSegment = new JsonMessageSegment(VALID_STRING_INPUT);

            Assert.Equal(VALID_STRING_INPUT, oSegment.Text);

            Assert.Null(oSegment.ColorString);
            Assert.Null(oSegment.Bold);
            Assert.Null(oSegment.Italicize);
            Assert.Null(oSegment.Underline);
            Assert.Null(oSegment.Strikethrough);
            Assert.Null(oSegment.Obfuscate);
            Assert.Null(oSegment.ClickEvent);
            Assert.Null(oSegment.HoverEvent);
        }

        [Fact]
        public void Constructor_AllInput_CreatesExpectedObject()
        {
            JsonMessageSegment oSegment = FullyInitalizedObject;

            Assert.Equal(VALID_STRING_INPUT, oSegment.Text);
            Assert.Equal(DEFAULT_TEXT_COLOR, oSegment.Color);
            Assert.Equal(DEFAULT_TEXT_COLOR.GetString(), oSegment.ColorString);

            Assert.True(oSegment.Bold);
            Assert.True(oSegment.Italicize);
            Assert.True(oSegment.Underline);
            Assert.True(oSegment.Strikethrough);
            Assert.True(oSegment.Obfuscate);

            Assert.NotNull(oSegment.ClickEvent);
            Assert.Equal(VALID_STRING_INPUT, oSegment.ClickEvent.Action);
            Assert.Equal(VALID_STRING_INPUT, oSegment.ClickEvent.Value);

            Assert.NotNull(oSegment.HoverEvent);
            Assert.Equal(VALID_STRING_INPUT, oSegment.HoverEvent.Action);
            Assert.Single(oSegment.HoverEvent.Contents.Segments);
            Assert.Equal(VALID_STRING_INPUT, oSegment.HoverEvent.Contents.Segments.First().Text);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        public void ImplicitConversion_InvalidSegmentToMessage_ThrowsExpectedException(string? sStringInput, Type tExpectedExceptionType)
        {
            JsonMessageSegment oInvalidSegment = CreateUnsafeInstance(sStringInput!);

            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonMessage oMessage = oInvalidSegment;
            });
        }

        [Fact]
        public void ImplicitConversion_SegmentToMessage_CreatesExpectedMessage()
        {
            JsonMessageSegment oSegment = GetMinimalValidInstance();

            JsonMessage oMessage = oSegment;

            Assert.NotNull(oMessage);
            Assert.Single(oMessage.Segments);
            Assert.Equal(VALID_STRING_INPUT, oMessage.Segments.First().Text);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        public void ImplicitConversion_InvalidStringToSegment_ThrowsExpectedException(string? sStringInput, Type tExpectedExceptionType)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonMessageSegment oInvalidSegment = sStringInput!;
            });
        }

        [Fact]
        public void ImplicitConversion_StringToSegment_CreatesExpectedSegment()
        {
            JsonMessageSegment oSegment = VALID_STRING_INPUT;

            Assert.NotNull(oSegment);
            Assert.Equal(VALID_STRING_INPUT, oSegment.Text);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        public void AdditionOperator_OneInvalidSegment_ThrowsExpectedException(string? sStringInput, Type tExpectedExceptionType)
        {
            JsonMessageSegment oSegmentLeft = GetMinimalValidInstance();
            JsonMessageSegment oSegmentRight = CreateUnsafeInstance(sStringInput!);

            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonMessage oCombinedMessage = oSegmentLeft + oSegmentRight;
            });


            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonMessage oCombinedMessage = oSegmentRight + oSegmentLeft;
            });
        }

        [Fact]
        public void AdditionOperator_AddTwoValidSegments_CreatesExpectedMessage()
        {
            JsonMessageSegment oSegmentLeft = GetMinimalValidInstance();
            JsonMessageSegment oSegmentRight = GetMinimalValidInstance();

            JsonMessage oCombinedMessage = oSegmentLeft + oSegmentRight;

            Assert.NotNull(oCombinedMessage);
            Assert.Equal(2, oCombinedMessage.Segments.Count);
            Assert.Equal(VALID_STRING_INPUT, oCombinedMessage.Segments[0].Text);
            Assert.Equal(VALID_STRING_INPUT, oCombinedMessage.Segments[1].Text);
        }

        [Fact]
        public void Json_InvalidDeserialization_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                JsonSerializerWrapper.Deserialize<JsonMessageSegment>(INVALID_JSON);
            });
        }

        [Fact]
        public void Json_MinimalValidObject_SerializesCorrectly()
        {
            JsonMessageSegment oSerialize = GetMinimalValidInstance();

            Assert.Equal(EXPECTED_JSON, JsonSerializerWrapper.Serialize(oSerialize));
        }

        [Fact]
        public void Json_FullyInitalizedObject_SerializesCorrectly()
        {
            Assert.Equal(EXPECTED_JSON_FULL, 
                         JsonSerializerWrapper.Serialize(FullyInitalizedObject));
        }

        [Fact]
        public void Json_InvalidJson_DeserializeThrowsArgumentException()
        {
            //
            // The invalid json contains string.Empty as the Action, which should throw an error.
            //
            Assert.Throws<ArgumentException>(() =>
            {
                JsonSerializerWrapper.Deserialize<JsonMessageSegment>(INVALID_JSON);
            });
        }

        [Fact]
        public void Json_ValidJson_DeserializesCorrectly()
        {
            JsonMessageSegment? oTestDeserialize = JsonSerializerWrapper.Deserialize<JsonMessageSegment>(EXPECTED_JSON);

            Assert.NotNull(oTestDeserialize);
            Assert.Equal(VALID_STRING_INPUT, oTestDeserialize.Text);
            Assert.Null(oTestDeserialize.ColorString);
            Assert.Null(oTestDeserialize.Bold);
            Assert.Null(oTestDeserialize.Italicize);
            Assert.Null(oTestDeserialize.Underline);
            Assert.Null(oTestDeserialize.Strikethrough);
            Assert.Null(oTestDeserialize.Obfuscate);
            Assert.Null(oTestDeserialize.ClickEvent);
            Assert.Null(oTestDeserialize.HoverEvent);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        public void Validate_InvalidText_ThrowsExpectedException(string? sStringInput, Type tExpectedExceptionType)
        {
            JsonMessageSegment oInvalidSegment = CreateUnsafeInstance(sStringInput!);

            ExceptionAssert.Throws(tExpectedExceptionType, oInvalidSegment.Validate);
        }

        [Fact]
        public void Validate_ValidText_DoesNotThrow()
        {
            ExceptionAssert.DoesNotThrow(() =>
            {
                GetMinimalValidInstance().Validate();
            });
        }

        #endregion // Public Method - Tests
    }
}
