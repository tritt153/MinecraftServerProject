using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Messages;
using MinecraftServerTests.Test_Utilities.Test_Factory;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using static MinecraftServerTests.Models.Common.JSON.Messages.JsonMessagesTestsData;
using static MinecraftServerTests.Test_Utilities.Constants;

namespace MinecraftServerTests.Models.Common.JSON.Events
{
    public partial class JsonEventsTestsData
    {
        #region Base Event

        /// <summary>
        /// Holds static data for <see cref="JsonBaseEventTests"/>
        /// </summary>
        public class JsonBaseEventTestsData : ITestFactory<JsonBaseEvent>
        {
            #region Constants

            /// <summary>
            /// The expected JSON string for the minimally viable instance of <see cref="JsonTestEvent"/>.
            /// </summary>
            /// <seealso cref="ITestFactory{T}"/>
            /// <seealso cref="GetMinimalValidInstance"/>
            public const string EXPECTED_JSON = $"{{\"action\":\"{VALID_STRING_INPUT}\"}}";

            /// <summary>
            /// JSON string that contains invalid JSON property data, and should deserialize into an invalid object.
            /// </summary>
            public const string INVALID_JSON = $"{{\"action\":\"{""}\"}}";

            #endregion // Constants

            #region Public Methods - Static

            /// <summary>
            /// Creates a <see cref="JsonBaseEvent"/> instance by bypassing constructor validation,
            /// allowing manual assignment of invalid values for testing purposes.
            /// </summary> 
            /// <param name="sAction">The potentially invalid action string</param>
            /// <returns>Unvalidated <see cref="JsonBaseEvent"/> instance</returns>
            public static JsonBaseEvent CreateUnsafeInstance(string sAction)
            {
                return new JsonTestEvent() { Action = sAction };
            }

            #endregion // Public Methods - Static

            #region ITestFactory

            /// <summary>
            /// Creates a <see cref="JsonBaseEvent"/> object that is guaranteed to be valid, and contain only necessary information.
            /// </summary>
            /// <returns>A minimally valid instance of <see cref="JsonBaseEvent"/></returns>
            /// <seealso cref="JsonTestEvent"/>
            public static JsonBaseEvent GetMinimalValidInstance()
            {
                return new JsonTestEvent(VALID_STRING_INPUT);
            }

            #endregion // ITestFactory

            #region Json Test Event

            /// <summary>
            /// Concrete subclass to allow testing of abstract parent <see cref="JsonBaseEvent"/>
            /// </summary>
            public class JsonTestEvent : JsonBaseEvent
            {
                #region Properties

                [JsonIgnore]
                public bool WasValidateInternalCalled = false;

                #endregion // Properties

                #region Constructor

                [JsonConstructor]
                public JsonTestEvent() { }

                [SetsRequiredMembers]
                public JsonTestEvent(string? sAction) : base(sAction!) { }

                #endregion // Constructor

                #region Public Methods - Abstract Overrides

                public override void ValidateInternal()
                {
                    WasValidateInternalCalled = true;
                }

                #endregion // Public Methods - Abstract Overrides
            }

            #endregion // Json Test Event
        }

        #endregion // Base Event

        #region Click Event

        /// <summary>
        /// Holds static data for <see cref="JsonClickEventTests"/>
        /// </summary>
        public class JsonClickEventTestsData : ITestFactory<JsonClickEvent> 
        {
            #region Constants

            /// <summary>
            /// The expected JSON string for the minimally viable instance of <see cref="JsonClickEvent"/>.
            /// </summary>
            /// <seealso cref="GetMinimalValidInstance"/>
            public const string EXPECTED_JSON = $"{{\"value\":\"{VALID_STRING_INPUT}\",\"action\":\"{VALID_STRING_INPUT}\"}}";

            /// <summary>
            /// JSON string that contains invalid JSON property data, and should deserialize into an invalid object.
            /// </summary>
            public const string INVALID_JSON = $"{{\"value\":\"{""}\",\"action\":\"{""}\"}}";

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
            public static JsonClickEvent GetMinimalValidInstance()
            {
                return new JsonClickEvent(VALID_STRING_INPUT, VALID_STRING_INPUT);
            }

            #endregion // ITestFactory
        }

        #endregion // Click Event

        #region Hover Event

        /// <summary>
        /// Holds static data for <see cref="JsonHoverEventTests"/>
        /// </summary>
        public class JsonHoverEventTestsData : ITestFactory<JsonHoverEvent>
        {
            #region Constants

            /// <summary>
            /// The expected JSON string for the minimally viable instance of <see cref="JsonHoverEvent"/>.
            /// </summary>
            /// <seealso cref="GetMinimalValidInstance"/>
            public static readonly string EXPECTED_JSON = $"{{\"contents\":{JsonMessageTestsData.EXPECTED_JSON},\"action\":\"{VALID_STRING_INPUT}\"}}";

            /// <summary>
            /// JSON string that contains invalid JSON property data, and should deserialize into an invalid object.
            /// </summary>
            public static readonly string INVALID_JSON = $"{{\"contents\":{JsonMessageTestsData.EXPECTED_JSON},\"action\":\"{""}\"}}";

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
            public static JsonHoverEvent GetMinimalValidInstance()
            {
                return new JsonHoverEvent(VALID_STRING_INPUT, JsonMessageTestsData.GetMinimalValidInstance());
            }

            #endregion // ITestFactory
        }

        #endregion // Hover Event
    }
}
