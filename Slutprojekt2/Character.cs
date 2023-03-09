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
    public static Enemy e;

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
        Raylib.DrawText("pX: " + Character.p.rect.x, 10, 0, 20, Color.BLACK);
        Raylib.DrawText("pY: " + Character.p.rect.y, 10, 20, 20, Color.BLACK);
        Raylib.DrawText("Player Animation: " + Character.p.a.Name, 200, 20, 20, Color.BLACK);
        Raylib.DrawText("Enemy Animation: " + Character.e.a.Name, 200, 40, 20, Color.BLACK);
        Raylib.DrawText("eX: " + Character.e.rect.x, 10, 60, 20, Color.BLACK);
        Raylib.DrawText("eY: " + Character.e.rect.y, 10, 80, 20, Color.BLACK);

        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionRecs(rect))
            {

                if (rect.y + rect.height >= block.rect.y)
                {
                    rect.y = block.rect.y - rect.height;
                    gravity = 0;
                    inAir = false;
                }

                /*   else if (rect.y >= block.rect.y + block.rect.height)
                  {
                      rect.y += speed.Y;
                  }  */
            }
        }
    }
}
