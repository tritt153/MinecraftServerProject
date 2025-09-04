namespace MinecraftServer.Models.Common.Utilities.General
{
    public static class Validator
    {
        #region Public Methods - Static

        public static void ValidateParams(params IValidatable[] oParams)
        {
            if (oParams is null)
            {
                Thrower.ThrowNullException();
            }

            foreach (var oParam in oParams)
            {
                if (oParam is null)
                {
                    Thrower.ThrowNullException(sMessage: "Parameter cannot be null.");
                }

                ValidateParam(oParam);
            }
        }

        public static void ValidateParam<TValidatable>(TValidatable oParam) where TValidatable : IValidatable
        {
            oParam.Validate();
        }

        #endregion // Public Methods - Static
    }
}
