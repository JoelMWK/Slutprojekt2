public class Bow : Weapon
{
    private Timer timer = new Timer();
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
            timer.Update();
            foreach (Enemy e in EnemySpawner.Enemies)
            {
                if (projectile.CheckCollisionPointRec(e.rect) && timer.CheckTimer(0.5f))
                {
                    e.GetHit(Damage);
                    IsActive = false;
                    timer.ResetTimer();
                }
            }
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
        return Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), Character.P.Cam.Camera2D);
    }

    public void Draw(Player p)
    {
        foreach (Projectile projectile in projectiles)
        {
            projectile.Draw();
        }
        Raylib.DrawTexturePro(sprite, source, new Rectangle(p.rect.x + 20, p.rect.y + p.rect.height / 2, source.width, source.height), new Vector2(-40, 25), angle, Color.WHITE);
        Raylib.DrawLine((int)p.rect.x, (int)p.rect.y, (int)pos.X, (int)pos.Y, Color.BLACK);
    }
}
