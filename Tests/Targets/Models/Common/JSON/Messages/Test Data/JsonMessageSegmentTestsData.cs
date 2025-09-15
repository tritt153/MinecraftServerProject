using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data;
using MinecraftServerTests.Targets.Models.Common.JSON.Messages.Tests;
using MinecraftServerTests.Utilities;
using static MinecraftServer.Models.Common.JSON.Utilities.JsonTextColor;
using static MinecraftServerTests.Utilities.Constants;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Messages.Test_Data
{

    /// <summary>
    /// Holds static data for <see cref="JsonMessageSegmentTests"/>
    /// </summary>
    public class JsonMessageSegmentTestsData : ITestFactory<JsonMessageSegment>
    {
        #region Constants

        /// <summary>
        /// The expected JSON string for the minimally viable instance of <see cref="JsonMessageSegment"/> which only contains text (see <see cref="JsonMessageSegmentTestFactory.GetMinimalValidInstance()"/>).
        /// </summary>
        /// <seealso cref="GetMinimallyValidInstance"/>
        public const string EXPECTED_JSON = $"{{\"text\":\"{VALID_STRING_INPUT}\"}}";

        /// <summary>
        /// The expected JSON string for a fully initialzed instance of <see cref="JsonMessageSegment"/> which contains all JSON properties (see <see cref="FullyInitalizedObject"/>).
        /// </summary>
        public static readonly string EXPECTED_JSON_FULL = $"{{" +
                                                           $"\"text\":\"{VALID_STRING_INPUT}\"," +
                                                           $"\"color\":\"{DEFAULT_TEXT_COLOR.GetString()}\"," +
                                                           $"\"bold\":true," +
                                                           $"\"italic\":true," +
                                                           $"\"underlined\":true," +
                                                           $"\"strikethrough\":true," +
                                                           $"\"obfuscated\":true," +
                                                           $"\"clickEvent\":{JsonClickEventTestsData.EXPECTED_JSON}," +
                                                           $"\"hoverEvent\":{JsonHoverEventTestsData.EXPECTED_JSON}" +
                                                           $"}}";


        /// <summary>
        /// JSON string that contains invalid JSON property data, and should deserialize into an invalid object.
        /// </summary>
        public const string INVALID_JSON = $"{{\"text\":\"{""}\"}}";

        #endregion // Constants

        #region Public Methods - Static

        /// <summary>
        /// Creates a <see cref="JsonMessageSegment"/> instance by bypassing constructor validation,
        /// allowing manual assignment of invalid values for testing purposes.
        /// </summary> 
        /// <param name="sText">The text of message</param>
        /// <param name="eColor">The enum representing the color of the message</param>
        /// <param name="bBold">True if text should be bolded</param>
        /// <param name="bItalicize">True if text should be italicized</param>
        /// <param name="bUnderline">True if text should be underlined</param>
        /// <param name="bStrikethrough">True if text should be struckthrough</param>
        /// <param name="bObfuscate">True if text should be obfuscated</param>
        /// <param name="oClickEvent">Click Event that occurs when user clicks on text</param>
        /// <param name="oHoverEvent">Hover Event that occurs when user hovers text</param>
        /// <returns>Unvalidated <see cref="JsonMessageSegment" instance/></returns>
        public static JsonMessageSegment CreateUnsafeInstance(string? sText, eTextColor eColor = eTextColor.None, bool? bBold = null, bool? bItalicize = null, bool? bUnderline = null, bool? bStrikethrough = null, bool? bObfuscate = null, JsonClickEvent? oClickEvent = null, JsonHoverEvent? oHoverEvent = null)
        {
            return new JsonMessageSegment()
            {
                Text = sText!,
                ColorString = eColor.GetString(),
                Bold = bBold,
                Italicize = bItalicize,
                Underline = bUnderline,
                Strikethrough = bStrikethrough,
                Obfuscate = bObfuscate,
                ClickEvent = oClickEvent,
                HoverEvent = oHoverEvent
            };
        }

        /// <summary>
        /// Creates and returns and instance of <see cref="JsonMessageSegment"/> that has all assignable fields set to minimally valid values.
        /// </summary>
        /// <returns>Fully initialized <see cref="JsonMessageSegment"/> instance</returns>

        public static JsonMessageSegment CreateFullyInitalizedObject()
        {
            JsonClickEvent oClickEvent = JsonClickEventTestsData.GetMinimallyValidInstance();
            JsonHoverEvent oHoverEvent = JsonHoverEventTestsData.GetMinimallyValidInstance();

            return new JsonMessageSegment(VALID_STRING_INPUT,
                                          DEFAULT_TEXT_COLOR,
                                          true,
                                          true,
                                          true,
                                          true,
                                          true,
                                          oClickEvent,
                                          oHoverEvent);
        }
        #endregion // Public Methods - Static

        #region ITestFactory

        /// <inheritdoc cref="ITestFactory{T}.GetMinimallyValidInstance()"/>
        public static JsonMessageSegment GetMinimallyValidInstance()
        {
            return new JsonMessageSegment(VALID_STRING_INPUT);
        }

        /// <inheritdoc cref="ITestFactory{JsonMessageSegment}.IsMinimallyValidInstance(JsonMessageSegment)"/>
        public static bool IsMinimallyValidInstance(JsonMessageSegment oInstance)
        {
            if (oInstance is not null)
            {
                return oInstance == GetMinimallyValidInstance();
            }

            return false;
        }

        #endregion // ITestFactory
    }
}
