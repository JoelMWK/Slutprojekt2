public class Player : Character
{
    public Camera camera = new Camera();
    public int direction;
    public Player()
    {
        rect = new Rectangle(400, 0, 45, 81);
        Hp = 10;
        a.currentTexture = Animation.spriteSheetP;
    }
    public override void Draw()
    {
        Raylib.DrawRectangleLines((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.YELLOW);
        base.Draw();
    }
    public override void Update()
    {
        base.Update();
        Movement();
    }

    public void Movement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) { rect.x -= speed.X; a.direction.X = -1; direction = 1; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) { rect.x += speed.X; a.direction.X = 1; direction = 2; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) { rect.y -= speed.Y; direction = 3; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) { rect.y += speed.Y; direction = 4; a.moving = true; }

        if (Raylib.IsKeyReleased(KeyboardKey.KEY_D) || Raylib.IsKeyReleased(KeyboardKey.KEY_A) || Raylib.IsKeyReleased(KeyboardKey.KEY_W) || Raylib.IsKeyReleased(KeyboardKey.KEY_S)) a.moving = false;
    }
}
