public class Animator : AnimationHandler
{

    public Texture2D currentTexture;
    Vector2 currentFrame;
    int totalFrames;
    public string Name { get; set; } = "idle";
    float timer;


    public Rectangle source = new Rectangle(0, 0, 80, 80);
    public Vector2 aniVector = new Vector2();
    public Vector2 direction = new Vector2(1, 0);
    public bool moving = false;


    public void Anim()
    {
        totalFrames = (int)colRow[Name].X * (int)source.width / 80;


        timer += Raylib.GetFrameTime();
        if (timer >= 0.2f)
        {
            timer = 0.0f;
            currentFrame.X++;
        }

        if (currentFrame.X > totalFrames) currentFrame.X = 0;
        for (int i = 0; i < colRow.Count; i++) currentFrame.Y = colRow[Name].Y;

        source.x = currentFrame.X * source.width;
        source.y = currentFrame.Y * source.height;
    }
    public void Draw(Character c)
    {
        //Raylib.DrawTextureRec(currentTexture, new Rectangle(source.x, source.y, source.width * direction.X, source.height), aniVector, Color.WHITE);

        Raylib.DrawTexturePro(currentTexture, new Rectangle(source.x, source.y, source.width * direction.X, source.height), c.rect, Vector2.Zero, 0, Color.WHITE);
    }
}
