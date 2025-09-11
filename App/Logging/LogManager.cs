using MinecraftServer.Common.General;
using MinecraftServer.Logging.Constants;
using System.IO;
using System.Runtime.CompilerServices;
using static MinecraftServer.Logging.Constants.LogConstants;

namespace MinecraftServer.Logging
{
    /// <summary>
    /// Class that takes messages and objects and writes information about them to a log file for purposes of debugging.
    /// </summary>
    public static partial class LogManager
    {
        #region Member Variables

        //
        // List of messages
        //
        private static List<LogObject>? _lstLogMessages = null;

        //
        // Background thread for logging messages.
        //
        private static Thread? _thrdLogMsgs = null;

        //
        // Lock for threads.
        // 
        private static readonly object _oLock = new object();

        //
        // File strings
        //
        private static string _sFullFolderPath = string.Empty;

        //
        // Thread flag.
        //
        private static bool _bisExit = false;

        //
        // Event wait handle, that controls when the logging thread can start/stop logging.
        //
        private static readonly EventWaitHandle _ewhLogFileWrite = new EventWaitHandle(false, EventResetMode.AutoReset);

        #endregion // Member Variables

        #region Public Methods

        /// <summary>
        /// Start the background logging thread and initialize variables.
        /// </summary>
        public static void Start()
        {
            try
            {
                //
                // Initiliaze the list.
                //
                _lstLogMessages = new List<LogObject>();

                //
                // Create and start thread that is attached to a method that writes log messages to a file.
                //
                _thrdLogMsgs = new Thread(new ThreadStart(WriteLogMessages));
                _thrdLogMsgs.Start();

                //
                // Set up file system.
                //
                InitializeFolder();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(LogErrorMessages.LoggerFailed(ex.Message));
            }
        }

        /// <summary>
        /// Stop background logging thread.
        /// </summary>
        public static void Stop()
        {
            //
            // Set flag saying we are exiting the thread.
            //
            _bisExit = true;

            //
            // Release the thread for the last time.
            // 
            _ewhLogFileWrite.Set();
        }

        public static void LogStart([CallerFilePath] string sCallerFile = "", [CallerMemberName] string sCallerName = "", [CallerLineNumber] int nCallerLine = 0)
        {
            LogString("Method Start", eLogCategory.StartEnd, sCallerFile, sCallerName, nCallerLine);
        }

        public static void LogEnd([CallerFilePath] string sCallerFile = "", [CallerMemberName] string sCallerName = "", [CallerLineNumber] int nCallerLine = 0)
        {
            LogString("Method End", eLogCategory.StartEnd, sCallerFile, sCallerName, nCallerLine);
        }

        /// <summary>
        /// Method that adds an exception to the log list, that will then be logged to a file.
        /// </summary>
        /// <param name="sErrorMessage">string - The custom error message to display.</param>
        /// <param name="ex">Exception - The exception that was thrown.</param>
        /// <param name="sCallerFile">string - The filepath to the caller.</param>
        /// <param name="sCallerName">string - The method name that called this method.</param>
        /// <param name="nCallerLine">int - The line # that this method was called at.</param>
        public static void LogException(Exception ex, string sErrorMessage = "", [CallerFilePath] string sCallerFile = "", [CallerMemberName] string sCallerName = "", [CallerLineNumber] int nCallerLine = 0)
        {
            //
            // Send error message string, 
            //
            LogString(sErrorMessage + " --- [" + ex.Message + "]", eLogCategory.Exception, sCallerFile, sCallerName, nCallerLine);
        }

        /// <summary>
        /// Method that logs an object via a to string method.
        /// </summary>
        /// <param name="sMessage">string - The message to be logged.</param>
        /// <param name="o">object - The object to be logged.</param>
        /// <param name="sCallerFile">string - The filepath to the caller.</param>
        /// <param name="sCallerName">string - The method name that called this method.</param>
        /// <param name="nCallerLine">int - The line # that this method was called at.</param>
        public static void LogObject(string sMessage, object oObject, [CallerFilePath] string sCallerFile = "", [CallerMemberName] string sCallerName = "", [CallerLineNumber] int nCallerLine = 0)
        {
            string sObjectMessage;

            if (oObject is null)
            {
                sObjectMessage = "Failed to log object because it was null.";
            }
            else
            {
                sObjectMessage = sMessage + " {" + oObject.ToString() + "}";
            }

            //
            // Log the object string.
            //
            LogString(sObjectMessage, eLogCategory.Object, sCallerFile, sCallerName, nCallerLine);
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// Method that adds a log object to a list that will then be written to a log file.
        /// </summary>
        /// <param name="sMessage">string - The message to be logged.</param>
        /// <param name="sCallerFile">string - The filepath to the caller.</param>
        /// <param name="sCallerName">string - The method name that called this method.</param>
        /// <param name="nCallerLine">int - The line # that this method was called at.</param>
        private static void LogString(string sMessage, eLogCategory eLogCategory, [CallerFilePath] string sCallerFile = "", [CallerMemberName] string sCallerName = "", [CallerLineNumber] int nCallerLine = 0)
        {
            try
            {
                Validator.CheckNull(_lstLogMessages);

                lock (_oLock)
                {
                    //
                    // Add message to log list
                    //
                    _lstLogMessages.Add(new LogObject(sMessage, eLogCategory, sCallerFile, sCallerName, nCallerLine));

                    //
                    // Release the waiting background thread.
                    // 
                    _ewhLogFileWrite.Set();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(LogErrorMessages.LoggerFailed(ex.Message));
            }
        }


        /// <summary>
        /// Creates a folder for storing the log files, if that folder does not already exist.
        /// </summary>
        private static void InitializeFolder()
        {
            //
            // Get OS independent path for data.
            // (e.g. Windows = C:\ProgramData)
            //
            string sCommonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            //
            // Add custom folder path.
            // (e.g. C:\ProgramData\Bell-Mark\Ink Bottle RFID Logs)
            //
            _sFullFolderPath = Path.Combine(sCommonAppData, LOG_FOLDER_PATH);

            //
            // Create this folder if it does not already exist.
            //
            if (!Directory.Exists(_sFullFolderPath))
            {
                Directory.CreateDirectory(_sFullFolderPath);
            }
        }

        /// <summary>
        /// Creates a file with today's date, if such a file does not already exist.
        /// </summary>
        private static string CreateFile()
        {
            //
            // Parse just the date.
            //
            string sDate = DateTime.Now.ToString(LOG_FILE_DATE_FORMAT);

            //
            // Make the file name with just the date
            // (e.g. InkLog_09012023.log)
            //
            string sFileName = string.Format(LOG_FILE_NAME_FORMAT_DATE, sDate, LOG_FILE_EXTENSTION);

            //
            // Construct the path to this file.
            //
            string sFilePath = Path.Combine(_sFullFolderPath, sFileName);

            //
            // Create the file if it does not already exist.
            //
            if (!File.Exists(sFilePath))
            {
                using (FileStream fsFile = File.Create(sFilePath))
                {

                }

                //
                // Everytime we add a new file we must remove the old files.
                //
                RemoveOldFiles();
            }
            else
            {
                //
                // If it does already exist, make sure it has not gotten too big
                //
                FileInfo fiExistingFile = new FileInfo(sFilePath);
                if (fiExistingFile.Length >= ((long)LOG_FILE_MAX_SIZE_KB * LOG_FILE_KB_TO_B))
                {
                    //
                    // If the file has gotten too big rename it and make a new file.
                    //
                    MoveRenameFile(sFilePath);
                }
            }

            return sFilePath;
        }

        /// <summary>
        /// Removes log files if they are older than a certain date.
        /// </summary>
        private static void RemoveOldFiles()
        {
            DateTime dtNow = DateTime.Now;


            //
            // Roll the date back to the allowed oldest file date/time
            //
            dtNow = dtNow.AddDays(-LOG_FILE_MAX_AGE_DAYS);

            //
            // Loop through all files in a folder and delete any that are older than a certain date.
            //
            foreach (string sFile in Directory.GetFiles(_sFullFolderPath))
            {
                FileInfo fiFile = new FileInfo(sFile);

                if (fiFile.CreationTime < dtNow)
                {
                    File.Delete(sFile);
                }
            }
        }

        /// <summary>
        /// Moves and renames the given file and then recreates it.
        /// </summary>
        /// <param name="sFileOriginal">string - The path to the file to be moved and renamed.</param>
        private static void MoveRenameFile(string sFileOriginal)
        {
            string sDate = DateTime.Now.ToString(LOG_FILE_DATE_FORMAT);
            string sTime = DateTime.Now.ToString(LOG_FILE_TIME_FORMAT);

            //
            // Create new file name with time appened 
            // (e.g. InkLog_09012023_0932AM.log)
            //
            string sFileCopy = string.Format(LOG_FILE_NAME_FORMAT_TIME, sDate, sTime, LOG_FILE_EXTENSTION);

            //
            // Move original file and rename it to the new file name.
            // (e.g. InkLog_09122023 -> (moved/renamed to) InkLog_09122023_0932AM)
            // Thus, InkLog_09122023 no longer exists.
            //
            File.Move(sFileOriginal, Path.Combine(_sFullFolderPath, sFileCopy));

            //
            // Recreate the original file.
            // (e.g. InkLog09122023.log)
            //
            using (FileStream fsFile = File.Create(sFileOriginal))
            {

            }
        }

        /// <summary>
        /// Method that loops through the list of objects and writes them all to file. The list is cleared after this to allow for new messages.
        /// </summary>
        /// <param name="sFilePath">The path to the file to write to.</param>
        private static void WriteMessagesFromList(string sFilePath)
        {
            Validator.CheckNull(_lstLogMessages);

            //
            // Open the file.
            //
            using (StreamWriter swLogWriter = File.AppendText(sFilePath))
            {
                if (swLogWriter != null)
                {

                    //
                    // Write to the file with the proper format.
                    //
                    foreach (LogObject logObject in _lstLogMessages)
                    {
                        if (logObject != null)
                        {
                            string sLine = string.Format(LOG_MESSAGE_FORMAT,
                                                         DateTime.Now.ToString(LOG_MESSAGE_TIME_FORMAT),
                                                         logObject.LogCategory,
                                                         logObject.CallerFile,
                                                         logObject.CallerName,
                                                         logObject.CallerLineNum,
                                                         logObject.LogMessage);

                            //
                            // Write the current object information then flush the stream.
                            //
                            swLogWriter.WriteLine(sLine);
                            swLogWriter.Flush();
                        }
                    }

                    //
                    // Clear list data for next message(s)
                    //
                    _lstLogMessages.Clear();
                }
            }
        }

        #endregion // Private Methods

        #region Background Logging Thread

        /// <summary>
        /// Method to be run on a background thread, that will write log messages to a file.
        /// </summary>
        private static void WriteLogMessages()
        {
            try
            {
                //
                // Run until we are told to exit.
                //
                while (!_bisExit)
                {
                    //
                    // Wait until we are allowed to continue.
                    //
                    _ewhLogFileWrite.WaitOne();

                    Validator.CheckNull(_lstLogMessages);

                    //
                    // Lock while writing to the file.
                    //
                    lock (_oLock)
                    {
                        if (_lstLogMessages.Count > 0)
                        {
                            //
                            // Get the name of the file we are currently writing to.
                            //
                            string sCurrentFile = CreateFile();

                            //
                            // Write the list to the log file.
                            //
                            WriteMessagesFromList(sCurrentFile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(LogErrorMessages.LoggerFailed(ex.Message));
            }
        }

        #endregion // Background Logging Thread
    }
}
