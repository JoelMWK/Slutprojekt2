public class Character : Animator
{
    public Rectangle rect = new Rectangle(0, 0, 46, 80);
    int ground = 500;
    public static bool inAir = false;
    public static bool isAlive = true;
    float gravity = 0;

    Vector2 speed = new Vector2(4, 8);

    public static Player p;

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
        if (rect.y + 80 >= ground)
        {
            rect.y = ground - 80;
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
        if (Raylib.IsKeyReleased(KeyboardKey.KEY_D) || Raylib.IsKeyReleased(KeyboardKey.KEY_A)) moving = false;
    }
    public override void Draw()
    {
        base.Draw();
    }
}
