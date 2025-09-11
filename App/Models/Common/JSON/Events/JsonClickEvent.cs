using MinecraftServer.Common.General;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Events
{
    public class JsonClickEvent : JsonBaseEvent
    {
        #region Constants

        internal const string RUN_COMMAND = "run_command";
        internal const string SUGGEST_COMMAND = "suggest_command";
        internal const string OPEN_URL = "open_url";
        internal const string CHANGE_PAGE = "change_page";
        internal const string COPY_TO_CLIPBOARD = "copy_to_clipboard";

        #endregion  // Constants

        #region Json Properties

        [NotNull] // or empty/whitespace
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required string Value { get; init; }

        #endregion // Json Properties

        #region Constructor

        [JsonConstructor]
        public JsonClickEvent() { }

        [SetsRequiredMembers]
        internal JsonClickEvent(string sAction, string sValue) : base(sAction)
        {
            Validator.ValidateString(sValue);

            Value = sValue;
        }

        #endregion // Constructor

        #region Public Methods - Static

        public static JsonClickEvent RunCommand(string sCommand)
        { 
            return new JsonClickEvent(RUN_COMMAND, sCommand);
        }

        public static JsonClickEvent SuggestCommand(string sCommand)
        {
            return new JsonClickEvent(SUGGEST_COMMAND, sCommand);
        }

        public static JsonClickEvent OpenUrl(string sUrl)
        {
            return new JsonClickEvent(OPEN_URL, sUrl);
        }

        public static JsonClickEvent ChangePage(string sUrl)
        {
            return new JsonClickEvent(CHANGE_PAGE, sUrl);
        }

        public static JsonClickEvent CopyToClipboard(string sValueToCopy)
        {
            return new JsonClickEvent(COPY_TO_CLIPBOARD, sValueToCopy);
        }

        #endregion // Public Methods - static

        #region IValidatable - Template Method

        public override void ValidateInternal()
        {
            Validator.ValidateString(Value);
        }

        #endregion // IValidatable
    }
}
