public class TileInfo
{
    //Dictionary som sparar information för alla tiles.
    //colRow - x och y på spritesheet.
    //bool isFloor - Om tilen är golv för att den inte ska ha någon kollision.
    //bool isTrap - Om tilen är en trap, eftersom den ska ha en annorlunda kollision jämfört med resten av blocken.
    public Dictionary<int, (Vector2 colRow, bool isFloor, bool isTrap)> tile = new Dictionary<int, (Vector2 colRow, bool isFloor, bool isTrap)>();

    public TileInfo() //Konstructor för TIleinfo. Lägger till blocken in i dictionaryn, med olika values.
    {
        tile.Add(1, (new Vector2(0, 0), false, false));
        tile.Add(2, (new Vector2(1, 0), false, false));
        tile.Add(3, (new Vector2(2, 0), false, false));
        tile.Add(4, (new Vector2(0, 1), true, false));
        tile.Add(5, (new Vector2(1, 1), true, false));
        tile.Add(6, (new Vector2(2, 1), true, false));
        tile.Add(7, (new Vector2(0, 2), false, true));
        tile.Add(8, (new Vector2(1, 2), false, false));
        tile.Add(9, (new Vector2(2, 2), false, false));
    }
}