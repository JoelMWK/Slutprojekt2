public class Camera
{
    private int screenWidth = Raylib.GetScreenWidth();
    private int screenHeight = Raylib.GetScreenHeight();
    public Camera2D Camera2D
    {
        get
        {
            return Camera2D = new Camera2D()
            {
                offset = new Vector2(screenWidth / 2, screenHeight / 2),
                target = new Vector2(Character.p.rect.x, Character.p.rect.y),
                rotation = 0.0f,
                zoom = 1.0f
            };
        }
        private set { }
    }

    public Vector2 WorldToScreen
    {
        get
        {
            return Raylib.GetWorldToScreen2D(new Vector2(Character.p.rect.x, Character.p.rect.y), Camera2D);
        }
    }
    public Vector2 ScreenToWorld
    {
        get
        {
            return Raylib.GetScreenToWorld2D(new Vector2(Character.p.rect.x, Character.p.rect.y), Camera2D);
        }
    }
    public Vector2 ScreenToWorldHud
    {
        get
        {
            return Raylib.GetScreenToWorld2D(new Vector2(10, 10), Camera2D);
        }
    }
}
