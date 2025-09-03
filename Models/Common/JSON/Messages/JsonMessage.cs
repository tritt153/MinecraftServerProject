using MinecraftServer.Models.Common.Utilities.General;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JsonMessages
{
    public class JsonMessage : IValidatable
    {
        #region Json Properties

        [NotNull]
        [JsonPropertyName("extra")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required List<JsonMessageSegment>? Segments { get; set; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonMessage(JsonMessageSegment oMsg)
        {
            Segments = [oMsg];
        }

        #endregion // Constructor

        #region Public Methods

        #endregion // Public Methods

        #region Operator Override(s)

        public static implicit operator JsonMessage(JsonMessageSegment oMsgSegment)
        {
            return new JsonMessage(oMsgSegment);
        }

        public static JsonMessage operator +(JsonMessage oFullMsg, JsonMessageSegment oSegment)
        {
            Validator.ValidateParams(oFullMsg, oSegment);

            oFullMsg.Segments.Add(oSegment);

            return oFullMsg;
        }

        public static JsonMessage operator +(JsonMessage oFullMsg, string sText)
        {
            StringValidation.Validate(sText, Validator.eStringValidationOptions.NotNullNotEmpty);
            Validator.ValidateParams(oFullMsg);

            oFullMsg.Segments.Add(new JsonMessageSegment(sText));

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
