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
                target = new Vector2(Character.p.rect.x, screenHeight / 2),
                rotation = 0.0f,
                zoom = 1.0f
            };
        }
        set { }
    }

    public Vector2 WorldToScreen(Vector2 position)
    {
        return Raylib.GetWorldToScreen2D(position, Camera2D);
    }
    public Vector2 ScreenToWorld(Vector2 position)
    {
        return Raylib.GetScreenToWorld2D(position, Camera2D);
    }
}
