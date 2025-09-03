namespace MinecraftServer.Models.Common.Utilities.General
{
    public static class Validator
    {
        #region Constants

        #region Enumerations

        [Flags]
        public enum eStringValidationOptions
        {
            None                = 0,                                  // 0b00000000
            NotNull             = 1,                                  // 0b00000001
            NotEmpty            = 2,                                  // 0b00000010
            NotWhiteSpace       = 4,                                  // 0b00000100
            NotNullNotEmpty     = NotNull | NotEmpty,                 // 0b00000011 (3)
            All                 = NotNull | NotEmpty | NotWhiteSpace, // 0b00000111 (7)
        }

        #endregion // Enumerations

        #endregion // Constants

        #region Public Methods - Static

        public static void ValidateStrings(eStringValidationOptions eOptions, params string[] sParams)
        {
            if (sParams is null)
            {
                Thrower.ThrowNullException(); // compiler too dumb to realize this always throws.
                return;
            }

            foreach (string sParam in sParams)
            {
                StringValidation.Validate(sParam, eOptions);
            }
        }

        public static void ValidateParams<TValidatable>(params TValidatable[] oParams) where TValidatable : IValidatable
        {
            if (oParams is null)
            {
                Thrower.ThrowNullException(); // compiler too dumb to realize this always throws.
            }

            foreach (var oParam in oParams)
            {
                if (oParam is null)
                {
                    Thrower.ThrowNullException(sMessage: "Parameter cannot be null.");
                }

                oParam.Validate();
            }
        }

        #endregion // Public Methods - Static
    }
}
