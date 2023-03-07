public class Character : Animator
{
    public static Texture2D[] animStates = {
        Raylib.LoadTexture("./images/character/idle.png"),
        Raylib.LoadTexture("./images/character/walk.png"),
        Raylib.LoadTexture("./images/character/walkG.png"),
    };
    public static Texture2D animAction = Raylib.LoadTexture("./images/character/gun.png");

    protected Rectangle rect = new Rectangle(0, 0, 58, 88);
    protected Rectangle gRect = new Rectangle(0, 0, 48, 11);

    int ground = 850;
    bool inAir = false;
    float gravity = 0;

    Vector2 speed = new Vector2(4, 8);

    public void Update()
    {
        SetGravity();
        CheckGround();
        Movement();
        Anim();
        aniVector.X = rect.x;
        aniVector.Y = rect.y;
    }

    public void SetGravity()
    {
        rect.y += gravity;
        gravity += 0.3f;
    }
    public void CheckGround()
    {
        if (rect.y + 88 >= ground)
        {
            rect.y = ground - 88;
            gravity = 0;
            inAir = false;
        }
    }

    public void Movement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && !inAir)
        {
            inAir = true;
        }

        if (inAir == true)
        {
            rect.y -= speed.Y;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) { rect.x -= speed.X; direction.X = -1; moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) { rect.x += speed.X; direction.X = 1; moving = true; }
    }
    public override void Draw()
    {
        base.Draw();
        //Raylib.DrawTexture(animAction, (int)rect.x + 25, (int)rect.y + 45, Color.WHITE);
    }
}
