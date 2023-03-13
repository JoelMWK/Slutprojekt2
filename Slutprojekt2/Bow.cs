public class Bow : Weapon
{
    private List<Projectile> projectiles = new List<Projectile>();
    private Vector2 position;
    private Vector2 speed = new Vector2(8, 8);
    private int arrowCount = 1;
    private float angle;

    public Bow()
    {
        sprite = Raylib.LoadTexture("./images/character/bow.png");
        Damage = 1;
        IsActive = false;
    }
    public void Update(Player p)
    {
        position = Raylib.GetMousePosition();
        angle = MathF.Atan2(position.Y - p.rect.y, position.X - p.rect.x) * 180 / MathF.PI;


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
        Projectile projectile = new(position, p);

        if (projectiles.Count() < arrowCount)
        {
            projectiles.Add(projectile);
            projectile.isActive = true;
        }
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(sprite, new Vector2(Character.p.rect.x + 40, Character.p.rect.y + 40), angle - 45, 1.5f, Color.WHITE);
    }
}
