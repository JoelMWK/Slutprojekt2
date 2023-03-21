public class Bow : Weapon
{
    private List<Projectile> projectiles = new List<Projectile>();
    private Vector2 speed = new Vector2(8, 8);
    private int arrowCount = 10;
    private Rectangle source = new Rectangle(0, 0, 14, 50);
    private Vector2 pos;
    private float angle;

    public Bow()
    {
        sprite = Raylib.LoadTexture("./images/character/Items/bow.png");
        Damage = 1;
        IsActive = false;
    }
    public void Update(Player p)
    {
        pos = MousePosition();
        angle = MathF.Atan2(pos.Y - p.rect.y, pos.X - p.rect.x) * 180 / MathF.PI;

        if (Raylib.IsMouseButtonPressed(0))
        {
            Shoot(p);
        }

        foreach (Projectile projectile in projectiles)
        {
            projectile.Update(speed);
        }
        projectiles.RemoveAll(projectile => !projectile.IsActive);
    }

    public void Shoot(Player p)
    {
        Projectile projectile = new(p, pos);

        if (projectiles.Count() < arrowCount)
        {
            projectiles.Add(projectile);
            projectile.IsActive = true;
        }
    }

    private Vector2 MousePosition()
    {
        return Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), Character.p.camera.Camera2D);
    }

    public void Draw(Player p)
    {
        foreach (Projectile projectile in projectiles)
        {
            projectile.Draw();
        }
        //Raylib.DrawTextureEx(sprite, new Vector2(p.rect.x, p.rect.y), angle, 1, Color.WHITE);
        Raylib.DrawTexturePro(sprite, source, new Rectangle(p.rect.x + 50, p.rect.y + 40, source.width, source.height), new Vector2(0, sprite.height / 2), angle, Color.WHITE);
        Raylib.DrawLine((int)p.rect.x, (int)p.rect.y, (int)pos.X, (int)pos.Y, Color.BLACK);
        //Raylib.DrawTextureRec(sprite, source, pos, Color.WHITE);
    }
}
