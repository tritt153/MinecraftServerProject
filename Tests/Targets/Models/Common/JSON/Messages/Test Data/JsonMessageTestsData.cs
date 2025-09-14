using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Utilities;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Messages.Test_Data
{

    /// <summary>
    /// Holds static data for <see cref="JsonMessageTests"/>
    /// </summary>
    public class JsonMessageTestsData : ITestFactory<JsonMessage>
    {
        #region Constants

        /// <summary>
        /// The expected JSON string for a minimally valid <see cref="JsonMessage"/> 
        /// containing a single minimally valid <see cref="JsonMessageSegment"/>. In Minecraft, the root object must contain 
        /// a 'text' property (usually empty) and an 'extra' array for complex or styled messages.
        /// </summary>
        public static readonly string EXPECTED_JSON = $"{{\"text\":\"{string.Empty}\",\"extra\":[{JsonMessageSegmentTestsData.EXPECTED_JSON}]}}";

        #endregion // Constants

        #region Public Methods - Static

        #endregion // Public Methods - Static

        #region ITestFactory

        /// <summary>
        /// Creates a <see cref="JsonMessageSegment"/> object that is guaranteed to be valid, and contain only necessary information.
        /// </summary>
        /// <returns>A minimally valid instance of <see cref="JsonMessageSegment"/></returns>
        public static JsonMessage GetMinimallyValidInstance()
        {
            return new JsonMessage(JsonMessageSegmentTestsData.GetMinimallyValidInstance());
        }

        #endregion // ITestFactory
    }

}
