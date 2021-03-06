﻿using Discord.Commands;
using Discord.WebSocket;

using SpiderDiscordBot.Authorization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SpiderDiscordBot.ImageCommands
{
    public class GenericImageCommand : AuthorizedCommand
    {
        [Command(ignoreExtraArgs: true, text: "hr")]
        [Summary("I NEED HR")]
        public async Task ProcessHrImageAsync()
        {
            var message = this.Context.Message;
            await message.Channel.SendMessageAsync("https://tenor.com/view/karen-karening-intensifies-done-iam-done-gif-16742218");
        }

        [Command(ignoreExtraArgs: true, text: "karen")]
        [Summary("KAAAAAARRENNNN")]
        public async Task ProcessKarenImageAsync()
        {
            var message = this.Context.Message;            
            await message.Channel.SendMessageAsync("https://tenor.com/view/snl-hell-naw-no-black-panther-karen-gif-11636970");
        }

        [Command(ignoreExtraArgs: true, text: "ravioli")]
        [Summary("raviolis?")]
        public async Task ProcessRavioliImageAsync()
        {
            var message = this.Context.Message;
            await message.Channel.SendMessageAsync("https://tenor.com/view/trailer-gif-7304634");
        }

        [Command(ignoreExtraArgs: true, text: "carrot")]
        [Summary("Oh Yeah baby, gimme that carrot")]
        [Alias("Hamster")]
        public async Task ProcessCarrotImageAsync()
        {
            var message = this.Context.Message;
            await message.Channel.SendMessageAsync("https://media1.tenor.com/images/ddec2ab3e59e5d3f1d86be306b1db89a/tenor.gif");
        }
    }
}
