public class Enemy : Character
{
    public Enemy()
    {
        e = this;
        rect = new Rectangle(0, 0, 64, 83);
        a.currentTexture = Animation.spriteSheetE;
        speed.X = 0.5f;
    }
    public override void Update()
    {
        if (IsVisible(250))
        {
            if (RightSide())
            {
                rect.x += speed.X;
                a.direction = 1;
                a.moving = true;
            }
            else
            {
                rect.x -= speed.X;
                a.direction = -1;
                a.moving = true;
            }
        }
        else a.moving = false;

        base.Update();

        if (a.moving) a.Name = "E_Walk";
        else a.Name = "E_Idle";
    }
    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
        if (IsAlive)
            base.Draw();
    }
}
