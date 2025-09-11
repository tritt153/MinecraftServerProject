using MinecraftServer.Common.General;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Events
{
    public abstract class JsonBaseEvent : IValidatable
    {
        #region Json Properties

        [NotNull] // or empty/whitespace
        [JsonPropertyName("action")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required string Action { get; init; }

        #endregion // Json Properties

        #region Constructor

        [JsonConstructor]
        public JsonBaseEvent() { }

        [SetsRequiredMembers]
        public JsonBaseEvent(string sAction)
        {
            Validator.ValidateString(sAction);

            Action = sAction;
        }

        #endregion // Constructor

        #region IValidatable

        public virtual void Validate()
        {
            Validator.ValidateString(Action);

            ValidateInternal();
        }

        public abstract void ValidateInternal(); // IValidatable Template Method

        #endregion // IValidatable
    }
}
