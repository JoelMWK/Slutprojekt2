public class Animator
{
    public Animation animations = new Animation();
    public Texture2D currentTexture;
    public Vector2 currentFrame;
    private int totalFrames;
    public Rectangle source = new Rectangle(0, 0, 64, 83);
    public string Name { get; set; } = "A_Idle";
    public float timer;
    public int direction = 1;
    public bool moving = false;

    public void Anim(int row, int column, float frameSpeed)
    {
        totalFrames = row;

        timer += Raylib.GetFrameTime();
        if (timer >= frameSpeed)
        {
            timer = 0.0f;
            currentFrame.X++;
        }

        if (currentFrame.X > totalFrames) currentFrame.X = 0;
        for (int i = 0; i < animations.ani.Count; i++) currentFrame.Y = column;

        source.x = currentFrame.X * source.width;
        source.y = currentFrame.Y * source.height;
    }
    public void Draw(Character c)
    {
        Raylib.DrawTexturePro(currentTexture, new Rectangle(source.x, source.y, source.width * direction, source.height), c.rect, Vector2.Zero, 0, Color.WHITE);
    }
}
