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
		static void Main(string[] args) => new dmcatcher().bot1();
		static void Alt(string[] args) => new dmcatcher().bot2();
		static void Alt2(string[] args) => new dmcatcher().bot3();

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

		public void bot1()
		{
			DiscordClient _client = new DiscordClient();

			_client.Log.Message += (s, e) => Console.WriteLine($"[1] [{e.Severity}] {e.Source}: {e.Message}");

			_client.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = _client.Servers;
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
					await _client.GetServer(alertGuild).GetChannel(alertChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
					if (inAlt)
						await _client.GetServer(altGuild).GetChannel(altChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
				}
			};
				
			_client.ExecuteAndWait(async () => {
				await _client.Connect(token1, TokenType.User);
				Console.WriteLine($"[1] Connected as {_client.CurrentUser.Name}#{_client.CurrentUser.Discriminator}");
			});
		}

		public void bot2()
		{
			DiscordClient _client = new DiscordClient();

			_client.Log.Message += (s, e) => Console.WriteLine($"[2] [{e.Severity}] {e.Source}: {e.Message}");

			_client.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = _client.Servers;
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
					await _client.GetServer(alertGuild).GetChannel(alertChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
					if (inAlt)
						await _client.GetServer(altGuild).GetChannel(altChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
				}
			};

			_client.ExecuteAndWait(async () => {
				await _client.Connect(token2, TokenType.User);
				Console.WriteLine($"[2] Connected as {_client.CurrentUser.Name}#{_client.CurrentUser.Discriminator}");
			});
		}

		public void bot3()
		{
			DiscordClient _client = new DiscordClient();

			_client.Log.Message += (s, e) => Console.WriteLine($"[3] [{e.Severity}] {e.Source}: {e.Message}");

			_client.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = _client.Servers;
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
					await _client.GetServer(alertGuild).GetChannel(alertChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
					if (inAlt)
						await _client.GetServer(altGuild).GetChannel(altChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
				}
			};

			_client.ExecuteAndWait(async () => {
				await _client.Connect(token3, TokenType.User);
				Console.WriteLine($"[3] Connected as {_client.CurrentUser.Name}#{_client.CurrentUser.Discriminator}");
			});
		}
	}

}
