public class Projectile
{
    public bool isActive { get; set; }
    private static Texture2D arrow = Raylib.LoadTexture("./images/character/arrow.png");
    private Vector2 pos;
    private Vector2 origin;
    private Rectangle rect = new Rectangle(0, 0, arrow.width, arrow.height);
    public Vector2 velocity;
    private float angle;
    private float gravity;

    public Projectile(Vector2 position, Player p)
    {
        isActive = false;
        pos = position;
        origin = new Vector2(p.rect.x + 40, p.rect.y + 30);
        angle = MathF.Atan2(pos.Y - origin.Y, pos.X - origin.X);
    }

    public void Update(Vector2 speed)
    {
        origin += velocity;

        rect.x = origin.X;
        rect.y = origin.Y;

        velocity.X = speed.X * MathF.Cos(angle);
        velocity.Y = speed.Y * MathF.Sin(angle);
        ProjectileDrop();
        Collision();
        Draw();
    }

    private void ProjectileDrop()
    {
        origin.Y += gravity;
        gravity += 0.08f;
    }

    private void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.WHITE);
        Raylib.DrawTextureEx(arrow, new Vector2(rect.x, rect.y), angle * 180 / MathF.PI, 1, Color.WHITE);
    }

    private void Collision()
    {
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect))
            {
                isActive = false;
            }
        }
        if (rect.x >= Raylib.GetScreenWidth() || rect.x < 0 || rect.y >= Raylib.GetScreenWidth() || rect.y < 0)
        {
            isActive = false;
        }
    }
}
