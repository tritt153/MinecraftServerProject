namespace MinecraftServer.Models.Common.JSON.Constants
{
    internal static class JsonErrorMessages
    {
        #region JSON Messages

        public static string CombineFailed(string sReason)
        {
            return $"Failed to combine JSON message, {sReason}";
        }

        public static string TextColorNotFound()
        {
            return $"Text color does not exist.";
        }

        public static string MessageSegmentInvalid()
        {
            return $"One or more message segments are invalid.";
        }

        public static string MessageNoSegments()
        {
            return $"Message must have at least one valid segment.";
        }

        public static string MessageNullSegments()
        {
            return $"Message segment list is null";
        }

        #endregion // JSON Messages
    }
}
