using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MinecraftServer.Common.Data_Validation
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

        /// <summary>
        /// Checks if the given object is null.
        /// </summary>
        /// <param name="oParam">The object to check</param>
        /// <param name="sMessage">Exception message</param>
        /// <param name="sParamName">The name of the object being checked</param>
        /// <exception cref="ArgumentNullException">Throws if the object is null</exception>
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
                Thrower.ThrowArgumentNullException(sParamName, sMessage);
            }
        }

        /// <summary>
        /// Validates the given <see cref="IValidatable"/> object(s).
        /// </summary>
        /// <param name="sMessage">The exception message</param>
        /// <param name="oParams">The variable list of <see cref="IValidatable"/> objects to validate</param>
        /// <exception cref="ArgumentNullException"/>
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
        /// Validates the given <see cref="IValidatable"/> object.
        /// </summary>
        /// <param name="oParam">The <see cref="IValidatable"/> object to validate.</param>
        /// <exception cref="ArgumentNullException"/>
        public static void ValidateParam([NotNull] IValidatable oParam, 
                                         string sMessage = "", 
                                         [CallerArgumentExpression(nameof(oParam))] string sParamName = "")
        {
            CheckNull(oParam, sMessage, sParamName);
            oParam.Validate();
        }

        /// <summary>
        /// Validates the given <see cref="string"/>, using<see cref="eStringValidationOptions"/> to determine what is considered valid.
        /// </summary>
        /// <param name="sValue">The string to validate</param>
        /// <param name="eOptions">The enum representing what is considered a valid string</param>
        /// <param name="sMessage">The exception message if the string is invalid</param>
        /// <param name="sParamName">The name of the variable being validated</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
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
