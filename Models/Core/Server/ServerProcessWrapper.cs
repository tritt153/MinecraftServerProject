using MinecraftServer.Models.Common.Utilities.General;
using System.Diagnostics;

namespace MinecraftServer.Models.Core.Server
{
    public class ServerProcessWrapper 
    {
        #region Events

        public event EventHandler? ServerStarted = null;

        #endregion // Events

        #region Member Variables

        private Process? _oProcess = null;

        #endregion // Member Variables

        #region Properties
        public string WorkingDirectory { get; private set; } = string.Empty;

        public string ServerFileName { get; private set; } = string.Empty;

        public string ServerFilePath { get; private set; } = string.Empty;

        public bool IsStarted { get; private set; } = false;

        public bool IsReady { get; private set; } = false;

        #endregion // Member Variables

        #region Constructor

        #endregion // Constructor

        #region Public Methods

        #endregion // Public Methods

    }
}
