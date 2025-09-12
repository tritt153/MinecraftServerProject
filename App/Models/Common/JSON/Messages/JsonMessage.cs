using MinecraftServer.Common.General;
using MinecraftServer.Models.Common.JSON.Constants;
using MinecraftServer.Models.Common.JSON.Utilities;
using System.Diagnostics.CodeAnalysis;
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

        [JsonConstructor]
        public JsonMessage() { }

        [SetsRequiredMembers]
        public JsonMessage(JsonMessageSegment oMsg)
        {
            Validator.ValidateParam(oMsg);

            Segments = [oMsg];
        }

        [SetsRequiredMembers]
        public JsonMessage(params JsonMessageSegment[] oSegments)
        {
            Validator.ValidateParams(JsonErrorMessages.MessageSegmentInvalid(), oSegments);

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
            return JsonSerializerWrapper.Serialize(this);
        }

        #endregion // Public Methods

        #region Operator Override(s)

        public static JsonMessage operator +(JsonMessage oFullMsg, JsonMessageSegment oSegment)
        {
            Validator.ValidateParam(oFullMsg);
            Validator.ValidateParam(oSegment);

            oFullMsg.Segments.Add(oSegment);

            return oFullMsg;
        }

        public static JsonMessage operator +(JsonMessage oMsgLeft, JsonMessage oMsgRight)
        {
            Validator.ValidateParam(oMsgLeft);
            Validator.ValidateParam(oMsgLeft);

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
                Thrower.ThrowInvalidOperationException(JsonErrorMessages.MessageSegmentInvalid(), nameof(Segments));
            }
        }

        #endregion // IValidatable
    }
}
