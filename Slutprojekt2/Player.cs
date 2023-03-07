public class Player : Character
{
    Rectangle gRect;
    Vector2 pos;

    public Player()
    {
        gRect = new Rectangle(0, 0, 48, 11);
    }
    public override void Draw()
    {
        base.Draw();
        Raylib.DrawTexture(gun, (int)gRect.x, (int)gRect.y, Color.WHITE);
    }
    public void UpdateGun()
    {
        gRect = new Rectangle(rect.x + 25, rect.y + 45, 48, 11);
        pos = Raylib.GetMousePosition();
        float angle = MathF.Atan2(pos.X, pos.Y);

        Raylib.DrawLine((int)rect.x, (int)rect.y, (int)pos.X, (int)pos.Y, Color.BLACK);
    }
}
