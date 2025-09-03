using MinecraftServer.Models.Common.Json_Messages;
using MinecraftServer.Models.Common.Json_Messages.Json_Events;
using MinecraftServer.Models.Common.JsonMessages;
using static MinecraftServer.Models.Common.Constants.Constants;
using static MinecraftServer.Models.Common.Json_Messages.Constants.JsonTextColor;

namespace MinecraftServer.Models.Common.Utilities.Extension_Methods
{
    public static class StringExtenstions
    {
        #region Public Methods - Static

        #region Json Messages

        public static JsonMessageSegment Color(this string oText, eTextColor eColor)
        {
            return new JsonMessageSegment(oText, eColor);
        }

        public static JsonMessageSegment Bold(this string oText)
        {
            return new JsonMessageSegment(oText, bBold: true);
        }

        public static JsonMessageSegment Italicize(this string oText)
        {
            return new JsonMessageSegment(oText, bItalicize: true);
        }

        public static JsonMessageSegment Underline(this string oText)
        {
            return new JsonMessageSegment(oText, bUnderline: true);
        }

        public static JsonMessageSegment StrikeThrough(this string oText)
        {
            return new JsonMessageSegment(oText, bStrikethrough: true);
        }

        public static JsonMessageSegment Obfuscate(this string oText)
        {
            return new JsonMessageSegment(oText, bObfuscate: true);
        }

        public static JsonMessageSegment ClickEvent(this string oText, JsonClickEvent oClickEvent)
        {
            return new JsonMessageSegment(oText, oClickEvent: oClickEvent);
        }

        public static JsonMessageSegment HoverEvent(this string oText, JsonHoverEvent oHoverEvent)
        {
            return new JsonMessageSegment(oText, oHoverEvent: oHoverEvent);
        }

        public static JsonMessageSegment NewLine(this string oText, int nNumNewLines = 1)
        {
            return new JsonMessageSegment(oText.Append(STRING_NEW_LINE, nNumNewLines));
        }

        public static JsonMessageSegment Space(this string oText, int nNumSpaces = 1)
        {
            return new JsonMessageSegment(oText.Append(STRING_SPACE, nNumSpaces));
        }

        #endregion // Json Messages

        #region General

        public static string Append(this string oText, string sToAppend, int nRepeat = 1)
        {
            for (int nNewLineIndex = 0; nNewLineIndex < nRepeat; nNewLineIndex++)
            {
                oText += sToAppend;
            }

            return oText;
        }

        #endregion // General

        #endregion // Public Methods - Static
    }
}
