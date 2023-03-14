public class Projectile
{
    public bool isActive { get; set; }
    private static Texture2D arrow = Raylib.LoadTexture("./images/character/Items/arrow.png");
    private Vector2 origin;
    private Rectangle rect = new Rectangle(0, 0, arrow.width, arrow.height);
    private Rectangle source = new Rectangle(0, 0, arrow.width, arrow.height);
    private float gravity;
    private int dir;

    public Projectile(Player p)
    {
        isActive = false;
        origin = new Vector2(p.rect.x + 40 * dir, p.rect.y + 30);
        dir = p.a.direction;
        source.width *= dir;
    }

    public void Update(int velocity)
    {
        origin.X += velocity * dir;

        rect.x = origin.X;
        rect.y = origin.Y;

        ProjectileDrop();
        Collision();
        Draw();
    }

    private void ProjectileDrop()
    {
        origin.Y += gravity;
        gravity += 0.04f;
    }

    private void Draw()
    {
        Raylib.DrawTextureRec(arrow, source, new Vector2(rect.x, rect.y), Color.WHITE);
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
        if (rect.x >= Raylib.GetScreenWidth() || rect.x < 0 || rect.y >= Raylib.GetScreenWidth())
        {
            isActive = false;
        }
    }
}
