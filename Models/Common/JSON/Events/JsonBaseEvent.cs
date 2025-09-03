using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.Json_Messages
{
    public record JsonBaseEvent
    {
        #region Json Properties

        [NotNull] // or empty
        [JsonPropertyName("action")]
        public required string Action { get; init; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonBaseEvent(string sAction)
        {
            if (string.IsNullOrEmpty(sAction))
            {
                throw new ArgumentNullException(nameof(sAction));
            }

            Action = sAction;
        }

        #endregion // Constructor
    }
}
