public class Sword : Weapon
{
    private Animator a = new Animator();
    private Rectangle dest = new Rectangle(0, 0, 58, 108);
    private Vector2 origin;
    private bool isAttacking;
    private Vector2 dir;
    private static Texture2D[] swordTexture = {
        Raylib.LoadTexture("./images/character/Items/sword.png"),
        Raylib.LoadTexture("./images/character/Items/sword2.png")
    };
    public Sword()
    {
        sprite = swordTexture[1];
        a.source.width = 58;
        a.source.height = 108;
        Damage = 3;
    }

    public void Update(Player p)
    {
        Hit();
        Collsion();
    }

    private void Collsion()
    {
        timer.Update();
        foreach (Enemy e in EnemySpawner.Enemies)
        {
            if (CheckCollisionRecs(e.rect) && timer.CheckTimer(0.5f))
            {
                e.GetHit(Damage);
                timer.ResetTimer();
            }
        }
    }

    private void Hit()
    {
        timer2.Update();
        if (Raylib.IsMouseButtonPressed(0) && !isAttacking)
        {
            timer2.ResetTimer();
            isAttacking = true;
        }

        if (timer2.CheckTimer(0.24f))
        {
            timer2.ResetTimer();
            isAttacking = false;
        }

        if (isAttacking) a.Anim(2, 0, 0.08f, 0);
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

    private void GetDirectionHitbox()
    {
        if (Character.P.Direction == 1)
        {
            sprite = swordTexture[0];
            dir.Y = -1;
            dir.X = 1;
            a.source.width = 58;
            a.source.height = 108;
            dest = new Rectangle(Character.P.rect.x - dest.width, Character.P.rect.y, 58, 108);
        }
        else if (Character.P.Direction == 2)
        {
            sprite = swordTexture[0];
            dir.Y = 1;
            dir.X = 1;
            a.source.width = 58;
            a.source.height = 108;
            dest = new Rectangle(Character.P.rect.x + 45, Character.P.rect.y, 58, 108);
        }
        else if (Character.P.Direction == 3)
        {
            sprite = swordTexture[1];
            dir.X = -1;
            a.source.width = 108;
            a.source.height = 58;
            dest = new Rectangle(Character.P.rect.x - 29, Character.P.rect.y - dest.height, 108, 58);
        }
        else
        {
            sprite = swordTexture[1];
            dir.X = 1;
            a.source.width = 108;
            a.source.height = 58;
            dest = new Rectangle(Character.P.rect.x - 29, Character.P.rect.y + Character.P.rect.height, 108, 58);
        }
    }
    public void Draw(Player p)
    {
        GetDirectionHitbox();
        Raylib.DrawTexturePro(sprite, new Rectangle(a.source.x, a.source.y, a.source.width * dir.Y, a.source.height * dir.X), dest, Vector2.Zero, 0, Color.WHITE);
    }

    private bool CheckCollisionRecs(Rectangle other)
    {
        return Raylib.CheckCollisionRecs(SwordHitbox(new Rectangle()), other);
    }
}
