using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Targets.Models.Common.JSON.Messages.Test_Data;
using static MinecraftServerTests.Targets.Models.Common.JSON.Messages.Test_Data.JsonMessageTestsData;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Messages.Tests
{
    public class JsonMessageTests
    {
        [Fact]
        public void Constructor_NullSegment_ThrowsNullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                JsonMessage oMessage = new JsonMessage(null!);
            });
        }

        [Fact]
        public void Constructor_InvalidSegment_ThrowsNullArgumentException()
        {
            JsonMessageSegment oInvalidSegment = JsonMessageSegmentTestsData.CreateUnsafeInstance(null!);

            Assert.Throws<ArgumentNullException>(() =>
            {
                JsonMessage oMessage = new JsonMessage(oInvalidSegment);
            });
        }

        [Fact]
        public void Constructor_ValidSegment_CreatesObject()
        {
            JsonMessage oMessage = new JsonMessage(JsonMessageSegmentTestsData.GetMinimallyValidInstance());

            Assert.NotNull(oMessage);
            Assert.Single(oMessage.Segments);
            Assert.True(JsonMessageSegmentTestsData.IsMinimallyValidInstance(oMessage.Segments.First()));
        }

        [Fact]
        public void Constructor_MultipleValidSegments_CreatesObject()
        {
            JsonMessage oMessage = new JsonMessage(JsonMessageSegmentTestsData.GetMinimallyValidInstance(),
                                                   JsonMessageSegmentTestsData.GetMinimallyValidInstance(),
                                                   JsonMessageSegmentTestsData.GetMinimallyValidInstance());

            Assert.NotNull(oMessage);
            Assert.Equal(3, oMessage.Segments.Count);

            foreach (JsonMessageSegment oSegment in oMessage.Segments)
            {
                Assert.True(JsonMessageSegmentTestsData.IsMinimallyValidInstance(oSegment));
            }
        }

        [Fact]
        public void AdditionOperator_InvalidMessagePlusSegment_ThrowsNullArgumentException()
        {
            JsonMessage oMessage = CreateUnsafeInstance(JsonMessageSegmentTestsData.CreateUnsafeInstance(null));

            Assert.Throws<ArgumentNullException>(() =>
            {
                oMessage = oMessage + JsonMessageSegmentTestsData.GetMinimallyValidInstance();
            });
        }

        [Fact]
        public void AdditionOperator_MessagePlusInvalidSegment_ThrowsNullArgumentException()
        {
            JsonMessage oMessage = GetMinimallyValidInstance();

            Assert.Throws<ArgumentNullException>(() =>
            {
                oMessage = oMessage + JsonMessageSegmentTestsData.CreateUnsafeInstance(null);
            });
        }

        [Fact]
        public void AdditionOperator_MessagePlusSegment_ReturnsCorrectMessage()
        {
            JsonMessage oMessage = new JsonMessage(JsonMessageSegmentTestsData.GetMinimallyValidInstance());

            oMessage = oMessage + JsonMessageSegmentTestsData.GetMinimallyValidInstance();

            Assert.NotNull(oMessage);
            Assert.Equal(2, oMessage.Segments.Count);

            foreach (JsonMessageSegment oSegment in oMessage.Segments)
            {
                Assert.True(JsonMessageSegmentTestsData.IsMinimallyValidInstance(oSegment));
            }
        }

        [Fact]
        public void AdditionOperator_MessagePlusMessage_ReturnsCorrectMessage()
        {
            JsonMessage oMessageLeft = new JsonMessage(JsonMessageSegmentTestsData.GetMinimallyValidInstance(),
                                                       JsonMessageSegmentTestsData.GetMinimallyValidInstance());

            JsonMessage oMessageRight = new JsonMessage(JsonMessageSegmentTestsData.GetMinimallyValidInstance(),
                                                        JsonMessageSegmentTestsData.GetMinimallyValidInstance());

            JsonMessage oCombinedMessage = oMessageLeft + oMessageRight;

            Assert.NotNull(oCombinedMessage);
            Assert.Equal(4, oCombinedMessage.Segments.Count);

            foreach (JsonMessageSegment oSegment in oCombinedMessage.Segments)
            {
                Assert.True(JsonMessageSegmentTestsData.IsMinimallyValidInstance(oSegment));
            }
        }
    }
}