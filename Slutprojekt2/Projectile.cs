public class Projectile
{
    public bool IsActive { get; set; } //Bool om projectile är active eller inte
    private static Texture2D arrow = Raylib.LoadTexture("./images/character/Items/arrow.png");
    private Vector2 origin; //Orign av arrow
    private float angle;
    private Vector2 velocity;
    private Vector2 pos;

    public Projectile(Player p, Vector2 pos) //Konstructor för projectile
    {
        IsActive = false;
        this.pos = pos; //Får in positionen av musen från bow
        origin = new Vector2(p.rect.x + p.rect.width / 2, p.rect.y + p.rect.height / 2); //Vart arrow skjuts ifrån
        angle = MathF.Atan2(pos.Y - origin.Y, pos.X - origin.X); //Radian mellan startpos och muspos.
    }

    public void Update(Vector2 speed) //Updaterar projectile
    {
        origin += velocity; //Orign ökar med velocity

        //Beräknar vad velocity kommer vara i x och y led beroende på angle
        velocity.X = speed.X * MathF.Cos(angle);
        velocity.Y = speed.Y * MathF.Sin(angle);

        Collision();
    }

    public void Draw() //Ritar arrow. Omvandlar radian till grader
    {
        Raylib.DrawTextureEx(arrow, origin, angle * 180 / MathF.PI, 1, Color.WHITE);
    }

    private void Collision() //Kollision för mappen och projectile
    {
        foreach (Block block in Block.blockList)
        {
            if (block.CheckCollisionPointRec(origin))
            {
                IsActive = false;
            }
        }
    }

    public bool CheckCollisionPointRec(Rectangle other) //Kollar om arrow kolliderar med någon rektangle som användes i andra klasser
    {
        return Raylib.CheckCollisionPointRec(origin, other);
    }
}
