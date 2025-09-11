using MinecraftServer.Common.General;
using MinecraftServer.Models.Common.JSON.Messages;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MinecraftServer.Models.Common.JSON.Events
{
    public class JsonHoverEvent : JsonBaseEvent
    {
        #region Json Properties

        [NotNull]
        [JsonPropertyName("contents")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required JsonMessage Contents { get; init; }

        #endregion // Json Properties

        #region Constructor

        [JsonConstructor]
        public JsonHoverEvent() { }

        [SetsRequiredMembers]
        public JsonHoverEvent(string sAction, JsonMessage oContents) : base(sAction)
        {
            Validator.ValidateParam(oContents);

            Contents = oContents;
        }

        #endregion // Constructor

        #region Public Methods - Static

        public static JsonHoverEvent ShowText(JsonMessage oText)
        {
            return new JsonHoverEvent("show_text", oText);
        }

        //TRR ADD NBT BUILDER FOR THESE, it must take an NBT tag item eventually...
        //public static HoverEvent ShowItem(NbtItem oItem)
        //{
        //    return new HoverEvent("show_item", oItem);
        //}

        //public static HoverEvent ShowPlayer(NbtPlayer oPlayer)
        //{
        //    return new HoverEvent("show_player", oPlayer);
        //}

        #endregion // Public Methods - Static

        #region IValidatable

        public override void ValidateInternal()
        {
            base.Validate();
            Validator.ValidateParam(Contents);
        }

        #endregion // IValidatable
    }
}
