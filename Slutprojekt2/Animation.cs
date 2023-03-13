public class Animation
{
    public static Texture2D spriteSheetP = Raylib.LoadTexture("./images/character/Player.png");
    public static Texture2D spriteSheetE = Raylib.LoadTexture("./images/character/Enemy.png");
    public Dictionary<string, Vector3> ani = new Dictionary<string, Vector3>();

    public Animation()
    {
        ani.Add("idle", new Vector3(3, 0, 0.3f));
        ani.Add("walk", new Vector3(3, 1, 0.2f));
        ani.Add("run", new Vector3(7, 2, 0.2f));
        ani.Add("crouch", new Vector3(5, 3, 0.3f));
        ani.Add("jump", new Vector3(7, 4, 0.14f));
        ani.Add("death2", new Vector3(2, 5, 0.2f));
        ani.Add("death", new Vector3(7, 6, 0.2f));
        ani.Add("attack", new Vector3(7, 7, 0.1f));
        ani.Add("attackE", new Vector3(3, 3, 0.2f));
        ani.Add("deathE", new Vector3(3, 2, 0.2f));
    }
}
