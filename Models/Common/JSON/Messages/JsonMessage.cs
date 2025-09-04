using MinecraftServer.Models.Common.Utilities.General;
using System.Diagnostics.CodeAnalysis;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Messages
{
    public class JsonMessage : IValidatable
    {
        #region Json Properties

        /// <summary>
        /// This property is necessary for JSON strings in Minecraft, the JSON must start with a "text" attribute, or parsing will fail.
        /// </summary>
        [NotNull]
        [JsonPropertyName("text")]
        public required string RootText { get; init; } = "";

        [NotNull]
        [JsonPropertyName("extra")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required List<JsonMessageSegment>? Segments { get; init; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonMessage(JsonMessageSegment oMsg)
        {
            Segments = [oMsg];
        }

        [SetsRequiredMembers]
        public JsonMessage(params JsonMessageSegment[] oSegments)
        {
            Segments = [.. oSegments];
        }

        #endregion // Constructor

        #region ToString 

        /// <summary>
        /// Serializes this object into a string in the format expected by Minecraft.
        /// </summary>
        /// <returns>string - The JSON message as a formatted string.</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            });
        }

        #endregion // Public Methods

        #region Operator Override(s)

        public static JsonMessage operator +(JsonMessage oFullMsg, JsonMessageSegment oSegment)
        {
            Validator.ValidateParams(oFullMsg, oSegment);

            oFullMsg.Segments.Add(oSegment);

            return oFullMsg;
        }

        public static JsonMessage operator +(JsonMessage oMsgLeft, JsonMessage oMsgRight)
        {
            Validator.ValidateParams(oMsgLeft, oMsgRight);

            foreach (JsonMessageSegment oSegment in oMsgRight.Segments)
            {
                oMsgLeft.Segments.Add(oSegment);
            }

            return oMsgLeft;
        }

        #endregion // Operator Override(s)

        #region IValidatable

        public void Validate()
        {
            if (Segments == null || Segments.Count == 0)
            {
                Thrower.ThrowInvalidOperationException("Message must have at least one segment!");
            }
        }

        #endregion // IValidatable
    }
}
