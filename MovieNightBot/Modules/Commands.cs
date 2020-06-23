using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace MovieNightBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        Random random = new Random();
        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        static Dictionary<string, List<string>> movie_list = new Dictionary<string, List<string>>();
        
        [Command("help")]
        public async Task Ping()
        {
            await ReplyAsync("Commands: \n!ayy: I will Lmao.\n" +
                                            "?add: I will add movie title to list of movies.\n" +
                                            "?clear: I will clear the movie list.\n" +
                                            "?list: I will show every movie on the list.\n" +
                                            "?remove: I will remove said movie from the movie list.\n" +
                                            "?roll: I will help your indecisiveness by rolling dice to figure out which movie to watch.\n" +
                                            "?(name): I will append the proper emoji which describes said individual.\n", true).ConfigureAwait(false);
        }

        [Command("add")]
        public async Task Add([Remainder] string movie)
        {
            string guild_server = Context.Guild.Id.ToString();
            if (!movie_list.ContainsKey(Context.Guild.Id.ToString()))
            {
                List<string> temp = new List<string>();
                movie_list.Add(Context.Guild.Id.ToString(), temp);
                movie_list[guild_server].Add(myTI.ToTitleCase(movie));
            }
            else if (movie_list.ContainsKey(Context.Guild.Id.ToString()))
            {
                movie_list[guild_server].Add(myTI.ToTitleCase(movie));
            }
            await ReplyAsync("Adding \"" + myTI.ToTitleCase(movie) + "\" to the list.", true).ConfigureAwait(false);
        }

        [Command("clear")]
        public async Task Clear()
        {
            string guild_server = Context.Guild.Id.ToString();
            List<string> temp = new List<string>();
            movie_list[guild_server] = temp;
            await ReplyAsync("List cleared.").ConfigureAwait(false);
        }

        [Command("list")]
        public async Task List()
        {
            string view_movie_list = "";
            string guild_server = Context.Guild.Id.ToString();
            for (int i = 0; i < movie_list[guild_server].Count; i++)
            {
                int counter = i + 1;
                view_movie_list = view_movie_list + counter.ToString() + ": \"" + myTI.ToTitleCase((movie_list[guild_server])[i]) + "\"\n";
            }
            await ReplyAsync(view_movie_list, true).ConfigureAwait(false); ;
        }

        [Command("poll")]
        public async Task Poll()
        {
            await ReplyAsync("Placeholder").ConfigureAwait(false);
        }

        [Command("remove")]
        public async Task Remove([Remainder] string movie)
        {
            string guild_server = Context.Guild.Id.ToString();
            if (movie_list[guild_server].Contains(myTI.ToTitleCase(movie)))
            {
                movie_list[guild_server].Remove(myTI.ToTitleCase(movie));
                await ReplyAsync(myTI.ToTitleCase(movie) + " removed from list.", true).ConfigureAwait(false);
            }
            else if (!movie_list[guild_server].Contains(myTI.ToTitleCase(movie)))
            {
                await ReplyAsync(myTI.ToTitleCase(movie) + " is not in the list.", true).ConfigureAwait(false);
            }
        }

        [Command("roll")]
        public async Task Roll()
        {
            string guild_server = Context.Guild.Id.ToString();
            int list_max = movie_list[guild_server].Count;
            int random_number = random.Next(list_max);

            await ReplyAsync("You rolled " + (random_number + 1) + ". We're watching... " + myTI.ToTitleCase((movie_list[guild_server])[random_number]) + "!", true).ConfigureAwait(false);
        }

        //Fun commands
        [Command("ayy")]
        public async Task Lmao()
        {
            await ReplyAsync("lmao", true).ConfigureAwait(false);
        }

        [Command("adrian")]
        public async Task Rat()
        {
            await ReplyAsync(":rat:").ConfigureAwait(false);
        }

        [Command("recroll")]
        public async Task Recroll()
        {
            await ReplyAsync("You rolled Gachimuchi. We're watching... Boy Next Door. AHHHHH.", true).ConfigureAwait(false);
        }
        
        //Test commands
        [Command("test")]
        public async Task Test()
        {
            string guild_server = Context.Guild.Id.ToString();
            await Context.Channel.SendMessageAsync(guild_server);
        }

        [Command("show")]
        public async Task Show()
        {
            string guild_server = Context.Guild.Id.ToString();
            await Context.Channel.SendMessageAsync("List being shown: " + movie_list[guild_server].ToString());
        }
    }
}