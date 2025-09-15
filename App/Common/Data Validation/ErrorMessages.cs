namespace MinecraftServer.Common.Data_Validation
{
    public static class ErrorMessages
    {
        #region Null Value

        public static string PropertyNull(string sPropertyName)
        {
            return $"Property: {sPropertyName} cannot be null or empty.";
        }

        #endregion // Null Value

        #region Invalid Parameter

        public static string ParamInvalid(string sParamName)
        {
            return $"Parameter: {sParamName} is invalid.";
        }

        #endregion // Invalid Parameter

        #region Invalid String

        public static string StringWhiteSpace(string sParamName)
        {
            return $"string: {sParamName} cannot be white space.";
        }

        public static string StringEmpty(string sParamName)
        {
            return $"string: {sParamName} cannot be empty.";
        }

        #endregion // Invalid String
    }
}
