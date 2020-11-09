using System.Text;

namespace AmongUs.Api
{
	//For the GameOptionsData class
	public interface ILobbyOptions
	{
		int MaxPlayers { get; set; }
		GameMap Map { get; set; }
		float PlayerSpeed { get; set; }
		float CrewMateVision { get; set; }
		float ImpostorVision { get; set; }
		float KillCooldown { get; set; }
		int CommonTasks { get; set; }
		int LongTasks { get; set; }
		int ShortTasks { get; set; }
		int EmergencyMeetingsAllowed { get; set; }
		int EmergencyMeetingCooldown { get; set; }
		int ImpostorCount { get; set; }
		bool GhostsDoTasks { get; set; }
		int KillDistance { get; set; }
		int DiscussionTime { get; set; }
		int VotingTime { get; set; }
		bool ConfirmImpostor { get; set; }
		bool VisualTasks { get; set; }
		bool AnonymousVotes { get; set; }
		TaskBarUpdates TaskBarUpdates { get; set; }
		bool IsDefaults { get; set; }
		string Settings { get; set; }
	}

	public enum TaskBarUpdates
	{
		Normal,
		MeetingOnly,
		Invisible
	}
}
