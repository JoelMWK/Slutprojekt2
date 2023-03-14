public class Player : Character
{
    //Bow bow = new Bow();
    public Player()
    {
        p = this;
        rect = new Rectangle(0, 0, 45, 81);
        a.currentTexture = Animation.spriteSheetP;
    }
    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
        //bow.Draw();
        base.Draw();
    }
    public override void Update()
    {
        //bow.Update(this);
        base.Update();
        Movement();
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

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) { rect.x -= speed.X; a.direction = -1; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) { rect.x += speed.X; a.direction = 1; a.moving = true; }
        if (Raylib.IsKeyReleased(KeyboardKey.KEY_D) || Raylib.IsKeyReleased(KeyboardKey.KEY_A)) a.moving = false;
    }
}
