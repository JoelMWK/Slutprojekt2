public class Bow : Weapon
{
    private int speed = 12;
    public Vector2 position;
    private int dir;
    public int arrowCount = 1;

    public Bow()
    {
        sprite = Raylib.LoadTexture("./images/character/bow.png");
        Damage = 1;
        isActive = false;
    }
    public void Update()
    {
      
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)position.X, (int)position.Y, 6, Color.YELLOW);
    }
}
