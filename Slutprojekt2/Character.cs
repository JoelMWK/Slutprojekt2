public class Character
{
    public Animator a = new Animator();
    public float Hp { get; set; } //Hp för aalla karaktärer
    public float Damage { get; set; } //Damage för allla karaktärer
    public int MarginY { get; set; } //MarginY som används för spritesheet animation om de två olika gubbarna har olika storlekar
    public bool IsAlive //Om karaktären är vid liv elelr inte
    {
        get
        {
            return Hp > 0;
        }
    }
    public static Player P { get; set; }
    public static Enemy E { get; set; }
    public Rectangle rect;
    protected Vector2 speed = new Vector2(6, 6);

    public virtual void Update() //Updaterar animationerna för karaktärerna
    {
        a.Anim(a.animations.ani[a.Name].col, a.animations.ani[a.Name].row, a.animations.ani[a.Name].frameSpeed, MarginY);
    }

    public virtual void Draw() //Ritar ut karaktären
    {
        a.Draw(this);
    }

    public void MapCollision() //Mapp kollision för spelare och enemy
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
                    rect.y -= speed.Y;
                }
                else if (bottom < top && bottom < left && bottom < right) //Kollar om spelaren kolliderar på undersidan av blocket
                {
                    rect.y += speed.Y;
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

    public void GetHit(float damageAmount) // Metod för ta skada
    {
        Hp -= damageAmount;
    }

    public bool IsVisible(int distance) //Om spelaren är synlig beroende på distance
    {
        return Vector2.Distance(new Vector2(P.rect.x, P.rect.y), new Vector2(E.rect.x, E.rect.y)) <= distance;
    }
    //Vilket håll enemy ska gå
    public bool DirectionLeft()
    {
        return E.rect.x > P.rect.x;
    }
    public bool DirectionRight()
    {
        return E.rect.x < P.rect.x;
    }
    public bool DirectionUp()
    {
        return E.rect.y > P.rect.y;
    }
    public bool DirectionDown()
    {
        return E.rect.y < P.rect.y;
    }
}
