using MinecraftServer.Common.General;
using MinecraftServer.Models.Common.JSON.Messages;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Events
{
    public class JsonHoverEvent : JsonBaseEvent
    {
        #region Constants

        internal const string SHOW_TEXT = "show_text";

        #endregion // Constants

        #region Json Properties

        [NotNull]
        [JsonPropertyName("contents")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required JsonMessage Contents { get; init; }

        #endregion // Json Properties

        #region Constructor

        [JsonConstructor]
        public JsonHoverEvent() { }

        [SetsRequiredMembers]
        public JsonHoverEvent(string sAction, JsonMessage oContents) : base(sAction)
        {
            Validator.ValidateParam(oContents);

            Contents = oContents;
        }

        #endregion // Constructor

        #region Public Methods - Static

        public static JsonHoverEvent ShowText(JsonMessage oText)
        {
            return new JsonHoverEvent(SHOW_TEXT, oText);
        }

        #endregion // Public Methods - Static

        #region IValidatable

        public override void ValidateInternal()
        {
            base.Validate();
            Validator.ValidateParam(Contents);
        }

        #endregion // IValidatable
    }
}
