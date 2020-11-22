using System.Collections.Generic;
using AmongUs.Api.Loader.Internal;

namespace AmongUs.Api
{
	public class Region
	{
		public string Name { get; }
		public string Address { get; }
		public List<Server> Servers { get; } = new List<Server>();

		public Region(string name, string address, params Server[] servers)
		{
			Name = name;
			Address = address;
			foreach (var server in servers)
			{
				server.Region = this;
				Servers.Add(server);
			}
		}
		
		public static void AddRegion(Region region) => ApiWrapper.Instance.AddRegion(region);

		public class Server
		{
			public Region Region { get; set; }
			public string Name { get; }
			public ushort Port { get; }

			public Server(string name, ushort port)
			{
				Name = name;
				Port = port;
			}
		}
	}
}
