namespace MinecraftServerTests.Test_Utilities.Test_Factory
{
    /// <summary>
    /// FOR TESTING ONLY: Interface used for enforcing creation of minimally valid instances of testable objects.
    /// </summary>
    /// <typeparam name="T">The type of the object being created.</typeparam>
    public interface ITestFactory<T>
    {
        #region Public Methods - Static + Abstract

        public static abstract T GetMinimalValidInstance();

        #endregion // Public Methods - Static + Abstract
    }
}
