using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;

namespace DarpBot
{
    class CommandHandler
    {
        private DiscordSocketClient _client;
        private CommandService _service;

        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;

        }

        private async Task HandleCommandAsync(SocketMessage e)
        {
            var msg = e as SocketUserMessage;
            if (msg == null) return;
            var channel = _client.GetChannel(300005220736303114) as SocketTextChannel;


            var context = new SocketCommandContext(_client, msg);
            var argPos = 0;


            if (msg.HasStringPrefix("https://www.youtu", ref argPos) && msg.Channel != channel)
            {

                await channel.SendMessageAsync(msg.ToString());
                //await msg.Channel.SendMessageAsync(msg.ToString());

            }

            if (msg != null)
            {
                var result = await _service.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }

            }


        }
    }
}
