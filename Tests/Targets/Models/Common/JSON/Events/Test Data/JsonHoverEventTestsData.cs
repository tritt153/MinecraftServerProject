using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Targets.Models.Common.JSON.Messages.Test_Data;
using MinecraftServerTests.Utilities;
using static MinecraftServerTests.Utilities.Constants;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data
{
    /// <summary>
    /// Holds static data for <see cref="JsonHoverEventTests"/>
    /// </summary>
    public class JsonHoverEventTestsData : ITestFactory<JsonHoverEvent>
    {
        #region Constants

        /// <summary>
        /// The expected JSON string for the minimally viable instance of <see cref="JsonHoverEvent"/>.
        /// </summary>
        /// <seealso cref="GetMinimallyValidInstance"/>
        public static readonly string EXPECTED_JSON = $"{{\"contents\":{JsonMessageTestsData.EXPECTED_JSON},\"action\":\"{VALID_STRING_INPUT}\"}}";

        /// <summary>
        /// JSON string that contains invalid JSON property data, and should deserialize into an invalid object.
        /// </summary>
        public static readonly string INVALID_JSON = $"{{\"contents\":{JsonMessageTestsData.EXPECTED_JSON},\"action\":\"{string.Empty}\"}}";

        #endregion // Constants

        #region Public Methods - Static

        /// <summary>
        /// Creates a <see cref="JsonClickEvent"/> instance by bypassing constructor validation,
        /// allowing manual assignment of invalid values for testing purposes.
        /// </summary> 
        /// <param name="sAction">The potentially invalid action string</param>
        /// <param name="oContents">The potentially invalid <see cref="JsonMessage"/></param>
        /// <returns>Unvalidated <see cref="JsonClickEvent"/> instance</returns>
        public static JsonHoverEvent CreateUnsafeInstance(string sAction, JsonMessage oContents)
        {
            return new JsonHoverEvent() { Action = sAction, Contents = oContents };
        }

        #endregion // Public Methods - Static

        #region ITestFactory

        /// <summary>
        /// Creates a <see cref="JsonHoverEvent"/> object that is guaranteed to be valid, and contain only necessary information.
        /// </summary>
        /// <returns>A minimally valid instance of <see cref="JsonHoverEvent"/></returns>
        public static JsonHoverEvent GetMinimallyValidInstance()
        {
            return new JsonHoverEvent(VALID_STRING_INPUT, JsonMessageTestsData.GetMinimallyValidInstance());
        }

        #endregion // ITestFactory
    }
}

