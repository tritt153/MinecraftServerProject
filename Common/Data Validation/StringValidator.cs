using System.Diagnostics.CodeAnalysis;

namespace MinecraftServer.Common.General
{
    internal static class StringValidator
    {
        #region Public Methods - Static

        internal static void CheckNullOrEmpty([NotNull] string? sValue, string sMessage, string sParamName)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                sMessage = string.IsNullOrEmpty(sMessage) ? ErrorMessages.StringNullOrEmpty(sParamName) : sMessage;
                Thrower.ThrowNullOrEmptyException(sMessage, sParamName);    
            }
        }

        internal static void CheckNullOrWhiteSpace([NotNull] string? sValue, string sMessage, string sParamName)
        {
            if (string.IsNullOrWhiteSpace(sValue))
            {
                sMessage = string.IsNullOrEmpty(sMessage) ? ErrorMessages.StringNullOrWhiteSpace(sParamName) : sMessage;
                Thrower.ThrowNullOrWhiteSpaceException(sMessage, sParamName);
            }
        }

        #endregion // Public Methods - Static
    }
}
