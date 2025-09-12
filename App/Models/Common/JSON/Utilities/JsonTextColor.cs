using MinecraftServer.Common.General;
using MinecraftServer.Models.Common.JSON.Constants;

namespace MinecraftServer.Models.Common.JSON.Utilities
{
    public static class JsonTextColor
    {
        #region Constants

        #region General

        public const eTextColor DEFAULT_TEXT_COLOR = eTextColor.White;

        #endregion // General

        #region Color Dictionary

        /// <summary>
        /// Dictionary of enum keys mapping all available text colors in Minecraft, in their expected string format. 
        /// </summary>
        private static readonly Dictionary<eTextColor, string?> _dicColors = new Dictionary<eTextColor, string?>()
        {
            [eTextColor.None] = null, //return null so JSON will ignore.
            [eTextColor.Black] = "black",
            [eTextColor.DarkBlue] = "dark_blue",
            [eTextColor.DarkGreen] = "dark_green",
            [eTextColor.DarkAqua] = "dark_aqua",
            [eTextColor.DarkRed] = "dark_red",
            [eTextColor.DarkPurple] = "dark_purple",
            [eTextColor.Gold] = "gold",
            [eTextColor.Gray] = "gray",
            [eTextColor.DarkGray] = "dark_gray",
            [eTextColor.Blue] = "blue",
            [eTextColor.Green] = "green",
            [eTextColor.Aqua] = "aqua",
            [eTextColor.Red] = "red",
            [eTextColor.LightPurple] = "light_purple",
            [eTextColor.Yellow] = "yellow",
            [eTextColor.White] = "white",
        };

        #endregion // Color Dictionary

        #region Enumerations

        public enum eTextColor
        {
            None,
            Black,
            DarkBlue,
            DarkGreen,
            DarkAqua,
            DarkRed,
            DarkPurple,
            Gold,
            Gray,
            DarkGray,
            Blue,
            Green,
            Aqua,
            Red,
            LightPurple,
            Yellow,
            White
        }

        #endregion // Enumerations

        #endregion // Constants

        #region Public Extension Methods - Static

        public static string? GetString(this eTextColor eColor)
        {
            if (!_dicColors.ContainsKey(eColor))
            {
                Thrower.ThrowArgumentOutOfRangeException(JsonErrorMessages.TextColorNotFound(), nameof(_dicColors));
            }

            return _dicColors[eColor];
        }

        public static eTextColor GetTextColorEnum(this string sColor)
        {
            if (!_dicColors.ContainsValue(sColor))
            {
                Thrower.ThrowArgumentOutOfRangeException(JsonErrorMessages.TextColorNotFound(), nameof(_dicColors));
            }

            foreach (KeyValuePair<eTextColor, string?> kvpColor in _dicColors)
            {
                if (kvpColor.Value == sColor)
                {
                    return kvpColor.Key;
                }
            }

            return DEFAULT_TEXT_COLOR;
        }

        #endregion // Public Methods - Static
    }
}
