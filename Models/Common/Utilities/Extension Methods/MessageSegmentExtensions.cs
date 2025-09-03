using MinecraftServer.Models.Common.Json_Messages;
using MinecraftServer.Models.Common.Json_Messages.Json_Events;
using MinecraftServer.Models.Common.JsonMessages;
using static MinecraftServer.Models.Common.Constants.Constants;
using static MinecraftServer.Models.Common.Json_Messages.Constants.JsonTextColor;

namespace MinecraftServer.Models.Common.Utilities.Extension_Methods
{
    public static class MessageSegmentExtensions
    {
        #region Public Methods - Static

        public static JsonMessageSegment Color(this JsonMessageSegment oMsg, eTextColor eColor)
        {
            return oMsg with { Color = eColor };
        }

        public static JsonMessageSegment Bold(this JsonMessageSegment oMsg)
        {
            return oMsg with { Bold = true };
        }

        public static JsonMessageSegment Italicize(this JsonMessageSegment oMsg)
        {
            return oMsg with { Italicize = true };
        }

        public static JsonMessageSegment Underline(this JsonMessageSegment oMsg)
        {
            return oMsg with { Underline = true };
        }

        public static JsonMessageSegment Strikethrough(this JsonMessageSegment oMsg)
        {
            return oMsg with { Strikethrough = true };
        }

        public static JsonMessageSegment Obfuscate(this JsonMessageSegment oMsg)
        {
            return oMsg with { Obfuscate = true };
        }

        public static JsonMessageSegment ClickEvent(this JsonMessageSegment oMsg, JsonClickEvent oClickEvent)
        {
            return oMsg with { ClickEvent = oClickEvent };
        }

        public static JsonMessageSegment HoverEvent(this JsonMessageSegment oMsg, JsonHoverEvent oHoverEvent)
        {
            return oMsg with { HoverEvent = oHoverEvent };
        }

        public static JsonMessageSegment NewLine(this JsonMessageSegment oMsg, int nNumNewLines = 1)
        {
            return oMsg with { Text = oMsg.Text.Append(STRING_NEW_LINE, nNumNewLines) };
        }

        public static JsonMessageSegment Space(this JsonMessageSegment oMsg, int nNumNewSpaces = 1)
        {
            return oMsg with { Text = oMsg.Text.Append(STRING_SPACE, nNumNewSpaces) };
        }

        #endregion // Public Methods - Static
    }
}
