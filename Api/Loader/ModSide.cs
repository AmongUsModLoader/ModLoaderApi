using System;

namespace AmongUs.Api.Loader
{
    [Flags]
    public enum ModSide
    {
        Common,
        Server,
        Client,
    }

    public class Side : Attribute
    {
        public ModSide ValidSide { get; }

        public Side(ModSide side = ModSide.Common) => ValidSide = side;
    }
}
