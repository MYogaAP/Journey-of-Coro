public static class TrackTimeLimit
{
    static private float timeLeft;
    static private float timeMax;
    static private float dashTime;
    public static float TimeLeft { get => timeLeft; set => timeLeft = value; }
    public static float TimeMax { get => timeMax; set => timeMax = value; }
    public static float DashTime { get => dashTime; set => dashTime = value; }
}
