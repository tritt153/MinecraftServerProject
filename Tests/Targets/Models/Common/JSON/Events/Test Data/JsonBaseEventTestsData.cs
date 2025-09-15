using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServerTests.Targets.Models.Common.JSON.Events.Tests;
using MinecraftServerTests.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using static MinecraftServerTests.Utilities.Constants;

namespace MinecraftServerTests.Targets.Models.Common.JSON.Events.Test_Data
{
    /// <summary>
    /// Holds static data for <see cref="JsonBaseEventTests"/>
    /// </summary>
    public class JsonBaseEventTestsData : ITestFactory<JsonBaseEvent>
    {
        #region Constants

        /// <summary>
        /// The expected JSON string for the minimally viable instance of <see cref="JsonTestEvent"/>.
        /// </summary>
        /// <seealso cref="GetMinimallyValidInstance"/>
        public const string EXPECTED_JSON = $"{{\"action\":\"{VALID_STRING_INPUT}\"}}";

        /// <summary>
        /// JSON string that contains invalid JSON property data, and should deserialize into an invalid object.
        /// </summary>
        public static readonly string INVALID_JSON = $"{{\"action\":\"{string.Empty}\"}}";

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
        public static JsonBaseEvent GetMinimallyValidInstance()
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

}
