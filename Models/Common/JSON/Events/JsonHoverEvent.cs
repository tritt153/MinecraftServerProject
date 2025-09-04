using MinecraftServer.Models.Common.JSON.Messages;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Events
{
    public record JsonHoverEvent : JsonBaseEvent
    {
        #region Json Properties

        [NotNull]
        [JsonPropertyName("contents")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required JsonMessage Contents { get; init; }

        #endregion // Json Properties

        #region Constructor

        [SetsRequiredMembers]
        public JsonHoverEvent(string sAction, JsonMessage oContents) : base(sAction)
        {
            oContents.Validate();

            Contents = oContents;
        }

        #endregion // Constructor

        #region Public Methods - Static

        public static JsonHoverEvent ShowText(JsonMessage oText)
        {
            return new JsonHoverEvent("show_text", oText);
        }

        //TRR ADD NBT BUILDER FOR THESE.
        //public static HoverEvent ShowItem(Message oItem)
        //{
        //    return new HoverEvent("show_item", oItem);
        //}

        //public static HoverEvent ShowPlayer(Message oPlayer)
        //{
        //    return new HoverEvent("show_player", oPlayer);
        //}

        #endregion // Public Methods - Static
    }
}
