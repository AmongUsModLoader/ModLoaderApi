using System;
using System.Collections.Generic;

namespace AmongUs.Api
{
	public static class GameLobby
	{
		/// <summary>
		/// Called when the client player loads into a lobby. (Only executes on the client)
		/// </summary>
		public static event Action<IGameLobby> LobbyLoadEvent;

		/// <summary>
		/// Post of when the start counter is set
		/// </summary>
		public static event Action<IGameLobby, float?> SetStartCounterEventPost;

		/// <summary>
		/// Pre of when the start counter is set
		/// </summary>
		public static event Action<IGameLobby, float?> SetStartCounterEventPre;

		/// <summary>
		/// Update loop of the game lobby
		/// </summary>
		public static event Action<IGameLobby> UpdateEvent;

		/// <summary>
		/// Called when the game is set from Private to Public
		/// </summary>
		public static event Action<IGameLobby> MakePublicEvent;

		/// <summary>
		/// Called when the game tries the start. EX: Start button is pressed
		/// </summary>
		public static event Action<IGameLobby> TryStartEvent;

		/// <summary>
		/// Called when the game tries the start while meeting player requirements.
		/// </summary>
		public static event Action<IGameLobby, bool> GameStartingEvent;

		//public static event Action<IGameLobby, PlayerControl, IDisconnectReason> PlayerDisconnectedEvent;
		public static event Action<IGameLobby> DisconnectEvent;
		
		public static event Action<IGameLobby> OptionsEdited;


		//"Load", this is when the lobby loads, not when the game starts
		public static void Start(IGameLobby lobby) => LobbyLoadEvent?.Invoke(lobby);

		public static void SetStartCounterPost(IGameLobby lobby, float seconds) =>
			SetStartCounterEventPost?.Invoke(lobby, seconds);

		public static void SetStartCounterPre(IGameLobby lobby, float seconds) =>
			SetStartCounterEventPre?.Invoke(lobby, seconds);

		public static void Update(IGameLobby lobby) => UpdateEvent?.Invoke(lobby);

		public static void MakePublic(IGameLobby lobby) => MakePublicEvent?.Invoke(lobby);

		public static void TryStart(IGameLobby lobby) => TryStartEvent?.Invoke(lobby);

		public static void GameStarting(IGameLobby lobby, bool neverShow) =>
			GameStartingEvent?.Invoke(lobby, neverShow);
		
		public static void EditOptions(IGameLobby lobby) => OptionsEdited?.Invoke(lobby);
	}

	public interface IGameLobby
	{
		List<IPlayer> Players { get; }
		float CountDownTimer { get; set; }
		int MinPlayers { get; set; }
		int LastPlayerCount { get; set; }
		StartingState StartState { get; set; }
		string GameStartText { get; set; }
		string GameRoomName { get; set; }
		string PlayerCounter { get; set; }
		
		void ResetStartState();
		T GetOption<T>(LobbyOption<T> option);
	}

	public enum StartingState
	{
		NotStarting,
		Countdown,
		Starting
	}
}
