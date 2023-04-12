public class Player : Character
{
    public Camera Cam { get; set; } = new Camera(); //2D kamera för spelaren
    public int Points { get; set; } //Poäng (coins)
    public int Direction { get; set; }
    private Timer timer = new Timer();
    private TimeSpan duration; //Skapar en TimeSpan för att den ska formatera tiden till sec, min, hour
    private float timeSurvived; 

    private Rectangle HealthBar //Rectangle hp för player.
    {
        get
        {
            return HealthBar = new Rectangle((int)Cam.ScreenToWorldHud.X + 5, (int)Cam.ScreenToWorldHud.Y + 5, 20 * Hp, 20);
        }
        set { }
    }
    public Player() //Konstructor för player
    {
        rect = new Rectangle(400, 0, 45, 81);
        Hp = 10;
        a.currentTexture = Animation.spriteSheetP; //Bestämmer vilken spritesheet som player ska använda
    }
    public override void Draw() //Ritar Hud och base.draw (Draw metoden från Character)
    {
        Hud();
        base.Draw();
    }
    public override void Update() //Updater allt för player
    {
        Cam.Update(); //Positionen av kameran
        base.Update();
        Movement();
        TakeDamage();
        Heal();
        Coin.Coins.RemoveAll(c => c.IsPickedUp); //Tar bort coins om player har tagit upp den
    }

    private void Hud() //Hud för spelet
    {
        timeSurvived += Raylib.GetFrameTime();
        duration = new(0, 0, (int)timeSurvived); //Formaterar tiden

        //Skriver ut coins, tid och visar healthbar
        Raylib.DrawText("Time Survived: " + duration, (int)Cam.ScreenToWorldHud.X + 500, (int)Cam.ScreenToWorldHud.Y, 30, Color.WHITE);
        Raylib.DrawText("Coins: " + Points, (int)Cam.ScreenToWorldHud.X, (int)Cam.ScreenToWorldHud.Y + 40, 30, Color.WHITE);
        Raylib.DrawRectangle((int)Cam.ScreenToWorldHud.X, (int)Cam.ScreenToWorldHud.Y, 210, 30, Color.BLACK);
        Raylib.DrawRectangleRec(HealthBar, Color.RED);
    }

    private void TakeDamage()
    {
        timer.Update();
        foreach (Enemy enemy in EnemySpawner.Enemies) //för varje enemy
        {
            if (enemy.CheckCollisionRecs(rect) && timer.CheckTimer(1)) //Kollar kollision mellan spelaren och en enemy
            {
                timer.ResetTimer();
                GetHit(enemy.Damage); //Tar damage. Damage ändras beroende på viket enemy det är
            }
        }
    }
    private void Heal() //Heal player. Player får 2 hp men måste ge bort 10 coins/points
    {
        if (Points >= 10)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_H) && Hp < 10)
            {
                Points -= 10;
                Hp += 2;
            }
        }
    }
    private void Movement() //Movement för player
    {
        //Bestämmer vilket håll spelare ska gå och ändra varablar beroende på hållet
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) { rect.x -= speed.X; a.direction.X = -1; Direction = 1; a.Moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) { rect.x += speed.X; a.direction.X = 1; Direction = 2; a.Moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) { rect.y -= speed.Y; Direction = 3; a.Moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) { rect.y += speed.Y; Direction = 4; a.Moving = true; }

        if (Raylib.IsKeyReleased(KeyboardKey.KEY_D) || Raylib.IsKeyReleased(KeyboardKey.KEY_A) || Raylib.IsKeyReleased(KeyboardKey.KEY_W) || Raylib.IsKeyReleased(KeyboardKey.KEY_S)) a.Moving = false;
    }
}
