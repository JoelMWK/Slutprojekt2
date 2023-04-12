public class Coin
{
    private Animator a = new Animator();
    private static Texture2D coinTexture = Raylib.LoadTexture("./images/character/Items/coin.png");
    private Random random = new Random();
    public Rectangle coinRect = new Rectangle(0, 0, 24, 28);
    public static List<Coin> Coins { get; private set; } = new List<Coin>(); //Lista för alla coins
    public bool IsPickedUp { get; set; } //Bool om coin är tagen eller inte
    public Coin(int x, int y) //Konstructor för coin, som bestämmer hur stor den är och vart den ska spawnas (x,y)
    {
        coinRect = new Rectangle(x, y, coinRect.width, coinRect.height);
        a.source.width = 24;
        a.source.height = 28;
    }
    public void Update() //Updaterar coins animation och collsiosn.
    {
        a.Anim(3, 0, 0.1f, 0); //Definerar hur snabb, row, och column för coin spritsheet
        Collision();
    }
    public void Draw() //Ritar ut coin
    {
        Raylib.DrawTexturePro(coinTexture, new Rectangle(a.source.x, a.source.y, a.source.width, a.source.height), coinRect, Vector2.Zero, 0, Color.WHITE);
    }

    private void Collision() //Hanterar kollsionen mellan player och coin
    {
        if (Raylib.CheckCollisionRecs(coinRect, Character.P.rect))
        {
            IsPickedUp = true;
            Character.P.Points++;
        }
    }
}
