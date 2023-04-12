public class ClassSelector
{
    public static List<Player> players = new List<Player>() //Lista av de två olika player klasserna
    {
        new Archer(),
        new Knight(),
    };

    public bool Selected { get; set; } //Bool om man har valt en klass eller inte
    public int ClassIndex { get; set; } //Index för klassen
    private static Texture2D[] images = { //BIlder
        Raylib.LoadTexture("./images/character/archer.png"),
        Raylib.LoadTexture("./images/character/knight.png"),
    };

    private Rectangle buttonA = new Rectangle(250, 250, 150, 225);
    private Rectangle buttonB = new Rectangle(500, 250, 150, 225);

    public void ChoosePlayer() //Kollar vilken klass man väljer med muspekaren och ett klick
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

        Character.P = players[ClassIndex]; //Bestämmer vilken av klasserna som ska vara player.

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);

        Raylib.DrawText("Choose a class", 280, 100, 40, Color.WHITE);

        Raylib.DrawTexture(images[0], (int)buttonA.x, (int)buttonA.y, Color.WHITE);
        Raylib.DrawTexture(images[1], (int)buttonB.x, (int)buttonB.y, Color.WHITE);

        Raylib.EndDrawing();
    }
    public void Update() //Updaterar klassen som blev vald beroende på classindex.
    {
        players[ClassIndex].Update();
        players[ClassIndex].MapCollision();
    }
    public void Draw() // Ritar ut player
    {
        players[ClassIndex].Draw();
    }
}
