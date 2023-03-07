public class Animator
{
    static Texture2D currentTexture = Character.animStates[0];
    float timer;
    int currentFrame;
    int totalFrames = currentTexture.height / 88;

    protected Rectangle cutter = new Rectangle(0, 0, 58, 88);
    protected Vector2 aniVector = new Vector2();
    protected Vector2 direction = new Vector2(1, 0);
    protected bool moving = false;

    public void Anim()
    {
        if (moving) currentTexture = Character.animStates[1];
        else currentTexture = Character.animStates[0];
        timer += Raylib.GetFrameTime();
        if (timer >= 0.2f)
        {
            timer = 0.0f;
            currentFrame++;
        }
        if (currentFrame > totalFrames) currentFrame = 0;
        cutter.y = currentFrame * cutter.height;
    }
    public virtual void Draw()
    {
        Raylib.DrawTextureRec(currentTexture, new Rectangle(cutter.x, cutter.y, cutter.width * direction.X, cutter.height), aniVector, Color.WHITE);
    }
}
