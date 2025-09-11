using MinecraftServer.Common.General;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Utilities
{
    public class JsonSerializerWrapper
    {
        #region Serializer Options

        public static JsonSerializerOptions Options = new()
        {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        };

        #endregion // Serializer Options

        #region Public Methods - Static

        /// <summary>
        /// Deserializes the given JSON string with predefined options, and, if the object being deserialized implements IValidatable, calls Validate on the object.
        /// This is done to prevent circumvention of input validation when deserializing an IValidatable object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sJson"></param>
        /// <returns></returns>
        public static T? Deserialize<T>(string sJson)
        {
            T? oResult = JsonSerializer.Deserialize<T>(sJson, Options);

            if (oResult is IValidatable oValidatable)
            {
                oValidatable.Validate();
            }

            return oResult;
        }

        /// <summary>
        /// Serializes the given object with predefined options.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oValue"></param>
        /// <returns></returns>
        public static string Serialize<T>(T oValue)
        {
            return JsonSerializer.Serialize(oValue, Options);
        }

        #endregion // Public Methods - Static
    }
}
