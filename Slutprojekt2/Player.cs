public class Player : Character
{
    //Rectangle gRect = new Rectangle(0, 0, 48, 11);
    //Vector2 pos;
    //float angle;

    public Player()
    {
        p = this;
        rect = new Rectangle(0, 0, 46, 80);
        a.currentTexture = AnimationHandler.spriteSheetP;
    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.GREEN);
        base.Draw();
        //Raylib.DrawTextureEx(gun, new Vector2(gRect.x, gRect.y), angle, 1, Color.WHITE);
        //Raylib.DrawLine((int)rect.x + 30, (int)rect.y + 45, (int)pos.X, (int)pos.Y, Color.BLACK);
    }
    public override void Update()
    {
        base.Update();
        Console.WriteLine("p: " + a.Name);
        if (a.moving && !inAir) a.Name = "run";
        else if (inAir) a.Name = "jump";
        else if (!isAlive) a.Name = "death";
        else a.Name = "idle";

        Movement();
    }

    /*public void UpdateGun()
    {
        pos = Raylib.GetMousePosition();
        gRect = new Rectangle(rect.x + 30, rect.y + 45, 48, 11);
        angle = MathF.Atan2(pos.Y - gRect.y, pos.X - gRect.x) * 180 / MathF.PI;
    }*/

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

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) { rect.x -= speed.X; a.direction.X = -1; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) { rect.x += speed.X; a.direction.X = 1; a.moving = true; }
        if (Raylib.IsKeyReleased(KeyboardKey.KEY_D) || Raylib.IsKeyReleased(KeyboardKey.KEY_A)) a.moving = false;
    }
}
