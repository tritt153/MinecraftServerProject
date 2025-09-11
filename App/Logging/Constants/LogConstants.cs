namespace MinecraftServer.Logging.Constants
{
    internal static class LogConstants
    {
        #region Enumerations

        internal enum eLogCategory
        {
            None = -1,
            StartEnd,
            Info,
            Object,
            Action,
            ValueChanged,
            Warning,
            Error,
            Exception,
            Critical,

        }

        #endregion // Enumerations

        #region Regex

        public const string FILE_INFO_REGEX = @"\[FILE:\s([^\s,]+),\sMETHOD:\s([^\s,]+),\sLINE:\s(\d+)\]";

        #endregion // Regex

        #region Message Formats

        /// <summary>
        /// Constant that holds format for non-exception log messages
        /// </summary>
        internal const string LOG_MESSAGE_FORMAT = "{0}: {1} --- [FILE: {2}, METHOD: {3}, LINE: {4}] --> {5}";

        /// <summary>
        /// Holds the format for times in files.
        /// </summary>
        internal const string LOG_MESSAGE_TIME_FORMAT = @"MMM. dd @ hh:mm:ss.fff tt";

        #endregion // Message Formats

        #region Files/Folders

        /// <summary>
        /// Constant to hold where log files should be stored.
        /// </summary>
        internal const string LOG_FOLDER_PATH = @"MinecraftServer\ServerLog";

        /// <summary>
        /// Constant that holds format for file naming.
        /// </summary>
        internal const string LOG_FILE_NAME_FORMAT_DATE = "ServerLog{0}{1}";

        /// <summary>
        /// Holds string fomratting for name a file with time appended.
        /// </summary>
        internal const string LOG_FILE_NAME_FORMAT_TIME = "ServerLog{0}_{1}{2}";

        /// <summary>
        /// Constant to hold how dates are to be formatted.
        /// </summary>
        internal const string LOG_FILE_DATE_FORMAT = @"yyyyMMdd";

        /// <summary>
        /// Holds the format for times in file names.
        /// </summary>
        internal const string LOG_FILE_TIME_FORMAT = @"hhmmsstt";

        /// <summary>
        /// Holds the maximum number of bytes the file can take up.
        /// </summary>
        internal const int LOG_FILE_MAX_SIZE_KB = 4096; // 4MB

        /// <summary>
        /// Holds the conversion ratio of bytes to kilo bytes (1 kb = 1024 b)
        /// </summary>
        internal const int LOG_FILE_KB_TO_B = 1024;

        /// <summary>
        /// The maximum number of days we want to keep a log file for.
        /// </summary>
        internal const int LOG_FILE_MAX_AGE_DAYS = 10;

        /// <summary>
        /// Constant to hold file extension for all log files
        /// </summary>
        internal const string LOG_FILE_EXTENSTION = ".log";

        #endregion // Files/Folders
    }
}
