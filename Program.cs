using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DarpBot
{
    class Program
    {
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _handler;

        private async Task StartAsync()
        {
            _client = new DiscordSocketClient();
            _handler = new CommandHandler(_client);
            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, "MzE2MjgxMzA2ODEwMDIzOTQ2.DAXwQg.PPEFDL5Z3-vZqFJHe5nTZ1IazcQ");
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            await Task.CompletedTask;
        }


    }
}