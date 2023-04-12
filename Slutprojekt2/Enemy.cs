public class Enemy : Character
{
    public int DropChance { get; set; }
    private Random random = new Random();
    public int Rx //Random x position
    {
        get
        {
            return random.Next(100, 900);
        }
        private set { }
    }
    public int Ry //Random y position
    {
        get
        {
            return random.Next(100, 900);
        }
        private set { }
    }
    public Enemy() //Konstructor för enemy
    {
        a.currentTexture = Animation.spriteSheetE; //Bestämmer vilken spritesheet som enmies ska använda
    }
    public override void Update()
    {
        if (IsVisible(700)) //Om spelaren är synlig för enemy
        {//Bestämmer vilket håll enemy ska gå.
            if (DirectionUp())
            {
                a.Moving = true;
                rect.y -= speed.Y;
            }
            if (DirectionDown())
            {
                a.Moving = true;
                rect.y += speed.Y;
            }
            if (DirectionRight())
            {
                a.direction.X = 1;
                a.Moving = true;
                rect.x += speed.X;
            }
            if (DirectionLeft())
            {
                a.direction.X = -1;
                a.Moving = true;
                rect.x -= speed.X;
            }
        }
        else a.Moving = false;

        base.Update();
    }

    public bool CheckCollisionRecs(Rectangle other)
    {
        return Raylib.CheckCollisionRecs(rect, other);
    }
    public override void Draw() //Ritar ut enemey
    {
        base.Draw();
    }
}
