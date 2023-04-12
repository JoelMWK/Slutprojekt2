public class Map
{
    public List<Block> blocks = new List<Block>(); //Lista av alla block
    public int[][] Level { get; set; } //array av array
    private Random random = new Random();
    public void LoadMap(string filePath)
    {
        string jsonText = File.ReadAllText(filePath); //Läser all text i filePath som är definerat i program.cs
        var m = JsonSerializer.Deserialize<Map>(jsonText); //Deserialize av jsonText som innehåller alla values

        for (int y = 0; y < m.Level.Length; y++) //Går igenom y-led 
        {
            for (int x = 0; x < m.Level[y].Length; x++) //Går igenom x-led
            {
                if (m.Level[y][x] > 0)
                {
                    Block b = new Block(x, y, m.Level[y][x]); //Skapar ett block med blockSize och positionen
                    blocks.Add(b); //Lägger till blocket i listan blocks
                }
                else //Slumpar mellan de 3 olika floor tiles för att generera golvet.
                {
                    m.Level[y][x] = random.Next(4, 7);
                    Block b = new Block(x, y, m.Level[y][x]);
                    blocks.Add(b);
                }
            }
        }
    }
    public void DrawMap()
    {
        foreach (Block b in blocks) //Går igenom alla intanser i blocks listan
        {
            b.Draw(); //För alla instanser så utförs draw
        }
    }
}
