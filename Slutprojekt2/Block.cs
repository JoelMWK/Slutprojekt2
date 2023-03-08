public class Block
{
    public static List<Block> blockList = new List<Block>();
    private static Texture2D[] textures = {
        Raylib.LoadTexture("./images/tile/grass.png"),
         Raylib.LoadTexture("./images/tile/dirt.png"),
    }; //Array av alla tiles texturer

    public int blockHp = 3;
    public int Type { get; set; }
    public bool IsPassable { get; set; }
    private Texture2D blockTexture;
    public Rectangle rect;
    private float blockSize = 60;

    public Block(int x, int y, int type) //Konstruktor för alla blocks som har specifika värden inmatade
    {
        Type = type; //Type är en int som tar in ett value från map.cs
        rect = new Rectangle(x * blockSize, y * blockSize, blockSize, blockSize); //Definerar hur stor alla block är
        blockList.Add(this);        // blockList.Add(rect = new Rectangle(x * blockSize, y * blockSize, blockSize, blockSize));
        blockTexture = textures[Type - 1]; //Type är 1-4 då inget ska ritas på 0. textures[] är 0-1-2-3.
    }

    public void Draw()
    {
        Raylib.DrawTexture(blockTexture, (int)rect.x, (int)rect.y, Color.WHITE);
    }

    public bool CheckCollisionCircle(Vector2 pos, float radius) //kollar kollision mellan en cirkel och rect
    {
        return Raylib.CheckCollisionCircleRec(pos, 6, rect);
    }
    public bool CheckCollisionRecs(Rectangle otherRect) //Kollar kollision mellan rect och rect
    {
        return Raylib.CheckCollisionRecs(rect, otherRect);
    }
}
