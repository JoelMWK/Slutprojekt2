public class Character
{
    protected Animator a = new Animator();

    public Rectangle rect;
    protected int ground = 500;
    public bool inAir = false;
    public bool isAlive = true;
    protected float gravity = 0;

    protected Vector2 speed = new Vector2(4, 8);

    public static Player p;

    public virtual void Update()
    {
        SetGravity();
        CheckGround();
        a.Anim();
        a.aniVector.X = rect.x;
        a.aniVector.Y = rect.y;
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
            inAir = false;
        }
    }
    public void MapCollision()
    {
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect))
            {
                if (rect.y + rect.height > block.rect.y && rect.y < block.rect.y - block.rect.height)
                {
                    rect.y = block.rect.y - rect.height;
                    gravity = 0;
                    inAir = false;
                }

                else if (rect.x >= block.rect.x) rect.x += speed.X;
                else if (rect.x <= block.rect.x) rect.x -= speed.X;
            }
        }
    }
}
