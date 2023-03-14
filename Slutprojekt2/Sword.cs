public class Sword : Weapon
{
    Animator a = new Animator();
    private Rectangle dest = new Rectangle(0, 0, 65, 108);
    private float time;
    private bool isAttacking;
    public Sword()
    {
        sprite = Raylib.LoadTexture("./images/character/Items/swordSheet.png");
        a.source.width = 65;
        a.source.height = 108;
        Damage = 3;
    }

    public void Update(Player p)
    {
        time += Raylib.GetFrameTime();
        Hit();
    }

    private void Hit()
    {
        if (Raylib.IsMouseButtonPressed(0) && !isAttacking)
        {
            time = 0;
            isAttacking = true;
        }

        if (time >= 0.3f)
        {
            time = 0;
            isAttacking = false;
        }

        if (isAttacking) a.Anim(2, 0, 0.1f);
    }
    private Rectangle SwordHitbox(Rectangle hitbox)
    {
        if (isAttacking)
        {
            hitbox = dest;
        }
        else
        {
            hitbox = new Rectangle(0, 0, 0, 0);
        }
        return hitbox;
    }
    public void Draw(Player p)
    {
        if (p.a.direction == -1)
            dest = new Rectangle(p.rect.x - dest.width, p.rect.y, dest.width, dest.height);
        else
        {
            dest = new Rectangle(p.rect.x + 45, p.rect.y, dest.width, dest.height);
        }
        Raylib.DrawRectangleRec(SwordHitbox(dest), Color.YELLOW);
        Raylib.DrawTexturePro(sprite, new Rectangle(a.source.x, a.source.y, a.source.width * p.a.direction, a.source.height), dest, Vector2.Zero, 0, Color.WHITE);
    }
}
