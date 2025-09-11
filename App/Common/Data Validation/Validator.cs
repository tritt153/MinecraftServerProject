using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MinecraftServer.Common.General
{
    public static class Validator
    {
        #region Constants

        #region String Validation Options

        [Flags]
        public enum eStringValidationOptions
        {
            None = 0,                                       // 0b000
            NotNull = 1,                                    // 0b001
            NotEmpty = 2,                                   // 0b010
            NotWhiteSpace = 4,                              // 0b100
            NotNullNotEmpty = NotNull | NotEmpty,           // 0b011 (3)
            NotNullNotWhitespace = NotNull | NotWhiteSpace, // 0b101 (5)
            All = NotNull | NotEmpty | NotWhiteSpace,       // 0b111 (7)
        }

        #endregion // String Validation Options

        #endregion // Constants

        #region Public Methods - Static

        public static void CheckNull([NotNull] object? oParam,
                                     string sMessage = "",
                                     [CallerArgumentExpression(nameof(oParam))] string sParamName = "")
        {
            if (oParam is null)
            {
                //
                // If no custom message is defined, use boiler plate null error message.
                // 
                sMessage = string.IsNullOrEmpty(sMessage) ? ErrorMessages.PropertyNull(sParamName) : sMessage;
                Thrower.ThrowNullException(sParamName, sMessage);
            }
        }

        /// <summary>
        /// Validates the given IValidatable object.
        /// </summary>
        /// <typeparam name="TValidatable"></typeparam>
        /// <param name="oParam"></param>
        public static void ValidateParams(string sMessage = "", [NotNull] params IValidatable[] oParams)
        {
            CheckNull(oParams);

            for (int nParameterIndex = 0; nParameterIndex < oParams.Length; nParameterIndex++)
            {
                string sParamName = $"Parameter Index: {nParameterIndex}";

                ValidateParam(oParams[nParameterIndex], sMessage, sParamName);
            }
        }

        /// <summary>
        /// Validates the given IValidatable object.
        /// </summary>
        /// <param name="oParam">The IValidatable object to validate.</param>
        public static void ValidateParam([NotNull] IValidatable oParam, 
                                         string sMessage = "", 
                                         [CallerArgumentExpression(nameof(oParam))] string sParamName = "")
        {
            CheckNull(oParam, sMessage, sParamName);
            oParam.Validate();
        }

        public static void ValidateString(string? sValue, 
                                          eStringValidationOptions eOptions = eStringValidationOptions.All, 
                                          string sMessage = "", 
                                          [CallerArgumentExpression(nameof(sValue))] string sParamName = "")
        {
            if (eOptions.HasFlag(eStringValidationOptions.NotNull))
            {
                CheckNull(sValue, sMessage, sParamName);
            }

            if (eOptions.HasFlag(eStringValidationOptions.NotEmpty))
            {
                StringValidator.CheckEmpty(sValue, sMessage, sParamName);
            }

            if (eOptions.HasFlag(eStringValidationOptions.NotWhiteSpace))
            {
                StringValidator.CheckWhiteSpace(sValue, sMessage, sParamName);
            }
        }

        #endregion // Public Methods - Static
    }
}
