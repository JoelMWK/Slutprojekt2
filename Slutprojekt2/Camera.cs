public class Camera
{
    private int screenWidth = Raylib.GetScreenWidth();
    private int screenHeight = Raylib.GetScreenHeight();
    public Camera2D Camera2D; //Skapar en intans av en Camera2D
    public Camera() //Konstructor för Camera. Skapar en camera2D med specefika values.
    {
        Camera2D = new Camera2D()
        {
            offset = new Vector2(screenWidth / 2, screenHeight / 2),
            target = new Vector2(),
            rotation = 0.0f,
            zoom = 1.0f
        };
    }
    public Vector2 WorldToScreen //Får världs positionen och omvandlar den till kamerans skärm position
    {
        get
        {
            return Raylib.GetWorldToScreen2D(new Vector2(Character.P.rect.x, Character.P.rect.y), Camera2D);
        }
    }
    public Vector2 ScreenToWorld //Får positionen av kameran och ovandlar det till världs position
    {
        get
        {
            return Raylib.GetScreenToWorld2D(new Vector2(Character.P.rect.x, Character.P.rect.y), Camera2D);
        }
    }
    public Vector2 ScreenToWorldHud //Får positionen av kameran och ovandlar det till världs position
    {
        get
        {
            return Raylib.GetScreenToWorld2D(new Vector2(10, 10), Camera2D);
        }
    }

    public void Update() //Updaterar positionen av kamerans target.
    {
        Camera2D.target = new Vector2(Character.P.rect.x, Character.P.rect.y);
    }
}
