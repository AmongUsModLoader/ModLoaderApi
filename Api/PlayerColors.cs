using System;
using AmongUs.Loader;

namespace AmongUs.Api
{
    public static class PlayerColors
    {
        [Side(ModSide.Client)]
        public static event Func<Color, bool> SelectColorEvent;
        public static event Func<IPlayerCustomizationTab, bool> SetAvailableColorsEvent;
        public static event Func<IPlayer, Color, bool> TrySetColorEvent;

        [Side(ModSide.Client)]
        public static bool PostSelectColorEvent(Color color) => SelectColorEvent?.Invoke(color) != false;
        public static bool PostSetAvailableColorsEvent(IPlayerCustomizationTab tab) => SetAvailableColorsEvent?.Invoke(tab) != false;
        public static bool PostTrySetColorEvent(IPlayer player, Color color) => TrySetColorEvent?.Invoke(player, color) != false;
    }
}
