namespace MinecraftServer.Models.Common.Utilities.Extension_Methods
{
    internal static class DictionaryExtenstions
    {
        #region Public Methods - Static

        /// <summary>
        /// Extension method for Dictionaries that creates and returns a string with all the key value pairs delimited by commas.
        /// </summary>
        /// <typeparam name="TKey">TKey - The key of the dictionary.</typeparam>
        /// <typeparam name="TValue">TValue - The value associated with the key.</typeparam>
        /// <param name="oDictionary">Dictionary<TKey, TValue> - The dictionary to list the contents of.</param>
        /// <returns>string - Formatted string of all KeyValuePairs in the given Dictionary<TKey, TValue> delimited by commas ",".</returns>
        internal static string ToString<TKey, TValue>(this Dictionary<TKey, TValue> oDictionary) where TKey : notnull
        {
            if (oDictionary?.Count > 0)
            {
                return "{" + string.Join(", ", oDictionary.Select(oKeyValuePair => $"{oKeyValuePair.Key}: {oKeyValuePair.Value}")) + "}";
            }

            return "{}";
        }

        #endregion // Public Methods - Static
    }
}
