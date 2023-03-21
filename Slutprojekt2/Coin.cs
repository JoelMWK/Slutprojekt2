public class Coin
{
    private Animator a = new Animator();
    private static Texture2D coinTexture = Raylib.LoadTexture("./images/character/Items/coin.png");
    public Rectangle coinRect = new Rectangle(0, 0, 24, 28);
    public static List<Coin> Coins { get; private set; } = new List<Coin>();
    private Random random = new Random();
    public Coin(int x, int y)
    {
        coinRect = new Rectangle(x, y, coinRect.width, coinRect.height);
        a.source.width = 24;
        a.source.height = 28;
    }
    public void Update()
    {
        a.Anim(3, 0, 0.1f, 0);
    }
    public void Draw()
    {
        Raylib.DrawTexturePro(coinTexture, new Rectangle(a.source.x, a.source.y, a.source.width, a.source.height), coinRect, Vector2.Zero, 0, Color.WHITE);
    }
}
