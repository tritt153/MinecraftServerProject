namespace MinecraftServerTests.Utilities
{
    /// <summary>
    /// FOR TESTING ONLY: Interface used for enforcing creation of minimally valid instances of testable objects.
    /// </summary>
    /// <typeparam name="T">The type of the object being created.</typeparam>
    public interface ITestFactory<T>
    {
        #region Public Methods - Static + Abstract

        /// <summary>
        /// Creates an object that is guaranteed to be valid, and contain only necessary information.
        /// </summary>
        /// <returns>A minimally valid instance of this class.</returns>
        public static abstract T GetMinimallyValidInstance();

        /// <summary>
        /// Tests if the given object is a minimally valid instance of it's type.
        /// </summary>
        /// <param name="oInstance">The instance to check</param>
        /// <returns>True if the given instance is the minimal valid instance, false otherwise./></returns>
        public static abstract bool IsMinimallyValidInstance(T oInstance);

        #endregion // Public Methods - Static + Abstract
    }
}
