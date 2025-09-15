using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Targets.Models.Common.JSON.Messages.Tests;
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

        /// <summary>
        /// Creates an invalid <see cref="JsonMessage"/> instance that has a null message segments list.
        /// </summary> 
        /// <returns>Invalid <see cref="JsonMessage"/> instance</returns>
        public static JsonMessage CreateUnsafeInstance(params JsonMessageSegment[] oParams)
        {
            return new JsonMessage() { RootText = string.Empty, Segments = [.. oParams] };
        }

        #endregion // Public Methods - Static

        #region ITestFactory

        ///<inheritdoc cref="ITestFactory{T}.GetMinimallyValidInstance()"/>
        public static JsonMessage GetMinimallyValidInstance()
        {
            return new JsonMessage(JsonMessageSegmentTestsData.GetMinimallyValidInstance());
        }

        ///<inheritdoc cref="ITestFactory{T}.IsMinimallyValidInstance(T)"/>
        public static bool IsMinimallyValidInstance(JsonMessage oInstance)
        {
            if (oInstance is not null)
            {
                if (oInstance.Segments is not null)
                {
                    return oInstance.Segments.Count == 1 &&
                           JsonMessageSegmentTestsData.IsMinimallyValidInstance(oInstance.Segments.First());
                }
            }

            return false;
        }

        #endregion // ITestFactory
    }

}
