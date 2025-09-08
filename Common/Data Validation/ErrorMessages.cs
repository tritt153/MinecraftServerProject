namespace MinecraftServer.Common.General
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

        public static string StringNullOrEmpty(string sParamName)
        {
            return $"string: {sParamName} cannot be null or empty.";
        }

        public static string StringNullOrWhiteSpace(string sParamName)
        {
            return $"string: {sParamName} cannot be null or white space.";
        }


        #endregion // Invalid String
    }
}
