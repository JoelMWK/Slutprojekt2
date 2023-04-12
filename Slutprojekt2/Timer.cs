public class Timer
{
    public float Time { get; set; } //Float variabel som ska användas för tid

    public void Update() //Updaterar "Time" för varje frame.
    {
        Time += Raylib.GetFrameTime();
    }
    public bool CheckTimer(float cooldown) //Kollar om Time har gått över eller = med en cooldown
    {
        return Time >= cooldown;
    }
    public float ResetTimer() //Nollställer Time till 0
    {
        return Time = 0;
    }
}
