using MinecraftServer.Models.Common.Json_Messages;
using MinecraftServer.Models.Common.Json_Messages.Json_Events;
using MinecraftServer.Models.Common.Utilities.General;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using static MinecraftServer.Models.Common.Json_Messages.Constants.JsonTextColor;

namespace MinecraftServer.Models.Common.JsonMessages
{
    public record JsonMessageSegment : IValidatable
    {
        #region Json Properties

        [NotNull] // or empty
        [JsonPropertyName("text")]
        public required string Text { get; init; }

        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required eTextColor Color { get; init; }

        [JsonPropertyName("bold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required bool? Bold { get; init; }

        [JsonPropertyName("italic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required bool? Italicize { get; init; }

        [JsonPropertyName("underlined")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required bool? Underline { get; init; }

        [JsonPropertyName("strikethrough")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required bool? Strikethrough { get; init; }

        [JsonPropertyName("obfuscated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required bool? Obfuscate { get; init; }

        [JsonPropertyName("clickEvent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required JsonClickEvent? ClickEvent { get; init; }

        [JsonPropertyName("hoverEvent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public required JsonHoverEvent? HoverEvent { get; init; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonMessageSegment(string sText, eTextColor eColor = DEFAULT_TEXT_COLOR, bool? bBold = null, bool? bItalicize = null, bool? bUnderline = null, bool? bStrikethrough = null, bool? bObfuscate = null, JsonClickEvent? oClickEvent = null, JsonHoverEvent? oHoverEvent = null)
        {
            if (string.IsNullOrEmpty(sText))
            {
                throw new ArgumentNullException(nameof(sText));
            }

            Text = sText;
            Color = eColor;
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
            StringValidation.Validate(Text, Validator.eStringValidationOptions.All, nameof(Text));
        }

        #endregion // Constructor
    }
}
