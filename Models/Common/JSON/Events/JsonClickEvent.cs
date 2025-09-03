using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.Json_Messages
{
    public record JsonClickEvent : JsonBaseEvent
    {
        #region Json Properties

        [NotNull] // or empty
        [JsonPropertyName("value")]
        public required string Value { get; init; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonClickEvent(string sAction, string sValue) : base(sAction)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                throw new ArgumentNullException(nameof(sValue));
            }
              
            Value = sValue;
        }

        #endregion // Constructor

        #region Public Methods - Static

        public static JsonClickEvent RunCommand(string sCommand)
        { 
            return new JsonClickEvent("run_command", sCommand);
        }

        public static JsonClickEvent SuggestCommand(string sCommand)
        {
            return new JsonClickEvent("suggest_command", sCommand);
        }

        public static JsonClickEvent OpenUrl(string sUrl)
        {
            return new JsonClickEvent("suggest_command", sUrl);
        }

        public static JsonClickEvent ChangePage(string sUrl)
        {
            return new JsonClickEvent("change_page", sUrl);
        }

        public static JsonClickEvent Copy(string sValueToCopy)
        {
            return new JsonClickEvent("copy_to_clipboard", sValueToCopy);
        }

        #endregion // Public Methods - Static
    }
}
