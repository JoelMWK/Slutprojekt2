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
        SpawnEnemy();
        foreach (Enemy e in Enemies)
        {
            Character.E = e;
            e.Update();
            e.MapCollision();
            if (!e.IsAlive && random.Next(1, e.DropChance + 1) == e.DropChance)
            {
                Coin.Coins.Add(new Coin((int)e.rect.x, (int)e.rect.y));
            }
        }
        Enemies.RemoveAll(e => !e.IsAlive);
    }

    private void SpawnEnemy()
    {
        if (random.Next(1, 100) == 5 && Vector2.Distance(new Vector2(Character.E.rect.x, Character.E.rect.y), new Vector2(Character.P.rect.x, Character.P.rect.y)) >= 100)
        {
            if (random.Next(1, 100) > 80)
            {
                Enemies.Add(new Demon());
            }
            else
            {
                Enemies.Add(new Wogol());
            }
        }
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
