using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace MovieNightBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        Random random = new Random();
        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        
        static List<string> movie_list = new List<string>();

        [Command("help")]
        public async Task Ping()
        {
            await ReplyAsync("Commands: \n!ayy: I will Lmao.\n" +
                                            "!add: I will add movie title to list of movies.\n" +
                                            "!list: I will show every movie on the list.\n" +
                                            "!remove: I will remove said movie from the movie list.\n" +
                                            "!roll: I will help your indecisiveness by rolling dice to figure out which movie to watch.\n" +
                                            "!(name): I will append the proper emoji which describes said individual.\n", true).ConfigureAwait(false);
        }

        [Command("add")]
        public async Task Add([Remainder] string movie)
        {

            await ReplyAsync("Adding \"" + myTI.ToTitleCase(movie) + "\" to the list.", true).ConfigureAwait(false); ;
            movie_list.Add(myTI.ToTitleCase(movie));

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
            await ReplyAsync(view_movie_list, true).ConfigureAwait(false); ;
        }

        [Command("remove")]
        public async Task Remove([Remainder] string movie)
        {
            if (movie_list.Contains(myTI.ToTitleCase(movie)))
            {
                movie_list.Remove(myTI.ToTitleCase(movie));
                await ReplyAsync(movie + " removed from list.", true).ConfigureAwait(false);
            }
            else
            {
                await ReplyAsync(myTI.ToTitleCase(movie) + " is not in the list.", true).ConfigureAwait(false);
            }
        }

        [Command("roll")]
        public async Task Roll()
        {
            int list_max = movie_list.Count;
            int random_number = random.Next(list_max) + 1;

            await ReplyAsync("You rolled " + random_number + ". We're watching... " + myTI.ToTitleCase(movie_list[random_number]) + "!").ConfigureAwait(false);
        }
        //Fun commands
        [Command("ayy")]
        public async Task Lmao()
        {
            await ReplyAsync("lmao", true).ConfigureAwait(false); ;
        }

        [Command("adrian")]
        public async Task Rat()
        {
            await ReplyAsync(":rat:").ConfigureAwait(false);
        }
    }
}