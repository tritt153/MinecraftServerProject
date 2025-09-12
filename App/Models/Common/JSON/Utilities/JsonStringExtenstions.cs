using MinecraftServer.Models.Common.JSON.Events;
using MinecraftServer.Models.Common.JSON.Messages;
using static MinecraftServer.Models.Common.JSON.Constants.JsonConstants;
using static MinecraftServer.Models.Common.JSON.Utilities.JsonTextColor;

namespace MinecraftServer.Models.Common.JSON.Utilities
{
    public static class JsonStringExtenstions
    {
        #region Public Methods - Static

        #region Json Messages

        public static JsonMessageSegment Text(this string sText)
        {
            return new JsonMessageSegment(sText: sText);
        }

        public static JsonMessageSegment Color(this string sText, eTextColor eColor)
        {
            return new JsonMessageSegment(sText: sText, eColor: eColor);
        }

        public static JsonMessageSegment Bold(this string sText)
        {
            return new JsonMessageSegment(sText: sText, bBold: true);
        }

        public static JsonMessageSegment Italicize(this string sText)
        {
            return new JsonMessageSegment(sText: sText, bItalicize: true);
        }

        public static JsonMessageSegment Underline(this string sText)
        {
            return new JsonMessageSegment(sText: sText, bUnderline: true);
        }

        public static JsonMessageSegment Strikethrough(this string sText)
        {
            return new JsonMessageSegment(sText: sText, bStrikethrough: true);
        }

        public static JsonMessageSegment Obfuscate(this string sText)
        {
            return new JsonMessageSegment(sText: sText, bObfuscate: true);
        }

        public static JsonMessageSegment ClickEvent(this string sText, JsonClickEvent oClickEvent)
        {
            return new JsonMessageSegment(sText: sText, oClickEvent: oClickEvent);
        }

        public static JsonMessageSegment HoverEvent(this string sText, JsonHoverEvent oHoverEvent)
        {
            return new JsonMessageSegment(sText: sText, oHoverEvent: oHoverEvent);
        }

        public static JsonMessageSegment NewLine(this string sText, int nNumNewLines = 1)
        {
            return new JsonMessageSegment(sText: sText.Append(JSON_STRING_NEW_LINE, nNumNewLines));
        }

        public static JsonMessageSegment Space(this string sText, int nNumSpaces = 1)
        {
            return new JsonMessageSegment(sText: sText.Append(JSON_STRING_SPACE, nNumSpaces));
        }

        #endregion // Json Messages

        #region General

        public static string Append(this string sText, string sToAppend, int nRepeat = 1)
        {
            for (int nAppendIndex = 0; nAppendIndex < nRepeat; nAppendIndex++)
            {
                sText += sToAppend;
            }

            return sText;
        }

        #endregion // General

        #endregion // Public Methods - Static
    }
}
