public class EnemySpawner
{
    public static List<Enemy> enemies = new List<Enemy>();
    Random random = new Random();

    public EnemySpawner()
    {
        enemies.Add(new Demon());
        Character.e = enemies[0];
    }

    public void Update()
    {
        foreach (Enemy e in enemies)
        {
            e.Update();
            e.MapCollision();
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_RIGHT_BUTTON)) enemies.Add(new Wogol());

        enemies.RemoveAll(e => !e.IsAlive);
    }
    public void Draw()
    {
        foreach (Enemy e in enemies)
        {
            e.Draw();
        }
    }
}
