using MinecraftServer.Models.Common.Utilities.General;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Events
{
    public record JsonBaseEvent
    {
        #region Json Properties

        [NotNull] // or empty
        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required string Action { get; init; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonBaseEvent(string sAction)
        {
            StringValidator.Validate(sAction, StringValidator.eStringValidationOptions.All);

            Action = sAction;
        }

        #endregion // Constructor
    }
}
