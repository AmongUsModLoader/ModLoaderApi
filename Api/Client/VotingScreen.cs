using System;
using AmongUs.Api.Loader;
using UnityEngine;

namespace AmongUs.Api
{
    [Side(ModSide.Client)]
    public static class VotingScreen
    {
        public static event Action<IVotingScreen> UpdateEvent;

        public static void Update(IVotingScreen hud) => UpdateEvent?.Invoke(hud);
    }

    //Currently unused, wrapper for MeetingHud
    [Side(ModSide.Client)]
    public interface IVotingScreen
    {
        string TitleText { get; set; }
        Vector3 VotePosition { get; set; }
        Vector3 VoteButtonSize { get; set; }
        IPlayerVoteState SkipVoteButton { get; }
        IPlayerVoteState[] PlayerStates { get; }
        //GameData.IHEKEPMDGIJ ExiledPlayer { get; set; }
        bool Tied { get; set; }
        string TimerText { get; set; }
        float DiscussionTime { get; set; }
    }

    [Side(ModSide.Client)]
    public interface IPlayerVoteState
    {
        string Name { get; set; }
        Vector3 Position { get; set; }
        bool IsEnabled { get; set; }
        bool IsDead { get; set; }
        bool Voted { get; set; }
        bool Reported { get; set; }
        //IPlayer Vote { get; set; }
        bool VotingFinished { get; set; }
    }
}
