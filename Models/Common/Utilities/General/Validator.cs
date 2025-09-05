namespace MinecraftServer.Models.Common.Utilities.General
{
    public static class Validator 
    {
        #region Public Methods - Static

        /// <summary>
        /// Takes multiple IValidatable objects and calls their validation method, to ensure all given parameters contain valid information
        /// </summary>
        /// <param name="oParams">Variable list of IValidatable objects</param>
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

        /// <summary>
        /// Validates the given IValidatable object.
        /// </summary>
        /// <typeparam name="TValidatable"></typeparam>
        /// <param name="oParam"></param>
        public static void ValidateParam<TValidatable>(TValidatable oParam) where TValidatable : IValidatable
        {
            oParam.Validate();
        }

        #endregion // Public Methods - Static
    }
}
