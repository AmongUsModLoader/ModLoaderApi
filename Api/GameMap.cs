using System.Collections.Generic;
using AmongUs.Api.Registry;

namespace AmongUs.Api
{
    public class GameMap : RegistryObject
    {
        public static readonly Dictionary<RegistryKey, GameMap> Registry = new Dictionary<RegistryKey, GameMap>();
    }
}