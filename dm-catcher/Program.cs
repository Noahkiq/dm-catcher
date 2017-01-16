using System;
using Discord;
using System.IO;

namespace dmcatcher
{
	class dmcatcher
	{
		static void Main(string[] args) => new Program().Start();

		public void LoadJson()
		{
			using (StreamReader r = new StreamReader("config.json"))
			{
				string json = r.ReadToEnd();
				List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
			}
		}

		public class Item
		{
			public string token;
			public List<KeyValuePair> alertChannels;
			public ulong ownerId;
		}

		private DiscordClient _client;

		public void Start()
		{
			_client = new DiscordClient();

			_client.Log.Message += (s, e) => Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");

			_client.MessageReceived += async (s, e) =>
			{
				// hi
			};
				
			_client.ExecuteAndWait(async () => {
				await _client.Connect(Item.token, TokenType.User);
			});

		}
	}

}
