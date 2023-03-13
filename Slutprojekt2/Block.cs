public class Block
{
    public static List<Block> blockList = new List<Block>();
    protected static Texture2D[] textures = {
        Raylib.LoadTexture("./images/tile/grass.png"),
        Raylib.LoadTexture("./images/tile/dirt.png"),
        Raylib.LoadTexture("./images/tile/platform.png"),
        Raylib.LoadTexture("./images/tile/saw.png"),
        Raylib.LoadTexture("./images/tile/box.png"),
    };

    public int Type { get; set; }
    private Texture2D blockTexture;
    public Rectangle rect;
    private double rot = 20;
    protected float blockSize = 60;

    public Block(int x, int y, int type) //Konstruktor för alla blocks som har specifika värden inmatade
    {
        Type = type; //Type är en int som tar in ett value från map.cs
        rect = new Rectangle(x * blockSize, y * blockSize, textures[Type - 1].width, textures[Type - 1].height);
        blockList.Add(this);        // blockList.Add(rect = new Rectangle(x * blockSize, y * blockSize, blockSize, blockSize));
        blockTexture = textures[Type - 1]; //Type är 1-4 då inget ska ritas på 0. textures[] är 0-1-2-3.
    }
    public void Draw()
    {
        if (Type == 4) Raylib.DrawTexturePro(blockTexture, rect, new Rectangle(rect.x + 30, rect.y + 30, rect.width, rect.height), new Vector2(rect.width / 2, rect.height / 2), (float)rot * (float)Raylib.GetTime() * 10, Color.WHITE);
        else Raylib.DrawTexture(blockTexture, (int)rect.x, (int)rect.y, Color.WHITE);
        Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
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
