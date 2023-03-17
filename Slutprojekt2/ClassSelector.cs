public class ClassSelector
{
    public Dictionary<string, Player> playerClass = new()
    {
        {"Archer", new Archer()},
        {"Knight", new Knight()},
    };

    public bool selected;
    private string className;

    private Rectangle ButtonA = new Rectangle(180, 300, 200, 150);
    private Rectangle ButtonB = new Rectangle(580, 300, 200, 150);

    public void ChoosePlayer()
    {
        Raylib.DrawText("Choose a player", 280, 100, 40, Color.WHITE);

        Raylib.DrawRectangleRec(ButtonA, Color.WHITE);
        Raylib.DrawRectangleRec(ButtonB, Color.WHITE);
        Raylib.DrawText("Archer", 220, 350, 30, Color.BLACK);
        Raylib.DrawText("Knight", 610, 350, 30, Color.BLACK);


        if (Raylib.IsMouseButtonPressed(0))
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), ButtonA))
            {
                selected = true;
                className = "Archer";
            }
            else if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), ButtonB))
            {
                selected = true;
                className = "Knight";
            }
        }
    }
    public void Update()
    {
        playerClass[className].Update();
        playerClass[className].MapCollision();
    }

    public void Draw()
    {
        playerClass[className].Draw();
    }
}
