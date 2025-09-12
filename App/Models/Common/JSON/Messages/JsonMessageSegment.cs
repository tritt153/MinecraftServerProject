using MinecraftServer.Common.General;
using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using static MinecraftServer.Models.Common.JSON.Utilities.JsonTextColor;

namespace MinecraftServer.Models.Common.JSON.Messages
{
    public record JsonMessageSegment : IValidatable
    {
        #region Json Properties

        [NotNull] // or empty
        [JsonPropertyName("text")]
        public required string Text { get; init; }

        [JsonIgnore]
        public eTextColor Color
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ColorString))
                {
                    return DEFAULT_TEXT_COLOR;
                }
                else
                {
                    return JsonTextColor.GetTextColorEnum(ColorString);
                }
            }
        }

        [NotNull]
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ColorString { get; init; }

        [JsonPropertyName("bold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Bold { get; init; }

        [JsonPropertyName("italic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Italicize { get; init; }

        [JsonPropertyName("underlined")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Underline { get; init; }

        [JsonPropertyName("strikethrough")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Strikethrough { get; init; }

        [JsonPropertyName("obfuscated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Obfuscate { get; init; }

        [JsonPropertyName("clickEvent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public JsonClickEvent? ClickEvent { get; init; }

        [JsonPropertyName("hoverEvent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public JsonHoverEvent? HoverEvent { get; init; }

        #endregion // Json Properties

        #region Constructor

        [JsonConstructor]
        public JsonMessageSegment() { }

        [SetsRequiredMembers]
        public JsonMessageSegment(string sText, eTextColor eColor = eTextColor.None , bool? bBold = null, bool? bItalicize = null, bool? bUnderline = null, bool? bStrikethrough = null, bool? bObfuscate = null, JsonClickEvent? oClickEvent = null, JsonHoverEvent? oHoverEvent = null)
        {
            Validator.ValidateString(sText, Validator.eStringValidationOptions.NotNullNotEmpty);

            Text = sText;
            ColorString = eColor.GetString();
            Bold = bBold;
            Italicize = bItalicize;
            Underline = bUnderline;
            Strikethrough = bStrikethrough;
            Obfuscate = bObfuscate;
            ClickEvent = oClickEvent;
            HoverEvent = oHoverEvent;
        }

        #endregion // Constructor

        #region Operator Override(s)

        /// <summary>
        /// Implicitly converts a single segment into a full message, so a segment can be use in context's that expect a 'full' message.
        /// </summary>
        /// <param name="oSegment">JsonMessageSegment - The segment to convert.</param>
        public static implicit operator JsonMessage(JsonMessageSegment oSegment)
        {
            Validator.ValidateParam(oSegment);

            return new JsonMessage(oSegment);
        }

        /// <summary>
        /// Implicitly converts a string into a message segment with no proerties default properties.
        /// </summary>
        /// <param name="oSegment">JsonMessageSegment - The segment to convert.</param>
        public static implicit operator JsonMessageSegment(string sText)
        {
            return new JsonMessageSegment(sText);
        }

        public static JsonMessage operator +(JsonMessageSegment oSegmentLeft, JsonMessageSegment oSegmentRight)
        {
            Validator.ValidateParam(oSegmentLeft);
            Validator.ValidateParam(oSegmentRight);

            return new JsonMessage(oSegmentLeft, oSegmentRight);
        }

        #endregion // Operator Override(s)

        #region IValidatable

        public void Validate()
        {
            Validator.ValidateString(Text, Validator.eStringValidationOptions.NotNullNotEmpty);
        }

        #endregion // IValidatable
    }
}
