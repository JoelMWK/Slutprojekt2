public class Animation
{
    public static Texture2D spriteSheetP = Raylib.LoadTexture("./images/character/players.png");
    public static Texture2D spriteSheetE = Raylib.LoadTexture("./images/character/enemies.png");
    public Dictionary<string, Vector3> ani = new Dictionary<string, Vector3>();

    public Animation()
    {
        ani.Add("K_Idle", new Vector3(3, 0, 0.2f));
        ani.Add("K_Run", new Vector3(3, 1, 0.2f));
        ani.Add("K_Jump", new Vector3(3, 2, 0.2f));

        ani.Add("A_Idle", new Vector3(3, 3, 0.2f));
        ani.Add("A_Run", new Vector3(3, 4, 0.2f));
        ani.Add("A_Jump", new Vector3(3, 5, 0.2f));

        ani.Add("E_Idle", new Vector3(3, 0, 0.4f));
        ani.Add("E_Walk", new Vector3(3, 1, 0.2f));
    }
}
