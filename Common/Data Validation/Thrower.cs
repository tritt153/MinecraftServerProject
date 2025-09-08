using System.Diagnostics.CodeAnalysis;

namespace MinecraftServer.Common.General
{
    public static class Thrower
    {
        #region Public Methods - Static

        [DoesNotReturn]
        public static void ThrowNullException(string sMessage, string sParamName)
        {
            throw new ArgumentNullException(sParamName, sMessage);
        }

        [DoesNotReturn]
        public static void ThrowNullOrEmptyException(string sMessage, string sParamName)
        {
            throw new ArgumentException(sMessage, sParamName);
        }

        [DoesNotReturn]
        public static void ThrowNullOrWhiteSpaceException(string sMessage, string sParamName)
        {
            throw new ArgumentException(sMessage, sParamName);
        }

        [DoesNotReturn]
        public static void ThrowArgumentException(string sMessage, string sParamName)
        {
            throw new ArgumentException(sMessage, sParamName);
        }

        [DoesNotReturn]
        public static void ThrowInvalidOperationException(string sMessage, string sParamName)
        {
            throw new InvalidOperationException(sMessage);
        }

        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException(string sMessage, string sParamName)
        {
            throw new ArgumentOutOfRangeException(sParamName, null, sMessage);
        }

        #endregion // Public Methods - Static
    }
}
