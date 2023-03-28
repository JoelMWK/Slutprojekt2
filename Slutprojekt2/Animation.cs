public class Animation
{
    public static Texture2D spriteSheetP = Raylib.LoadTexture("./images/character/players.png");
    public static Texture2D spriteSheetE = Raylib.LoadTexture("./images/character/enemies.png");
    public Dictionary<string, (int col, int row, float frameSpeed)> ani = new Dictionary<string, (int col, int row, float frameSpeed)>();

    public Animation()
    {
        ani.Add("K_Idle", (3, 0, 0.2f));
        ani.Add("K_Run", (3, 1, 0.2f));

        ani.Add("A_Idle", (3, 2, 0.2f));
        ani.Add("A_Run", (3, 3, 0.2f));

        ani.Add("D_Idle", (3, 0, 0.4f));
        ani.Add("D_Walk", (3, 1, 0.4f));

        ani.Add("W_Idle", (3, 0, 0.4f));
        ani.Add("W_Walk", (3, 1, 0.2f));
    }
}
