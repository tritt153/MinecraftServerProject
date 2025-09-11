using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Test_Utilities.Helper_Methods;
using Moq;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServerTests.Models.JSON.Events
{
    public class JsonBaseEventTests
    {
        private const string VALID_STRING_INPUT = "Test Input";
        private const string EXPECTED_JSON_SERIALIZATION = $"{{\"action\":\"{VALID_STRING_INPUT}\"}}";
        private const string INVALID_JSON_SERIALIZATION = $"{{\"action\":\"{""}\"}}";

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
        public void Constructor_InvalidStringInput_ThrowsExpectedException(string? sTestString, Type? tExpectedExceptionType = null)
        {
            ExceptionAssert.Throws(tExpectedExceptionType, () =>
            {
                JsonBaseEvent oTestEvent = new JsonTestEvent(sTestString);
            });
        }

        [Fact]
        public void Constructor_ValidStringInput_CreatesObject()
        {
            JsonBaseEvent oTestEvent = new JsonTestEvent(VALID_STRING_INPUT);

            Assert.Equal(VALID_STRING_INPUT, oTestEvent.Action);
        }

        [Fact]
        public void Json_SerializedObject_ShouldDeserializeIntoSameObject()
        {
            JsonBaseEvent oExpectedEvent = new JsonTestEvent(VALID_STRING_INPUT);

            JsonBaseEvent? oActualEvent = JsonSerializerWrapper.Deserialize<JsonTestEvent>
                                         (JsonSerializerWrapper.Serialize(oExpectedEvent));

            Assert.NotNull(oActualEvent);
            Assert.Equal(oExpectedEvent.Action, oActualEvent.Action);
        }

        [Fact]
        public void Json_InvalidDeserialization_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                JsonSerializerWrapper.Deserialize<JsonTestEvent>(INVALID_JSON_SERIALIZATION);
            });
        }

        [Fact]
        public void Json_ValidObject_SerializesCorrectly()
        {
            JsonBaseEvent oTestSerialize = new JsonTestEvent(VALID_STRING_INPUT);

            Assert.Equal(EXPECTED_JSON_SERIALIZATION, JsonSerializerWrapper.Serialize(oTestSerialize));
        }

        [Fact]
        public void Json_ValidJson_DeserializesCorrectly()
        {
            JsonBaseEvent? oTestDeserialize = JsonSerializerWrapper.Deserialize<JsonTestEvent>(EXPECTED_JSON_SERIALIZATION);

            Assert.NotNull(oTestDeserialize);
            Assert.Equal(VALID_STRING_INPUT, oTestDeserialize.Action);
        }

        [Fact]
        public void Json_InvalidJson_DeserializeThrowsArgumentException()
        {
            //
            // The invalid json contains string.Empty as the Action, which should throw an error.
            //
            Assert.Throws<ArgumentException>(() =>
            {
                JsonSerializerWrapper.Deserialize<JsonTestEvent>(INVALID_JSON_SERIALIZATION);
            });
        }

        [Fact]
        public void Validate_Calls_ValidateInternal()
        {
            Mock<JsonTestEvent> oMockTestEvent = new(VALID_STRING_INPUT)
            {
                CallBase = true
            };

            oMockTestEvent.Object.Validate();

            oMockTestEvent.Verify(x => x.Validate(), Times.Once);
            oMockTestEvent.Verify(x => x.ValidateInternal(), Times.Once);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("   ", typeof(ArgumentException))]
        [InlineData("\t\t\t", typeof(ArgumentException))]
        public void Validate_InvalidAction_ThrowsExpectedException(string? sTestAction, Type tExpectedExceptionType)
        {
            JsonTestEvent oInvalidTest = new JsonTestEvent()
            {
                Action = sTestAction!
            };

            ExceptionAssert.Throws(tExpectedExceptionType, oInvalidTest.Validate);
        }

        [Fact]
        public void Validate_ValidAction_ThrowsNothing()
        {
            JsonTestEvent oInvalidTest = new JsonTestEvent()
            {
                Action = VALID_STRING_INPUT
            };

            ExceptionAssert.DoesNotThrow(oInvalidTest.Validate);
        }
    }

    public class JsonTestEvent : JsonBaseEvent
    {
        [JsonConstructor]
        public JsonTestEvent() { }

        [SetsRequiredMembers]
        public JsonTestEvent(string? sAction) : base(sAction!) { }

        public override void ValidateInternal()
        {
            // do nothing, will mock and check this was called.
        }
    }
}
