public class ClassSelector
{
    public static List<Player> players = new List<Player>()
    {
        new Archer(),
        new Knight(),
    };

    public bool Selected { get; set; }
    public int ClassIndex { get; set; }
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
                Selected = true;
                ClassIndex = 0;
            }
            else if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonB))
            {
                Selected = true;
                ClassIndex = 1;
            }
        }

        Character.P = players[ClassIndex];

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawText("Choose a class", 280, 100, 40, Color.WHITE);

        Raylib.DrawTexture(images[0], (int)buttonA.x, (int)buttonA.y, Color.WHITE);
        Raylib.DrawTexture(images[1], (int)buttonB.x, (int)buttonB.y, Color.WHITE);

        Raylib.EndDrawing();
    }
    public void Update()
    {
        players[ClassIndex].Update();
        players[ClassIndex].MapCollision();
    }
    public void Draw()
    {
        players[ClassIndex].Draw();
    }
}
