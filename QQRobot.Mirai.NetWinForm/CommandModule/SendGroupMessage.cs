using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQRobot.Mirai.NetWinForm.CommandModule
{
    public class SendGroupMessage : ICommandModule
    {
        public bool? IsEnable { get; set; }

        [CommandTrigger("say")]
        public async void Execute(MessageReceiverBase receiver, MessageBase executeMessage)
        {
            if (receiver is GroupMessageReceiver gReceiver)
            {
                if (executeMessage is PlainMessage message)
                {
                    if (this.GetCommandTrigger().HasParameters(message.Text))
                    {
                        var result = this.GetCommandTrigger().ParseCommand(message.Text);

                        //if (result.First().Key == "value")
                        //{
                        //    await gReceiver.SendGroupMessageAsync(string.Join(" ", result.First().Value));
                        //}
                    }
                    else
                    {
                        //await gReceiver.SendGroupMessageAsync("bruh what the fuck do you want me to say?");
                    }
                }
            }
        }
    }
}
