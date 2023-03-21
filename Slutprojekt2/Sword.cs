public class Sword : Weapon
{
    private Animator a = new Animator();
    private Rectangle dest = new Rectangle(0, 0, 58, 108);
    private Vector2 origin;
    private float time;
    private bool isAttacking;
    public Sword()
    {
        sprite = Raylib.LoadTexture("./images/character/Items/sword.png");
        a.source.width = 58;
        a.source.height = 108;
        Damage = 3;
    }

    public void Update(Player p)
    {
        Timer.Update();
        time += Raylib.GetFrameTime();
        Hit();
        Collsion();
    }

    private void Collsion()
    {
        foreach (Enemy e in EnemySpawner.Enemies)
        {
            if (CheckCollisionRecs(e.rect) && Timer.CheckTimer(0.5f))
            {
                e.Hp--;
                Timer.ResetTimer();
            }
        }
    }

    private void Hit()
    {
        if (Raylib.IsMouseButtonPressed(0) && !isAttacking)
        {
            time = 0;
            isAttacking = true;
        }

        if (time >= 0.24f)
        {
            time = 0;
            isAttacking = false;
        }

        //if (isAttacking) a.Anim(2, 0, 0.08f, 0);
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
        if (Character.p.direction == 1)
        {
            a.source.width = 58;
            a.source.height = 108;
            dest = new Rectangle(Character.p.rect.x - dest.width, Character.p.rect.y, 58, 108);
        }
        else if (Character.p.direction == 2)
        {
            a.source.width = 58;
            a.source.height = 108;
            dest = new Rectangle(Character.p.rect.x + 45, Character.p.rect.y, 58, 108);
        }
        else if (Character.p.direction == 3)
        {
            a.source.width = 108;
            a.source.height = 58;
            dest = new Rectangle(Character.p.rect.x - 29, Character.p.rect.y - dest.height, 108, 58);
        }
        else
        {
            a.source.width = 108;
            a.source.height = 58;
            dest = new Rectangle(Character.p.rect.x - 29, Character.p.rect.y + Character.p.rect.height, 108, 58);
        }
    }
    public void Draw(Player p)
    {
        GetDirectionHitbox();
        Raylib.DrawRectangleRec(SwordHitbox(new Rectangle()), Color.BLACK);
        Raylib.DrawTexturePro(sprite, new Rectangle(a.source.x, a.source.y, a.source.width, a.source.height), dest, Vector2.Zero, 0, Color.WHITE);
    }

    private bool CheckCollisionRecs(Rectangle other)
    {
        return Raylib.CheckCollisionRecs(SwordHitbox(new Rectangle()), other);
    }
}
