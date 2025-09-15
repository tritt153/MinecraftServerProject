using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Utilities;
using MinecraftServerTests.Utilities;
using static MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data.JsonBaseEventTestsData;
using static MinecraftServerTests.Utilities.Constants;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Events.Tests
{
    /// <summary>
    /// Contains unit testing logic for <see cref="JsonBaseEvent"/>.
    /// </summary>
    /// <seealso cref="JsonBaseEvent"/>
    /// <seealso cref="JsonTestEvent"/>
    public class JsonBaseEventTests
    {
        #region Public Method - Tests

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
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
            JsonBaseEvent oExpectedEvent = GetMinimallyValidInstance();

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
                JsonSerializerWrapper.Deserialize<JsonTestEvent>(INVALID_JSON);
            });
        }

        [Fact]
        public void Json_ValidObject_SerializesCorrectly()
        {
            JsonBaseEvent oTestSerialize = GetMinimallyValidInstance();

            Assert.Equal(EXPECTED_JSON, JsonSerializerWrapper.Serialize(oTestSerialize));
        }

        [Fact]
        public void Json_ValidJson_DeserializesCorrectly()
        {
            JsonBaseEvent? oTestDeserialize = JsonSerializerWrapper.Deserialize<JsonTestEvent>(EXPECTED_JSON);

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
                JsonSerializerWrapper.Deserialize<JsonTestEvent>(INVALID_JSON);
            });
        }

        [Fact]
        public void Validate_Calls_ValidateInternal()
        {
            JsonBaseEvent oEvent = GetMinimallyValidInstance();

            oEvent.Validate();

            Assert.IsType<JsonTestEvent>(oEvent);
            JsonTestEvent oTestEvent = (JsonTestEvent)oEvent;   

            Assert.True(oTestEvent.WasValidateInternalCalled);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData(STRING_INPUT_EMPTY, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_SPACES, typeof(ArgumentException))]
        [InlineData(STRING_INPUT_TABS, typeof(ArgumentException))]
        public void Validate_InvalidAction_ThrowsExpectedException(string? sTestAction, Type tExpectedExceptionType)
        {
            JsonBaseEvent oInvalidEvent = CreateUnsafeInstance(sTestAction!);

            ExceptionAssert.Throws(tExpectedExceptionType, oInvalidEvent.Validate);
        }

        [Fact]
        public void Validate_ValidAction_DoesNotThrow()
        {
            JsonBaseEvent oValidEvent = GetMinimallyValidInstance();

            ExceptionAssert.DoesNotThrow(oValidEvent.Validate);
        }

        #endregion // Public Method - Tests
    }
}
