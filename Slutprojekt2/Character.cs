public class Character
{
    public Animator a = new Animator();
    public int Hp { get; set; }
    public bool InAir { get; set; } = false;
    public bool IsAlive
    {
        get
        {
            return Hp > 0;
        }
    }
    public Rectangle rect;
    protected int ground = 500;
    protected float gravity;
    protected Vector2 speed = new Vector2(4, 8);
    public static Player p;
    public static Enemy e;
    public int MarginY { get; set; }

    public virtual void Update()
    {
        SetGravity();
        CheckGround();
        a.Anim((int)a.animations.ani[a.Name].X, (int)a.animations.ani[a.Name].Y, a.animations.ani[a.Name].Z, MarginY);
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
                float left = rect.x + rect.width - block.rect.x; //vänster sida av blocket - höger sida av character
                float right = block.rect.x + block.rect.width - rect.x; //höger sida av blocket - vänster sida av character
                float top = rect.y + rect.height - block.rect.y; //toppen av blocket - botten av character
                float bottom = block.rect.y + block.rect.height - rect.y; //botten av blocket - toppen av character      

                if (top < bottom && top < left && top < right) //Kollar om spelaren kolliderar på toppen av blocket
                {
                    rect.y = block.rect.y - rect.height;
                    gravity = 0;
                    InAir = false;
                }
                else if (bottom < top && bottom < left && bottom < right) //Kollar om spelaren kolliderar på undersidan av blocket
                {
                    rect.y = block.rect.y + block.rect.height;
                }
                else if (left < right) //Kollar om spelare kolliderar på vänster om blocket
                {
                    rect.x -= speed.X;
                }
                else //Kollar om spelare kolliderar på höger om blocket
                {
                    rect.x += speed.X;
                }
            }
        }
    }

    public bool IsVisible(int distance)
    {
        return Vector2.Distance(new Vector2(p.rect.x, p.rect.y), new Vector2(e.rect.x, e.rect.y)) <= distance;
    }
    public bool LeftSide()
    {
        return e.rect.x >= p.rect.x;
    }
    public bool RightSide()
    {
        return e.rect.x <= p.rect.x;
    }
}
