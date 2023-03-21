public class Player : Character
{
    public Camera camera = new Camera();
    public int direction;
    private Rectangle HealthBar
    {
        get
        {
            return HealthBar = new Rectangle((int)camera.ScreenToWorldHud.X + 5, (int)camera.ScreenToWorldHud.Y + 5, 20 * Hp, 20);
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
    }

    private void Hud()
    {
        Raylib.DrawRectangle((int)camera.ScreenToWorldHud.X, (int)camera.ScreenToWorldHud.Y, 210, 30, Color.BLACK);
        Raylib.DrawRectangleRec(HealthBar, Color.RED);
    }

    private void Movement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) { rect.x -= speed.X; a.direction.X = -1; direction = 1; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) { rect.x += speed.X; a.direction.X = 1; direction = 2; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) { rect.y -= speed.Y; direction = 3; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) { rect.y += speed.Y; direction = 4; a.moving = true; }

        if (Raylib.IsKeyReleased(KeyboardKey.KEY_D) || Raylib.IsKeyReleased(KeyboardKey.KEY_A) || Raylib.IsKeyReleased(KeyboardKey.KEY_W) || Raylib.IsKeyReleased(KeyboardKey.KEY_S)) a.moving = false;
    }
}
