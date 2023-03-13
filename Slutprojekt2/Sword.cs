public class Sword : Weapon
{
    public Rectangle hitbox = new Rectangle(0, 0, 20, 20);

    public Sword()
    {
        Damage = 3;
    }

    public void Update(Character p)
    {
        hitbox = new Rectangle(p.rect.x, p.rect.y, 20, 20);
        if (Raylib.IsMouseButtonPressed(0))
        {
            Console.WriteLine("attack");
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(hitbox, Color.WHITE);
    }
}
