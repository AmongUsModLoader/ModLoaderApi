using System;
using AmongUs.Loader;

namespace AmongUs.Api
{
    [Side(ModSide.Client)]
    public static class MainMenu
    {
        public static event Func<string, string> VersionShowEvent;

        public static string ShowVersion(string text) => VersionShowEvent?.Invoke(text) ?? text;
    }
}
