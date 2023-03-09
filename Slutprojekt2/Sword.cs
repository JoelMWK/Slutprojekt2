public class Sword : Weapon
{
    public Rectangle hitbox = new Rectangle(0, 0, 50, 20);
    public Sword()
    {
        sprite = Raylib.LoadTexture("./images/character/sword.png");
        Damage = 2;
        scale = 2;
    }

    public void Update()
    {
        hitbox.x = Character.p.rect.x;
        hitbox.y = Character.p.rect.y;
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(sprite, new Vector2(hitbox.x, hitbox.y), rot, scale, Color.WHITE);
    }
}
