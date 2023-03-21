public class ClassSelector
{
    public static List<Player> players = new List<Player>()
    {
        new Archer(),
        new Knight(),
    };

    public bool selected;
    public int classIndex;
    private static Texture2D[] images = {
        Raylib.LoadTexture("./images/character/archer.png"),
        Raylib.LoadTexture("./images/character/knight.png"),
    };

    private Rectangle buttonA = new Rectangle(250, 250, 150, 225);
    private Rectangle buttonB = new Rectangle(500, 250, 150, 225);

    public void ChoosePlayer()
    {
        if (Raylib.IsMouseButtonPressed(0))
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonA))
            {
                selected = true;
                classIndex = 0;
            }
            else if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonB))
            {
                selected = true;
                classIndex = 1;
            }
        }

        Character.p = players[classIndex];

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawText("Choose a class", 280, 100, 40, Color.WHITE);

        Raylib.DrawTexture(images[0], (int)buttonA.x, (int)buttonA.y, Color.WHITE);
        Raylib.DrawTexture(images[1], (int)buttonB.x, (int)buttonB.y, Color.WHITE);

        Raylib.EndDrawing();
    }
    public void Update()
    {
        players[classIndex].Update();
        players[classIndex].MapCollision();
    }

    public void Draw()
    {
        players[classIndex].Draw();
    }
}
