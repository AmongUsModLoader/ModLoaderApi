namespace AmongUs.Api.Loader.Internal
{
    public abstract class ApiWrapper
    {
        public static ApiWrapper Instance { get; set; }

        [Side(ModSide.Client)]
        public abstract string Language { get; }

        public abstract ILogger CreateLogger(string name);

        public abstract void AddRegion(Region region);
        public abstract void SetMaxImpostors(int playerCount, int maxImpostors);
    }
}
