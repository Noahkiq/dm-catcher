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
		static void Main(string[] args) => new dmcatcher().Start();

		private DiscordClient _client;

		public void Start()
		{
			string currentDir = Directory.GetCurrentDirectory();
			string configJson = File.ReadAllText(currentDir + "/config.json");
			dynamic data = JObject.Parse(configJson);
			string token = data.token;
			ulong alertGuild = data.alertGuild;
			ulong alertChannel = data.alertChannel;

			_client = new DiscordClient();

			_client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");

			_client.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = _client.Servers;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));

					string mutuals = string.Join(", ", mutualServers.ToArray());
					await _client.GetServer(alertGuild).GetChannel(alertChannel).SendMessage($"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text);
				}
			};
				
			_client.ExecuteAndWait(async () => {
				await _client.Connect(token, TokenType.User);
				Console.WriteLine($"Connected as {_client.CurrentUser.Name}#{_client.CurrentUser.Discriminator}");
			});

		}
	}

}
