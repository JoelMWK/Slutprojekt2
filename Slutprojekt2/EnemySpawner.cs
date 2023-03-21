public class EnemySpawner
{
    public static List<Enemy> Enemies { get; set; } = new List<Enemy>();
    private Random random = new Random();

    public EnemySpawner()
    {
        Enemies.Add(new Demon());
    }

    public void Update()
    {
        foreach (Enemy e in Enemies)
        {
            Character.e = e;
            e.Update();
            e.MapCollision();
            if (!e.IsAlive && random.Next(1, 5) == 4)
            {
                Coin.Coins.Add(new Coin((int)e.rect.x, (int)e.rect.y));
            }
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON)) Enemies.Add(new Wogol());
        Enemies.RemoveAll(e => !e.IsAlive);
    }
    public void Draw()
    {
        foreach (Enemy e in Enemies)
        {
            e.Draw();
        }
        foreach (Coin c in Coin.Coins)
        {
            c.Update();
            c.Draw();
        }
    }
}
