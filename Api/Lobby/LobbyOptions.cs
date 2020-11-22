using System;
using System.Collections.Generic;
using AmongUs.Api.Registry;

namespace AmongUs.Api
{
	public abstract class LobbyOption : RegistryObject
	{
		public Func<IGameLobby, LobbyOptionInstance> Factory { get; protected set; }
		public bool Hidden { get; }

		public LobbyOption(Func<IGameLobby, LobbyOptionInstance> factory, bool hidden = false)
		{
			Factory = factory;
			Hidden = hidden;
		}

		public abstract string ValueName(object value);
	}
	
	public class LobbyOption<T> : LobbyOption
	{
		protected Func<T, string> _serializer;

		public LobbyOption(Func<IGameLobby, LobbyOptionInstance<T>> factory, Func<T, string> serializer, bool hidden = false) : base(factory, hidden) => _serializer = serializer;

		public override string ValueName(object value) => _serializer((T) value);
	}

	public class LobbyOptionInstance
	{
		protected readonly IGameLobby _lobby;

		public LobbyOptionInstance(IGameLobby lobby) => _lobby = lobby;

		public void TriggerSettingsUpdate() => GameLobby.PostOptionsEditedEvent(_lobby);
	}

	public class LobbyOptionInstance<T> : LobbyOptionInstance
	{
		private T _value;

		public LobbyOptionInstance(IGameLobby lobby) : base(lobby)
		{
		}

		public virtual T Value
		{
			get => _value;
			set
			{
				_value = value;
				TriggerSettingsUpdate();
			}
		}
	}
	
	public class LazyLobbyOption<T> : LobbyOption<T>
	{
		public LazyLobbyOption(bool hidden = false) : base(null, null, hidden) {}

		public void Initialize(Func<IGameLobby, LobbyOptionInstance<T>> factory, Func<T, string> serializer)
		{
			Factory = factory;
			_serializer = serializer;
		}
	}
	
	public static class LobbyOptions
	{
		public static readonly Dictionary<RegistryKey, LobbyOption> Registry = new Dictionary<RegistryKey, LobbyOption>();
		
		public static readonly LobbyOption<int> MaxPlayers = new LazyLobbyOption<int>(true);
		public static readonly LobbyOption<bool> GhostsDoTasks = new LazyLobbyOption<bool>(true);
		public static readonly LobbyOption<GameMap> Map = new LazyLobbyOption<GameMap>();
		public static readonly LobbyOption<int> Impostors = new LazyLobbyOption<int>();
		public static readonly LobbyOption<bool> ConfirmEjects = new LazyLobbyOption<bool>();
		public static readonly LobbyOption<int> EmergencyMeetings = new LazyLobbyOption<int>();
		public static readonly LobbyOption<bool> AnonymousVotes = new LazyLobbyOption<bool>();
		public static readonly LobbyOption<int> EmergencyCooldown = new LazyLobbyOption<int>();
		public static readonly LobbyOption<int> DiscussionTime = new LazyLobbyOption<int>();
		public static readonly LobbyOption<int> VotingTime = new LazyLobbyOption<int>();
		public static readonly LobbyOption<float> PlayerSpeed = new LazyLobbyOption<float>();
		public static readonly LobbyOption<float> CrewmateVision = new LazyLobbyOption<float>();
		public static readonly LobbyOption<float> ImpostorVision = new LazyLobbyOption<float>();
		public static readonly LobbyOption<float> KillCooldown = new LazyLobbyOption<float>();
		public static readonly LobbyOption<KillDistance> KillDistance = new LazyLobbyOption<KillDistance>();
		public static readonly LobbyOption<TaskBarUpdates> TaskBarUpdates = new LazyLobbyOption<TaskBarUpdates>();
		public static readonly LobbyOption<bool> VisualTasks = new LazyLobbyOption<bool>();
		public static readonly LobbyOption<int> CommonTasks = new LazyLobbyOption<int>();
		public static readonly LobbyOption<int> LongTasks = new LazyLobbyOption<int>();
		public static readonly LobbyOption<int> ShortTasks = new LazyLobbyOption<int>();
	}
	
	public enum TaskBarUpdates
	{
		Always,
		Meeting,
		Never
	}
}
