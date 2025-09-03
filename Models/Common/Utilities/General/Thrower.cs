using System.Diagnostics.CodeAnalysis;

namespace MinecraftServer.Models.Common.Utilities.General
{
    public static class Thrower
    {
        #region Public Methods - Static

        [DoesNotReturn]
        public static void ThrowNullException(string sParamName = "", string sMessage = "Value cannot be null.")
        {
            throw new ArgumentNullException(sParamName, sMessage);
        }

        [DoesNotReturn]
        public static void ThrowNullOrEmptyException(string sParamName = "", string sMessage = "Value cannot be null or empty.")
        {
            throw new ArgumentException(sParamName, sMessage);
        }

        [DoesNotReturn]
        public static void ThrowNullOrWhiteSpaceException(string sParamName = "", string sMessage = "Value cannot be null or white space.")
        {
            throw new ArgumentException(sParamName, sMessage);
        }

        [DoesNotReturn]
        public static void ThrowArgumentException(string sParamName = "", string sMessage = "Invalid argument.")
        {
            throw new ArgumentException(sParamName, sMessage);
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException(string sMessage = "Invalid operation.")
        {
            throw new InvalidOperationException(sMessage);
        }

        #endregion // Public Methods - Static
    }
}
