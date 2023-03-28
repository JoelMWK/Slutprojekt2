public class Player : Character
{
    public Camera Cam { get; set; } = new Camera();
    public int Points { get; set; }
    public int Direction { get; set; }
    private Timer timer = new Timer();
    private TimeSpan duration;
    private float timeSurvived;

    private Rectangle HealthBar
    {
        get
        {
            return HealthBar = new Rectangle((int)Cam.ScreenToWorldHud.X + 5, (int)Cam.ScreenToWorldHud.Y + 5, 20 * Hp, 20);
        }
        set { }
    }
    public Player()
    {
        rect = new Rectangle(400, 0, 45, 81);
        Hp = 10;
        a.currentTexture = Animation.spriteSheetP;
    }
    public override void Draw()
    {
        Hud();
        Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
        base.Draw();
    }
    public override void Update()
    {
        base.Update();
        Movement();
        TakeDamage();
        Heal();
        Coin.Coins.RemoveAll(c => c.IsPickedUp);
    }

    private void Hud()
    {
        timeSurvived += Raylib.GetFrameTime();
        duration = new(0, 0, (int)timeSurvived);

        Raylib.DrawText("Time Survived: " + duration, (int)Cam.ScreenToWorldHud.X + 500, (int)Cam.ScreenToWorldHud.Y, 30, Color.WHITE);
        Raylib.DrawText("Coins: " + Points, (int)Cam.ScreenToWorldHud.X, (int)Cam.ScreenToWorldHud.Y + 40, 30, Color.WHITE);
        Raylib.DrawRectangle((int)Cam.ScreenToWorldHud.X, (int)Cam.ScreenToWorldHud.Y, 210, 30, Color.BLACK);
        Raylib.DrawRectangleRec(HealthBar, Color.RED);
    }

    private void TakeDamage()
    {
        timer.Update();
        foreach (Enemy enemy in EnemySpawner.Enemies)
        {
            if (enemy.CheckCollisionRecs(rect) && timer.CheckTimer(1))
            {
                timer.ResetTimer();
                GetHit(enemy.Damage);
            }
        }
    }
    private void Heal()
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
    private void Movement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) { rect.x -= speed.X; a.direction.X = -1; Direction = 1; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) { rect.x += speed.X; a.direction.X = 1; Direction = 2; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) { rect.y -= speed.Y; Direction = 3; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) { rect.y += speed.Y; Direction = 4; a.moving = true; }

        if (Raylib.IsKeyReleased(KeyboardKey.KEY_D) || Raylib.IsKeyReleased(KeyboardKey.KEY_A) || Raylib.IsKeyReleased(KeyboardKey.KEY_W) || Raylib.IsKeyReleased(KeyboardKey.KEY_S)) a.moving = false;
    }
}
