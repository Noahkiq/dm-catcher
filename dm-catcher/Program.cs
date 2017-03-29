using System;
using Discord;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.CSharp;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace dmcatcher
{
	class dmcatcher
	{
		static void Main(string[] args) => new dmcatcher().startbots();

		public static string currentDir = Directory.GetCurrentDirectory();
		public static string configJson = File.ReadAllText(currentDir + "/config.json");
		public static dynamic data = JObject.Parse(configJson);
		public static string token1 = data.token1;
		public static string token2 = data.token2;
		public static string token3 = data.token3;
		public static string token4 = data.token4;
		public static string token5 = data.token5;
		public static string token6 = data.token6;
		public static string token7 = data.token7;
		public static string token8 = data.token8;
		public static ulong alertGuild = data.alertGuild;
		public static ulong alertChannel = data.alertChannel;
		public static ulong altGuild = data.altGuild;
		public static ulong altChannel = data.altChannel;
		public static ulong customGuild = 282219466589208576;
		public static ulong customChannel = 282477076454309888;

		public void startbots()
		{
			bot1();
			bot2();
			bot3();
			bot4();
			bot5();
			bot6();
			bot7();
			bot8();
		}
		public void bot1()
		{
			DiscordClient bot = new DiscordClient();

			bot.Log.Message += (s, e) => Console.WriteLine($"[1 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.Connect(token1, TokenType.User);
		}

		public void bot2()
		{
			DiscordClient bot = new DiscordClient();

			// bot.Log.Message += (s, e) => Console.WriteLine($"[2 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.Connect(token2, TokenType.User);
		}
		public void bot3()
		{
			DiscordClient bot = new DiscordClient();

			// bot.Log.Message += (s, e) => Console.WriteLine($"[3 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.Connect(token3, TokenType.User);
		}
		public void bot4()
		{
			DiscordClient bot = new DiscordClient();

			// bot.Log.Message += (s, e) => Console.WriteLine($"[4 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.Connect(token4, TokenType.User);
		}
		public void bot5()
		{
			DiscordClient bot = new DiscordClient();

			// bot.Log.Message += (s, e) => Console.WriteLine($"[2 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.Connect(token5, TokenType.User);
		}
		public void bot6()
		{
			DiscordClient bot = new DiscordClient();

			// bot.Log.Message += (s, e) => Console.WriteLine($"[2 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.Connect(token6, TokenType.User);
		}
		public void bot7()
		{
			DiscordClient bot = new DiscordClient();

			// bot.Log.Message += (s, e) => Console.WriteLine($"[2 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.Connect(token7, TokenType.User);
		}
		public void bot8()
		{
			DiscordClient bot = new DiscordClient();

			// bot.Log.Message += (s, e) => Console.WriteLine($"[2 - {e.Severity} - {DateTime.UtcNow.Hour}:{DateTime.UtcNow.Minute}:{DateTime.UtcNow.Second}] {e.Source}: {e.Message}");

			bot.MessageReceived += async (s, e) =>
			{
				if (e.Channel.IsPrivate)
				{
					var mutualServers = new List<KeyValuePair<string, ulong>>();
					var servers = bot.Servers;
					bool inAlt = false;
					bool inCustom = false;

					foreach(Server server in servers)
						foreach (User user in server.Users)
							if (user.Id == e.User.Id)
							{
								mutualServers.Add(new KeyValuePair<string, ulong>(server.Name, server.Id));
								if (server.Id == altGuild)
									inAlt = true;
								else if (server.Id == customGuild)
									inCustom = true;
							}

					string mutuals = string.Join(", ", mutualServers.ToArray());
					bool hasAttachment = e.Message.Attachments.Length > 0;
					string output = $"PM from (Id {e.User.Id})\n({e.User.Mention}) {e.User.Name} [#{e.User.Discriminator}]\nMutual servers: {mutuals}\n**Message:**\n" + e.Message.Text;
					if(hasAttachment) {
						output += "\n**Attachment(s):** ";
						foreach (var attatchment in e.Message.Attachments)
							output += attatchment.Url;
					}

					await bot.GetServer(alertGuild).GetChannel(alertChannel).SendMessage(output);
					if (inAlt)
						await bot.GetServer(altGuild).GetChannel(altChannel).SendMessage(output);
					if (inCustom)
						await bot.GetServer(customGuild).GetChannel(customChannel).SendMessage(output);
				}
			};

			bot.ExecuteAndWait(async () => {
				await bot.Connect(token8, TokenType.User);
				Console.WriteLine($"[8] Connected as {bot.CurrentUser.Name}#{bot.CurrentUser.Discriminator}");
			});
		}
	}

}
