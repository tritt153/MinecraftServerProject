using MinecraftServer.Common.Data_Validation;
using MinecraftServer.Models.Common.JSON.Constants;
using MinecraftServer.Models.Common.JSON.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Messages
{
    public class JsonMessage : IValidatable
    {
        #region Json Properties

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
        public JsonMessage(params JsonMessageSegment[] oSegments)
        {
            Validator.ValidateParams(JsonErrorMessages.MessageSegmentInvalid(), oSegments);

            Segments = [.. oSegments];
        }

        #endregion // Constructor

        #region ToString 

        /// <summary>
        /// Serializes this object into a JSON string.
        /// </summary>
        /// <returns>string - The JSON message as a formatted string.</returns>
        /// <seealso cref="JsonSerializerWrapper"/>
        public override string ToString()
        {
            return JsonSerializerWrapper.Serialize(this);
        }

        #endregion // Public Methods

        #region Operator Override(s)

        public static JsonMessage operator +(JsonMessage oFullMsg, JsonMessageSegment oSegment)
        {
            Validator.ValidateParams(JsonErrorMessages.MessageSegmentInvalid(), oFullMsg, oSegment);

            oFullMsg.Segments.Add(oSegment);

            return oFullMsg;
        }

        public static JsonMessage operator +(JsonMessage oMsgLeft, JsonMessage oMsgRight)
        {
            Validator.ValidateParams(JsonErrorMessages.MessageSegmentInvalid(), oMsgLeft, oMsgRight);

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
            if (Segments is null)
            {
                Thrower.ThrowArgumentNullException(JsonErrorMessages.MessageNullSegments(), nameof(Segments));
            }
            else if (Segments.Count == 0)
            {
                Thrower.ThrowArgumentException(JsonErrorMessages.MessageNoSegments(), nameof(Segments));
            }
            else
            {
                foreach (JsonMessageSegment oSegment in Segments)
                {
                    oSegment.Validate();
                }
            }
        }

        #endregion // IValidatable
    }
}
