public class Animator : AnimationHandler
{
    static Texture2D currentTexture = idle;
    float timer;
    int currentFrame;
    int totalFrames;

    protected Rectangle cutter = new Rectangle(0, 0, 46, 80);
    protected Vector2 aniVector = new Vector2();
    protected Vector2 direction = new Vector2(1, 0);
    protected bool moving = false;

    public void Anim()
    {
        totalFrames = currentTexture.width / 80;

        if (moving) currentTexture = walk;
        else currentTexture = idle;

        timer += Raylib.GetFrameTime();
        if (timer >= 0.2f)
        {
            timer = 0.0f;
            currentFrame++;
        }
        if (currentFrame > totalFrames) currentFrame = 0;
        cutter.x = currentFrame * cutter.width;
    }
    public virtual void Draw()
    {
        Raylib.DrawTextureRec(currentTexture, new Rectangle(cutter.x, cutter.y, cutter.width * direction.X, cutter.height), aniVector, Color.WHITE);
    }
}
