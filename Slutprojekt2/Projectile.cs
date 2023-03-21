public class Projectile
{
    public bool IsActive { get; set; }
    private static Texture2D arrow = Raylib.LoadTexture("./images/character/Items/arrow.png");
    private Vector2 origin;
    private Rectangle rect;
    private float angle;
    private Vector2 velocity;
    private Vector2 pos;

    public Projectile(Player p, Vector2 pos)
    {
        IsActive = false;
        this.pos = pos;
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

        Collision();
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(arrow, new Vector2(rect.x, rect.y), angle * 180 / MathF.PI, 1, Color.WHITE);
    }

    private void Collision()
    {
        Timer.Update();
        foreach (Enemy e in EnemySpawner.Enemies)
        {
            if (CheckCollisionPointRec(e.rect) && Timer.CheckTimer(0.5f))
            {
                e.Hp--;
                IsActive = false;
                Timer.ResetTimer();
            }
        }
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionPointRec(origin))
            {
                IsActive = false;
            }
        }
    }

    public bool CheckCollisionPointRec(Rectangle other)
    {
        return Raylib.CheckCollisionPointRec(origin, other);
    }
}
