public class Sword : Weapon
{
    private Timer timer = new Timer();
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
        timer.Update();
        time += Raylib.GetFrameTime();
        Hit();
        Collsion();
    }

    private void Collsion()
    {
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
            a.source.width = 58;
            a.source.height = 108;
            dest = new Rectangle(Character.P.rect.x - dest.width, Character.P.rect.y, 58, 108);
        }
        else if (Character.P.Direction == 2)
        {
            a.source.width = 58;
            a.source.height = 108;
            dest = new Rectangle(Character.P.rect.x + 45, Character.P.rect.y, 58, 108);
        }
        else if (Character.P.Direction == 3)
        {
            a.source.width = 108;
            a.source.height = 58;
            dest = new Rectangle(Character.P.rect.x - 29, Character.P.rect.y - dest.height, 108, 58);
        }
        else
        {
            a.source.width = 108;
            a.source.height = 58;
            dest = new Rectangle(Character.P.rect.x - 29, Character.P.rect.y + Character.P.rect.height, 108, 58);
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
