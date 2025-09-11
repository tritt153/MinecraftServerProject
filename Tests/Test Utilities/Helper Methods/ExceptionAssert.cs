namespace MinecraftServerTests.Test_Utilities.Helper_Methods
{
    internal static class ExceptionAssert
    {
        #region Internal Methods - Static

        internal static void Throws(Type? tExpectedExceptionType, Action oAction)
        {
            Exception? exExpectedException = Record.Exception(oAction);

            //
            // If the Action is expected to throw an exception, make sure it threw the expected one.
            //
            if (tExpectedExceptionType is not null)
            {
                Assert.NotNull(exExpectedException);
                Assert.IsType(tExpectedExceptionType, exExpectedException);
            }
            else
            {
                //
                // Otherwise ensure it threw nothing.
                //
                Assert.Null(exExpectedException);
            }
        }

        internal static void DoesNotThrow(Action oAction)
        {
            Exception? exExpectedException = Record.Exception(oAction);
            Assert.Null(exExpectedException);
        }

        #endregion // Internal Methods - Static
    }
}
