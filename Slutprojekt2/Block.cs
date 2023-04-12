public class Block
{
    public TileInfo tileInfo = new TileInfo();
    private Rectangle source;
    protected static Texture2D tileset = Raylib.LoadTexture("./images/tile/tileset.png");
    protected float tileSize = 64;
    public Rectangle rect;
    public static List<Block> blockList = new List<Block>();
    public int Type { get; set; } //Vilken typ av block

    public Block(int x, int y, int type) //Konstruktor för alla blocks som har specifika värden inmatade
    {
        Type = type; //Type är en int som tar in ett value från map.cs
        rect = new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize);
        source = rect;
        if (!tileInfo.tile[Type].isFloor && !tileInfo.tile[Type].isTrap) // kollar om en tile är floor eller inte
        { blockList.Add(this); }

        //Tar reda på vilken plats blocket befinenr sig i spritesheetet
        source.x = tileInfo.tile[Type].colRow.X * source.width;
        source.y = tileInfo.tile[Type].colRow.Y * source.height;
    }
    public void Draw()
    {
        Raylib.DrawTextureRec(tileset, source, new Vector2(rect.x, rect.y), Color.WHITE);
        //Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
    }

    public bool CheckCollisionPointRec(Vector2 pos) //kollar kollision mellan en cirkel och rect
    {
        return Raylib.CheckCollisionPointRec(pos, rect);
    }
    public bool CheckCollisionRecs(Rectangle otherRect) //Kollar kollision mellan rect och rect
    {
        return Raylib.CheckCollisionRecs(rect, otherRect);
    }
}
