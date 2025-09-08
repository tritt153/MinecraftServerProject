using MinecraftServer.Common.General;
using MinecraftServer.Models.Common.JSON.Constants;

namespace MinecraftServer.Models.Common.JSON.Messages
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
        private static readonly Dictionary<eTextColor, string> _dicColors = new Dictionary<eTextColor, string>()
        {
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

        #region Public Methods - Static

        public static string GetString(this eTextColor eColor)
        {
            if (!_dicColors.ContainsKey(eColor))
            {
                Thrower.ThrowArgumentOutOfRangeException(JsonErrorMessages.TextColorNotFound(), nameof(_dicColors));
            }
            
            return _dicColors[eColor];
        }

        #endregion // Public Methods - Static
    }
}
