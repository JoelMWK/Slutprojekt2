public class Animator : AnimationHandler
{
    static Texture2D currentTexture = spriteSheet;
    Vector2 currentFrame;
    int totalFrames;
    string name = "idle";
    float timer;


    protected Rectangle source = new Rectangle(0, 0, 80, 80);
    protected Vector2 aniVector = new Vector2();
    protected Vector2 direction = new Vector2(1, 0);
    protected bool moving = false;


    public void Anim()
    {
        if (moving && !Character.inAir) name = "run";
        else if (Character.inAir) name = "jump";
        else if (!Character.isAlive) name = "death";
        else name = "idle";

        Console.WriteLine(name);
        totalFrames = (int)colRow[name].X * (int)source.width / 80;


        timer += Raylib.GetFrameTime();
        if (timer >= 0.2f)
        {
            timer = 0.0f;
            currentFrame.X++;
        }

        if (currentFrame.X > totalFrames) currentFrame.X = 0;
        for (int i = 0; i < colRow.Count; i++) currentFrame.Y = colRow[name].Y;

        source.x = currentFrame.X * source.width;
        source.y = currentFrame.Y * source.height;
    }
    public virtual void Draw()
    {
        Raylib.DrawTextureRec(currentTexture, new Rectangle(source.x, source.y, source.width * direction.X, source.height), aniVector, Color.WHITE);
    }
}
