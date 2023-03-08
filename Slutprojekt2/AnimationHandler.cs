public class AnimationHandler
{
    protected static Texture2D spriteSheet = Raylib.LoadTexture("./images/character/Player.png");
    protected Dictionary<string, Vector2> colRow = new Dictionary<string, Vector2>();

    public AnimationHandler()
    {
        colRow.Add("idle", new Vector2(3, 0));
        colRow.Add("walk", new Vector2(3, 1));
        colRow.Add("run", new Vector2(7, 2));
        colRow.Add("crouch", new Vector2(5, 3));
        colRow.Add("jump", new Vector2(7, 4));
        colRow.Add("death2", new Vector2(2, 5));
        colRow.Add("death", new Vector2(7, 6));
        colRow.Add("attack", new Vector2(7, 7));
    }
}
