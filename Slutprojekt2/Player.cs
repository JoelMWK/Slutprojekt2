public class Player : Character
{
    Rectangle gRect = new Rectangle(0, 0, 48, 11);
    Vector2 pos;
    float angle;

    public Player()
    {
        p = this;
    }
    public override void Draw()
    {
        Raylib.DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, Color.GREEN);
        base.Draw();
        //Raylib.DrawTextureEx(gun, new Vector2(gRect.x, gRect.y), angle, 1, Color.WHITE);
        //Raylib.DrawLine((int)rect.x + 30, (int)rect.y + 45, (int)pos.X, (int)pos.Y, Color.BLACK);
    }
    public void UpdateGun()
    {
        pos = Raylib.GetMousePosition();
        gRect = new Rectangle(rect.x + 30, rect.y + 45, 48, 11);
        angle = MathF.Atan2(pos.Y - gRect.y, pos.X - gRect.x) * 180 / MathF.PI;
    }
}
