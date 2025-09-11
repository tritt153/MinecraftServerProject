using MinecraftServer.Common.General;
using System.Diagnostics.CodeAnalysis;
using static MinecraftServer.Logging.Constants.LogConstants;

namespace MinecraftServer.Logging
{
    internal partial class LogObject
    {
        #region Properties

        internal string LogMessage { get; init; } = string.Empty;

        internal string CallerFile { get; init; } = string.Empty;

        internal string CallerName { get; init; } = string.Empty;

        internal eLogCategory LogCategory { get; init; } = eLogCategory.None;

        internal int CallerLineNum { get; init; } = 0;

        internal bool IsException
        {
            get
            {
                return LogCategory == eLogCategory.Exception;
            }
        }


        #endregion // Properties

        #region Constructor

        /// <summary>
        /// Constructor for an object to hold data about something we want to log.
        /// </summary>
        /// <param name="sLogMessage">The custom message to be logged.</param>
        /// <param name="sCallerFile">The file path of the caller.</param>
        /// <param name="sCallerName">The name of the caller.</param>
        /// <param name="nCallerLineNum">The line number where the log was called from.</param>
        internal LogObject(string sLogMessage, eLogCategory eLogCategory, [NotNull] string sCallerFile, [NotNull] string sCallerName, int nCallerLineNum)
        {
            //
            // Split the file path string by '\' if it is not null.
            // (e.g. C:\Test\Hello.cs => ["C:"], ["Test"], ["Hello.cs"])
            // 
            string[] arrLogFileSplit = sCallerFile.Split('\\');

            //
            // Only care about the last part of the file path (the .cs file)
            // (e.g. "MainTest.cs")
            //
            if (arrLogFileSplit != null && arrLogFileSplit.Length > 0)
            {
                CallerFile = arrLogFileSplit[^1];
            }

            LogMessage = sLogMessage;
            LogCategory = eLogCategory;
            CallerName = sCallerName;
            CallerLineNum = nCallerLineNum;
        }

        #endregion // Constructor
    }
}
