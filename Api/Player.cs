using System.Collections.Generic;
using System.Numerics;
using PowerTools;

namespace AmongUs.Api
{
    public interface IPlayer
    {
        byte Id { get; }
        float MaxReportDistance { get; set; }
        bool CanMove { get; set; }
        bool InVent { get; }
        bool Infected { get; set; }
        Color Color { get; set; }
        bool Disconnected { get; }
        bool IsImpostor { get; set; }
        bool IsDead { get; set; }
        bool Visible { get; set; }
        float KillCooldown { get; set; }
        int RemainingEmergencies { get; set; }
        string Name { get; set; }
        List<ITask> Tasks { get; }
        //IUsable Closest { get; set; }
        //List<IUsable> InRange { get; }
    }
    
    public interface IPlayerCustomizationTab
    {
        HashSet<Color> AvailableColors { get; }
        
        void SelectColor(Color color);
        void UpdateAvailableColors();
    }
    
    public enum Color
    {
        Red,
        Blue,
        Green,
        Pink,
        Orange,
        Yellow,
        Black,
        White,
        Purple,
        Brown,
        Cyan,
        Lime
    }
    
    public interface IUsable
    {
    	float UsableDistance { get; }
        
    	void SetOutline(bool on, bool mainTarget);
        //float CanUse(IPlayer player, out bool canUse, out bool couldUse);
        void Use();
    }
}
