﻿using Discord.Commands;
using Discord.WebSocket;

using SpiderDiscordBot.Authorization;

using SpidersGoogleSheetsIntegration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiderDiscordBot.SignupCommands
{
    public class RevokeSignupCommand : AuthorizedCommand
    {
        public const string Description = "Revokes your signup for a specific run for a specific character.\n" +
            "ex: !revokesignup heroic thwackdaddy";

        [Command(ignoreExtraArgs: true, text: "revokesignup")]
        [AuthorizedGroup("Daddy Long Legs", "Veteran Spider", "Trial Spider", "Goliath Spider", "Banana Spider")]
        [Summary(Description)]
        public async Task ProcessMessageAsync()
        {
            var message = this.Context.Message;
            var arguments = message.Content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (arguments.Length != 3)
            {
                await message.Channel.SendMessageAsync("Invalid usage of !revokesignup. Use like this: " + Description);
                return;
            }

            var run = arguments[1];
            var character = arguments[2];
            if (!SignupCommand.RunTypes.Contains(run, StringComparer.OrdinalIgnoreCase))
            {
                await message.Channel.SendMessageAsync("Invalid usage of !signup. Invalid 'runType/id' value.");
                return;
            }

            var sheetsClient = new SheetsClient();
            await sheetsClient.Initialize();

            try
            {
                await sheetsClient.RevokeSignupAsync(character, message.Author.Username);
                await message.Channel.SendMessageAsync($"Successfully Revoked: {character} for {message.Author.Mention} for {run}!");
            }
            catch(InvalidOperationException ex)
            {
                await message.Channel.SendMessageAsync(ex.Message);
            }
            catch (Exception ex)
            {
                await message.Channel.SendMessageAsync($"Revoke attempt resulted in error, @sealslicer please check into it.");
                throw;
            }

        }
    }
}
