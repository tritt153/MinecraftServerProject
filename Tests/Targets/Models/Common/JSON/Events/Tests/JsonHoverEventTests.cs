using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServerTests.Targets.Models.Common.JSON.Messages.Test_Data;
using MinecraftServerTests.Utilities;
using static MinecraftServerTests.Utilities.Constants;
using static MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data.JsonHoverEventTestsData;

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
                JsonHoverEvent oHoverEvent = new JsonHoverEvent(sStringInput!, JsonMessageTestsData.GetMinimallyValidInstance());
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
            Assert.Throws<InvalidOperationException>(() =>
            {
                JsonHoverEvent oHoverEvent = new JsonHoverEvent(VALID_STRING_INPUT, JsonMessageTestsData.CreateInstanceWithNullSegments());
            });
        }

        [Fact]
        public void Constructor_ValidInput_CreatesObject()
        {
            JsonHoverEvent oHoverEvent = new JsonHoverEvent(VALID_STRING_INPUT,
                                                            JsonMessageTestsData.GetMinimallyValidInstance());
            
            Assert.NotNull(oHoverEvent);
            Assert.Equal(VALID_STRING_INPUT, oHoverEvent.Action);

            ExceptionAssert.DoesNotThrow(oHoverEvent.Contents.Validate);
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
        public void ShowText_InvalidJsonMessage_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                JsonHoverEvent oHoverEvent = JsonHoverEvent.ShowText(JsonMessageTestsData.CreateInstanceWithNullSegments());
            });
        }

        [Fact]
        public void ShowText_ValidJsonMessage_CreatesObject()
        {
            JsonHoverEvent oHoverEvent = JsonHoverEvent.ShowText(JsonMessageTestsData.GetMinimallyValidInstance());

            Assert.NotNull(oHoverEvent);
            Assert.Equal(JsonHoverEvent.SHOW_TEXT, oHoverEvent.Action);

            ExceptionAssert.DoesNotThrow(oHoverEvent.Contents.Validate);
        }

        #endregion // Public Methods - Tests

    }
}
