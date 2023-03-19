public class Timer
{
    public static float time;

    public static void Update()
    {
        time += Raylib.GetFrameTime();
    }
    public static bool CheckTimer(float cooldown)
    {
        return time >= cooldown;
    }
    public static float ResetTimer()
    {
        return time = 0;
    }
}
