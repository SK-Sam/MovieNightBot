using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace MovieNightBot
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton<ConfigHandler>()
                .BuildServiceProvider();
            await _services.GetService<ConfigHandler>().PopulateConfig();

            await _client.LoginAsync(TokenType.Bot, _services.GetService<ConfigHandler>().GetToken());
            await _client.StartAsync();
        }
    }
}
