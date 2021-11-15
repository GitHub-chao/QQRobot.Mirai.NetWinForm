using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers
{
    public class FriendMessageReceiver : MessageReceiverBase
    {
        [JsonProperty("sender")] public Friend Sender { get; set; }

        public override MessageReceivers Type { get; set; } = MessageReceivers.Friend;

    }
}