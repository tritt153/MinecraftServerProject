using static MinecraftServer.Models.Common.Utilities.General.Validator;

namespace MinecraftServer.Models.Common.Utilities.General
{
    public static class StringValidation
    {
        #region Public Methods - Static

        public static void Validate(string sText, eStringValidationOptions eOptions, string? sParamName = null)
        {
            if (sParamName is null)
            {
                sParamName = nameof(sText);
            }

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
