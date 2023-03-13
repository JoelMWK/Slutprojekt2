public class Bow : Weapon
{
    private Vector2 speed = new Vector2(12, 12);
    public Vector2 position;
    private int dir;
    public int arrowCount = 1;
    float angle;

    public Bow()
    {
        sprite = Raylib.LoadTexture("./images/character/bow.png");
        Damage = 1;
        IsActive = false;
    }
    public void Update(Player p)
    {
        position = Raylib.GetMousePosition();
        rect = new Rectangle(p.rect.x + 40, p.rect.y + 40, 80, 80);
        angle = MathF.Atan2(position.Y - rect.y, position.X - rect.x) * 180 / MathF.PI;
        Raylib.DrawLine((int)p.rect.x + 30, (int)p.rect.y + 45, (int)position.X, (int)position.Y, Color.BLACK);
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(sprite, new Vector2(rect.x, rect.y), angle - 45, 1.5f, Color.WHITE);
    }
}
