public class Bow : Weapon
{
    private List<Projectile> projectiles = new List<Projectile>();
    private int speed = 10;
    private int arrowCount = 1;
    private Rectangle source = new Rectangle(0, 0, 14, 50);
    private Vector2 pos;

    public Bow()
    {
        sprite = Raylib.LoadTexture("./images/character/Items/bow.png");
        Damage = 1;
        IsActive = false;
    }
    public void Update(Player p)
    {
        if (Raylib.IsMouseButtonPressed(0))
        {
            Shoot(p);
        }

        foreach (Projectile projectile in projectiles)
        {
            projectile.Update(speed);
        }
        projectiles.RemoveAll(projectile => !projectile.isActive);
    }

    public void Shoot(Player p)
    {
        Projectile projectile = new(p);

        if (projectiles.Count() < arrowCount)
        {
            projectiles.Add(projectile);
            projectile.isActive = true;
        }
    }

    public void Draw(Player p)
    {
        if (p.a.direction == -1) pos = new Vector2(p.rect.x - 15, p.rect.y + 14);
        else pos = new Vector2(p.rect.x + 45, p.rect.y + 14);
        Raylib.DrawTextureRec(sprite, new Rectangle(source.x, source.y, source.width * p.a.direction, source.height), pos, Color.WHITE);
    }
}
