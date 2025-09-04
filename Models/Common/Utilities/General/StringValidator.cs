namespace MinecraftServer.Models.Common.Utilities.General
{
    public static class StringValidator
    {
        #region Constants

        #region Enumerations

        [Flags]
        public enum eStringValidationOptions
        {
            None            = 0,                                  // 0b00000000
            NotNull         = 1,                                  // 0b00000001
            NotEmpty        = 2,                                  // 0b00000010
            NotWhiteSpace   = 4,                                  // 0b00000100
            NotNullNotEmpty = NotNull | NotEmpty,                 // 0b00000011 (3)
            All             = NotNull | NotEmpty | NotWhiteSpace, // 0b00000111 (7)
        }

        #endregion // Enumerations

        #endregion // Constants

        #region Public Methods - Static

        public static void Validate(eStringValidationOptions eOptions, params string[] sParams)
        {
            if (sParams is null)
            {
                Thrower.ThrowNullException();
            }

            foreach (string sParam in sParams)
            {
                Validate(sParam, eOptions);
            }
        }

        public static void Validate(string sText, eStringValidationOptions eOptions, string? sParamName = null)
        {
            sParamName ??= nameof(sText);

            if (eOptions.HasFlag(eStringValidationOptions.NotNull) && sText is null)
            {
                Thrower.ThrowNullException(sParamName);
            }

            if (eOptions.HasFlag(eStringValidationOptions.NotEmpty) && string.IsNullOrEmpty(sText))
            {
                Thrower.ThrowNullOrEmptyException(sParamName);
            }

            if (eOptions.HasFlag(eStringValidationOptions.NotWhiteSpace) && string.IsNullOrWhiteSpace(sText))
            {
                Thrower.ThrowNullOrWhiteSpaceException(sParamName);
            }
        }

        #endregion // Public Methods - Static
    }
}
