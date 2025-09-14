using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServerTests.Utilities;
using static MinecraftServerTests.Utilities.Constants;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data
{
    /// <summary>
    /// Holds static data for <see cref="JsonClickEventTests"/>
    /// </summary>
    public class JsonClickEventTestsData : ITestFactory<JsonClickEvent>
    {
        #region Constants

        /// <summary>
        /// The expected JSON string for the minimally viable instance of <see cref="JsonClickEvent"/>.
        /// </summary>
        /// <seealso cref="GetMinimallyValidInstance"/>
        public const string EXPECTED_JSON = $"{{\"value\":\"{VALID_STRING_INPUT}\",\"action\":\"{VALID_STRING_INPUT}\"}}";

        /// <summary>
        /// JSON string that contains invalid JSON property data, and should deserialize into an invalid object.
        /// </summary>
        public static readonly string INVALID_JSON = $"{{\"value\":\"{string.Empty}\",\"action\":\"{string.Empty}\"}}";

        #endregion // Constants

        #region Public Methods - Static

        /// <summary>
        /// Creates a <see cref="JsonClickEvent"/> instance by bypassing constructor validation,
        /// allowing manual assignment of invalid values for testing purposes.
        /// </summary> 
        /// <param name="sAction">The potentially invalid action string</param>
        /// <param name="sValue">The potentially invalid value string</param>
        /// <returns>Unvalidated <see cref="JsonClickEvent"/> instance</returns>
        public static JsonClickEvent CreateUnsafeInstance(string sAction, string sValue)
        {
            return new JsonClickEvent() { Action = sAction, Value = sValue };
        }

        #endregion // Public Methods - Static

        #region ITestFactory

        /// <summary>
        /// Creates a <see cref="JsonClickEvent"/> object that is guaranteed to be valid, and contain only necessary information.
        /// </summary>
        /// <returns>A minimally valid instance of <see cref="JsonClickEvent"/></returns>
        public static JsonClickEvent GetMinimallyValidInstance()
        {
            return new JsonClickEvent(VALID_STRING_INPUT, VALID_STRING_INPUT);
        }

        #endregion // ITestFactory
    }

}
