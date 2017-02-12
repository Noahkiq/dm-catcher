using System;
using Discord;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.CSharp;
using Newtonsoft.Json.Linq;

namespace dmcatcher
{
	class dmcatcher
	{
		static void Main(string[] args) => new dmcatcher().bots();

		public static string currentDir = Directory.GetCurrentDirectory();
		public static string configJson = File.ReadAllText(currentDir + "/config.json");
		public static dynamic data = JObject.Parse(configJson);
		public static string token1 = data.token1;
		public static string token2 = data.token2;
		public static string token3 = data.token3;
		public static ulong alertGuild = data.alertGuild;
		public static ulong alertChannel = data.alertChannel;
		public static ulong altGuild = data.altGuild;
		public static ulong altChannel = data.altChannel;

		public void bots()
		{
			DiscordClient bot1 = new DiscordClient();
			DiscordClient bot2 = new DiscordClient();
			DiscordClient bot3 = new DiscordClient();

			bot1.Log.Message += (s, e) => Console.WriteLine($"[1] [{e.Severity}] {e.Source}: {e.Message}");
			bot2.Log.Message += (s, e) => Console.WriteLine($"[2] [{e.Severity}] {e.Source}: {e.Message}");
			bot3.Log.Message += (s, e) => Console.WriteLine($"[3] [{e.Severity}] {e.Source}: {e.Message}");

			bot1.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot1.Servers;
					bool inAlt = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					await bot1.GetServer(alertGuild).GetChannel(alertChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
					if (inAlt)
						await bot1.GetServer(altGuild).GetChannel(altChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
				}
			};

			bot2.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot2.Servers;
					bool inAlt = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					await bot2.GetServer(alertGuild).GetChannel(alertChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
					if (inAlt)
						await bot2.GetServer(altGuild).GetChannel(altChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
				}
			};

			bot3.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot3.Servers;
					bool inAlt = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					await bot3.GetServer(alertGuild).GetChannel(alertChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
					if (inAlt)
						await bot3.GetServer(altGuild).GetChannel(altChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
				}
			};

			bot1.Connect(token1, TokenType.User);

			bot2.Connect(token2, TokenType.User);

			bot3.ExecuteAndWait(async () => {
				await bot3.Connect(token3, TokenType.User);
				Console.WriteLine($"[1] Connected as {bot1.CurrentUser.Name}#{bot1.CurrentUser.Discriminator}");
				Console.WriteLine($"[2] Connected as {bot2.CurrentUser.Name}#{bot2.CurrentUser.Discriminator}");
				Console.WriteLine($"[3] Connected as {bot3.CurrentUser.Name}#{bot3.CurrentUser.Discriminator}");
			});
		}
	}

}
