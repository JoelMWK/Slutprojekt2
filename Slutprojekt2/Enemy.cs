public class Enemy : Character
{
    public Enemy()
    {
        rect = new Rectangle(0, 0, 70, 35);
        a.currentTexture = AnimationHandler.spriteSheetE;
    }
    public override void Update()
    {
        base.Update();
        Console.WriteLine("e: " + a.Name);
        if (a.moving) a.Name = "walk";
        else if (!isAlive) a.Name = "deathE";
        else a.Name = "idle";

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) { rect.x -= speed.X; a.direction.X = 1; a.moving = true; }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) { rect.x += speed.X; a.direction.X = -1; a.moving = true; }
        if (Raylib.IsKeyReleased(KeyboardKey.KEY_RIGHT) || Raylib.IsKeyReleased(KeyboardKey.KEY_LEFT)) a.moving = false;
    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.RED);
        base.Draw();
    }
}
