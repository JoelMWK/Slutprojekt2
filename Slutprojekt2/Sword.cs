public class Sword : Weapon
{
    private Animator a = new Animator();
    private Rectangle dest = new Rectangle(0, 0, 58, 108);
    private float time;
    private bool isAttacking;
    public Sword()
    {
        sprite = Raylib.LoadTexture("./images/character/Items/swordSheet.png");
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
        foreach (Enemy e in EnemySpawner.enemies)
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
    public void Draw(Player p)
    {
        if (p.a.direction == -1)
            dest = new Rectangle(p.rect.x - dest.width, p.rect.y, dest.width, dest.height);
        else
        {
            dest = new Rectangle(p.rect.x + 45, p.rect.y, dest.width, dest.height);
        }
        Raylib.DrawTexturePro(sprite, new Rectangle(a.source.x, a.source.y, a.source.width * p.a.direction, a.source.height), dest, Vector2.Zero, 0, Color.WHITE);
    }

    private bool CheckCollisionRecs(Rectangle other)
    {
        return Raylib.CheckCollisionRecs(SwordHitbox(new Rectangle()), other);
    }
}
