public class Animator
{
    protected Animation animations = new Animation();
    public Texture2D currentTexture;
    Vector2 currentFrame;
    int totalFrames;
    public string Name { get; set; } = "idle";
    float timer;

    public Rectangle source = new Rectangle(0, 0, 80, 80);
    public int direction = 1;
    public bool moving = false;


    public void Anim()
    {
        totalFrames = (int)animations.ani[Name].X;

        timer += Raylib.GetFrameTime();
        if (timer >= animations.ani[Name].Z)
        {
            timer = 0.0f;
            currentFrame.X++;
        }

        if (currentFrame.X > totalFrames) currentFrame.X = 0;
        for (int i = 0; i < animations.ani.Count; i++) currentFrame.Y = animations.ani[Name].Y;

        source.x = currentFrame.X * source.width;
        source.y = currentFrame.Y * source.height;
    }
    public void Draw(Character c)
    {
        Raylib.DrawTexturePro(currentTexture, new Rectangle(source.x, source.y, source.width * direction, source.height), c.rect, Vector2.Zero, 0, Color.WHITE);
    }
}
