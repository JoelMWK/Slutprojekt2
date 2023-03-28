public class Enemy : Character
{
    public int DropChance { get; set; }
    private Random random = new Random();
    public int Rx
    {
        get
        {
            return random.Next(100, 900);
        }
        private set { }
    }
    public int Ry
    {
        get
        {
            return random.Next(100, 900);
        }
        private set { }
    }
    public Enemy()
    {
        a.currentTexture = Animation.spriteSheetE;
    }
    public override void Update()
    {
        if (IsVisible(700))
        {
            if (DirectionUp())
            {
                a.moving = true;
                rect.y -= speed.Y;
            }
            if (DirectionDown())
            {
                a.moving = true;
                rect.y += speed.Y;
            }
            if (DirectionRight())
            {
                a.direction.X = 1;
                a.moving = true;
                rect.x += speed.X;
            }
            if (DirectionLeft())
            {
                a.direction.X = -1;
                a.moving = true;
                rect.x -= speed.X;
            }
        }
        else a.moving = false;

        base.Update();
    }

    public bool CheckCollisionRecs(Rectangle other)
    {
        return Raylib.CheckCollisionRecs(rect, other);
    }
    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
        base.Draw();
    }
}
