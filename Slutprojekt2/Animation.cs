public class Animation
{
    public static Texture2D spriteSheetP = Raylib.LoadTexture("./images/character/players.png");
    public static Texture2D spriteSheetE = Raylib.LoadTexture("./images/character/Enemy.png");
    public Dictionary<string, Vector3> ani = new Dictionary<string, Vector3>();

    public Animation()
    {
        ani.Add("idleK", new Vector3(3, 0, 0.2f));
        ani.Add("runK", new Vector3(3, 1, 0.2f));
        ani.Add("jumpK", new Vector3(3, 2, 0.2f));

        ani.Add("idleA", new Vector3(3, 3, 0.2f));
        ani.Add("runA", new Vector3(3, 4, 0.2f));
        ani.Add("jumpA", new Vector3(3, 5, 0.2f));

        ani.Add("idle", new Vector3(3, 0, 0.3f));
        ani.Add("walk", new Vector3(3, 1, 0.2f));
        ani.Add("attackE", new Vector3(3, 3, 0.2f));
        ani.Add("deathE", new Vector3(3, 2, 0.2f));
    }
}
