using System.Collections.Generic;
using System.Numerics;
using AmongUs.Api.Registry;

namespace AmongUs.Api
{
    public class TaskType : RegistryObject
    {
        public static readonly Dictionary<RegistryKey, TaskType> Registry = new Dictionary<RegistryKey, TaskType>();
    }
    
    public interface ITask
    {
        TaskType Type { get; }
        IPlayer Owner { get; }
        int TaskStep { get; }
        bool IsComplete { get; } 
        Vector2 Location { get; }
    }
}
