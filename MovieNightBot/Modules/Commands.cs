using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace MovieNightBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        
        static List<string> movie_list = new List<string>();

        [Command("help")]
        public async Task Ping()
        {
            await ReplyAsync("Commands: \n!ayy: I will Lmao.\n" +
                                            "!add: I will add movie title to list of movies.\n" +
                                            "!adrian: I will append the proper emoji which describes said individual.\n" +
                                            "!list: I will show every movie on the list.").ConfigureAwait(false);
        }

        [Command("ayy")]
        public async Task Lmao()
        {
            await ReplyAsync("lmao", true).ConfigureAwait(false); ;
        }
        [Command("add")]
        public async Task Add([Remainder] string movie)
        {

            await ReplyAsync("Adding \"" + movie + "\" to the list.", true).ConfigureAwait(false); ;
            movie_list.Add(movie);

        }

        [Command("adrian")]
        public async Task Rat()
        {
            await ReplyAsync(":rat:").ConfigureAwait(false); ;
        }

        [Command("list")]
        public async Task List()
        {
            string view_movie_list = "";
            for(int i = 0; i < movie_list.Count; i++)
            {
                int counter = i + 1;
                view_movie_list = view_movie_list + counter.ToString() + ": \"" + movie_list[i] + "\"\n";
            }
            await ReplyAsync(view_movie_list).ConfigureAwait(false); ;
        }
    }
}