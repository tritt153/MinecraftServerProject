using System.Diagnostics.CodeAnalysis;

namespace MinecraftServer.Common.Data_Validation
{
    internal static class StringValidator
    {
        #region Public Methods - Static

        /// <summary>
        /// Throws an ArgumentException iff the given string is the empty string -> "", othewise does nothing.
        /// </summary>
        /// <param name="sValue">The value to check.</param>
        /// <param name="sMessage">The exception message.</param>
        /// <param name="sParamName">The name of the parameter being checked.</param>
        /// <exception cref="ArgumentException"/>
        internal static void CheckEmpty(string? sValue, string sMessage = "", string sParamName = "")
        {
            if (sValue is not null)
            {
                if (string.IsNullOrEmpty(sValue))
                {
                    sMessage = string.IsNullOrEmpty(sMessage) ? ErrorMessages.StringEmpty(sParamName) : sParamName;
                    Thrower.ThrowEmptyStringException(sMessage, sParamName);
                }
            }
        }

        /// <summary>
        /// Throws an error iff the given string contains only white space, otherwise does nothing.
        /// </summary>
        /// <param name="sValue">The value to check.</param>
        /// <param name="sMessage">The exception message.</param>
        /// <param name="sParamName">The name of the parameter being checked.</param>
        /// <exception cref="ArgumentException"/>
        internal static void CheckWhiteSpace(string? sValue, string sMessage = "", string sParamName = "")
        {
            if (sValue is not null)
            {
                if (!string.IsNullOrEmpty(sValue))
                {
                    if (string.IsNullOrWhiteSpace(sValue))
                    {
                        sMessage = string.IsNullOrEmpty(sMessage) ? ErrorMessages.StringWhiteSpace(sParamName) : sParamName;
                        Thrower.ThrowWhiteSpaceStringException(sMessage, sParamName);
                    }
                }
            }
        }

        #endregion // Public Methods - Static
    }
}
