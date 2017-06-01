using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DarpBot.Modules
{
    public class Answer : ModuleBase<SocketCommandContext>
    {
        

        [Command("sa")]
        public async Task sa()
        {
            await Context.Channel.SendMessageAsync("as");
        }
    }
}
