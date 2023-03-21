public class Enemy : Character
{
    public Enemy()
    {
        a.currentTexture = Animation.spriteSheetE;
    }
    public override void Update()
    {
        if (IsVisible(250))
        {
            if (RightSide())
            {
                rect.x += speed.X;
                a.direction.X = 1;
                a.moving = true;
            }
            else
            {
                rect.x -= speed.X;
                a.direction.X = -1;
                a.moving = true;
            }
        }
        else a.moving = false;

        base.Update();
    }
    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
        base.Draw();
    }
}
