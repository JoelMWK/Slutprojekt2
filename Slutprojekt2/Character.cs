public class Character
{
    public Animator a = new Animator();
    public int Hp { get; set; }
    public bool InAir { get; set; } = false;
    public bool IsAlive { get; set; } = true;
    public Rectangle rect;
    protected int ground = 500;
    protected float gravity = 0;
    protected Vector2 speed = new Vector2(4, 8);
    public static Player p;
    public static Enemy e;

    public virtual void Update()
    {
        SetGravity();
        CheckGround();
        a.Anim((int)a.animations.ani[a.Name].X, (int)a.animations.ani[a.Name].Y, a.animations.ani[a.Name].Z);
    }

    public virtual void Draw()
    {
        a.Draw(this);
    }

    public void SetGravity()
    {
        rect.y += gravity;
        gravity += 0.3f;
    }
    public void CheckGround()
    {
        if (rect.y + rect.height >= ground)
        {
            rect.y = ground - rect.height;
            gravity = 0;
            InAir = false;
        }
    }

    public void MapCollision()
    {
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect))
            {
                if (rect.y + rect.height >= block.rect.y)
                {
                    rect.y = block.rect.y - rect.height;
                    gravity = 0;
                    InAir = false;
                }
                /*    else if (rect.x + rect.width <= block.rect.x)
                   {
                       rect.x -= speed.X;
                   }
                   else if (rect.x >= block.rect.x + block.rect.width)
                   {
                       rect.x += speed.X;
                   } */
            }
        }
    }
}
