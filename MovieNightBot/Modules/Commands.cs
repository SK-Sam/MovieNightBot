using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace MovieNightBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("bing")]
        public async Task Ping()
        {
            await ReplyAsync("Bong");
        }
        [Command("ayy")]
        public async Task Lmao()
        {
            await ReplyAsync("lmao");
        }
        [Command("hell")]
        public async Task Yeah()
        {
            await ReplyAsync("yeah");
        }
        [Command("adrian")]
        public async Task Rat()
        {
            await ReplyAsync(":rat:");
        }
    }
}
