public class Timer
{
    public float Time { get; set; }

    public void Update()
    {
        Time += Raylib.GetFrameTime();
    }
    public bool CheckTimer(float cooldown)
    {
        return Time >= cooldown;
    }
    public float ResetTimer()
    {
        return Time = 0;
    }
}
