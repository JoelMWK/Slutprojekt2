public class Sword : Weapon
{
    public Rectangle hitbox = new Rectangle(0, 0, 20, 58);
    private Rectangle source = new Rectangle(0, 0, 20, 58);

    public Sword()
    {
        sprite = Raylib.LoadTexture("./images/character/Items/sword.png");
        Damage = 3;
    }

    public void Update(Character p)
    {
        hitbox = new Rectangle(p.rect.x + 45, p.rect.y, hitbox.width, hitbox.height);
        if (Raylib.IsMouseButtonPressed(0))
        {
            Console.WriteLine("attack");
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(hitbox, Color.WHITE);

        Raylib.DrawTexturePro(sprite, source, hitbox, new Vector2(hitbox.x + sprite.width / 2, hitbox.y + sprite.height), 20 * (float)Raylib.GetTime() * 10, Color.WHITE);
        //Raylib.DrawTexture(sprite, (int)hitbox.x, (int)hitbox.y, Color.WHITE);
    }
}
