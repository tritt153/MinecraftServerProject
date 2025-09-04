using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.Utilities.General;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using static MinecraftServer.Models.Common.JSON.Constants.JsonTextColor;

namespace MinecraftServer.Models.Common.JSON.Messages
{
    public record JsonMessageSegment : IValidatable
    {
        #region Json Properties

        [NotNull] // or empty
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required string Text { get; init; }

        [JsonIgnore]
        public required eTextColor Color { get; init; }

        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required string ColorString { get; init; }

        [JsonPropertyName("bold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required bool? Bold { get; init; }

        [JsonPropertyName("italic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required bool? Italicize { get; init; }

        [JsonPropertyName("underlined")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required bool? Underline { get; init; }

        [JsonPropertyName("strikethrough")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required bool? Strikethrough { get; init; }

        [JsonPropertyName("obfuscated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required bool? Obfuscate { get; init; }

        [JsonPropertyName("clickEvent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required JsonClickEvent? ClickEvent { get; init; }

        [JsonPropertyName("hoverEvent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required JsonHoverEvent? HoverEvent { get; init; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonMessageSegment(string sText, eTextColor eColor = DEFAULT_TEXT_COLOR, bool? bBold = null, bool? bItalicize = null, bool? bUnderline = null, bool? bStrikethrough = null, bool? bObfuscate = null, JsonClickEvent? oClickEvent = null, JsonHoverEvent? oHoverEvent = null)
        {
            StringValidator.Validate(sText, StringValidator.eStringValidationOptions.NotNullNotEmpty, nameof(sText));

            Text = sText;
            Color = eColor;
            ColorString = eColor.GetString();
            Bold = bBold;
            Italicize = bItalicize;
            Underline = bUnderline;
            Strikethrough = bStrikethrough;
            Obfuscate = bObfuscate;
            ClickEvent = oClickEvent;
            HoverEvent = oHoverEvent;
        }

        public void Validate()
        {
            StringValidator.Validate(Text, StringValidator.eStringValidationOptions.NotNullNotEmpty, nameof(Text));
        }

        #endregion // Constructor

        #region Operator Override(s)

        /// <summary>
        /// Implicitly converts a signle segment into a full message, so a segment can be use in context's that expect a 'full' message.
        /// </summary>
        /// <param name="oSegment">JsonMessageSegment - The segment to convert.</param>
        public static implicit operator JsonMessage(JsonMessageSegment oSegment)
        {
            return new JsonMessage(oSegment);
        }

        public static JsonMessage operator +(JsonMessageSegment oSegmentLeft, JsonMessageSegment oSegmentRight)
        {
            Validator.ValidateParams(oSegmentLeft, oSegmentRight);

            return new JsonMessage(oSegmentLeft, oSegmentRight);
        }

        public static JsonMessage operator +(string sText, JsonMessageSegment oFullMsg)
        {
            StringValidator.Validate(sText, StringValidator.eStringValidationOptions.NotNullNotEmpty);
            Validator.ValidateParams(oFullMsg);

            return new JsonMessage(new JsonMessageSegment(sText));
        }

        public static JsonMessage operator +(JsonMessageSegment oFullMsg, string sText)
        {
            return sText + oFullMsg;
        }

        #endregion // Operator Override(s)
    }
}
