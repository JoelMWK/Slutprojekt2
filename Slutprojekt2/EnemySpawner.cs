public class EnemySpawner
{
    public static List<Enemy> Enemies { get; set; } = new List<Enemy>(); //Lista för enemies
    private Timer timer = new Timer();
    private Random random = new Random(); //Random nummer

    private int roundNum = 1; //Vilken runda spelaren är på
    private int enemyCount = 2; //Hur många enmies det totalt ska finnas
    private int enemiesRemaining; // Hur många enmies är kvar
    private bool roundActive = false; //Om rundan är igång eller inte
    private float roundDelay = 10f; //Tid mellan runderna

    public void Update()
    {
        if (!roundActive) //Om rundan inte aktiv starta timer
        {
            timer.Update();
            if (timer.CheckTimer(roundDelay))
            {
                StartRound();
                timer.ResetTimer();
            }
        }
        else
        {
            if (Enemies.Count <= 0) //Om rundan är aktiv och alla det inte finns något objekt i listan Enmies utfört detta
            {
                enemiesRemaining = 0; //Återställer enmiesremaning till 0
                roundActive = false;
                roundNum++; //Ökar rundan för svårare 
            }

            foreach (Enemy e in Enemies) //För varje enemy.
            {
                Character.E = e;
                e.Update();
                e.MapCollision();
                if (!e.IsAlive && random.Next(1, e.DropChance + 1) == e.DropChance) //om man har dödat en enemy finns det en chans att droppa en coin
                {
                    Coin.Coins.Add(new Coin((int)e.rect.x, (int)e.rect.y));
                }
            }
            Enemies.RemoveAll(e => !e.IsAlive); //Tar bort alla enmies om det är inte vid liv
        }
    }
    public void Draw() //Ritar ut coins, enmies och Visar text som indikerar hur lång tid du har kvar innan nästa runda startar
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
        if (!roundActive)
            Raylib.DrawText($"Round {roundNum} starts in {(int)(roundDelay - timer.Time)}", (int)Character.P.Cam.ScreenToWorldHud.X, (int)Character.P.Cam.ScreenToWorldHud.Y + 100, 30, Color.WHITE);
    }

    private void SpawnEnemy() //Spawnar enmies. Slumpar med hur stor chans att en svårare enemy spawnar.
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
    private void StartRound() //Startar en ny runda
    {
        roundActive = true;
        enemyCount += 2; //Ökar med totalet av enmies 
        enemiesRemaining = enemyCount; 

        for (int i = 0; i < enemiesRemaining; i++) //Spawnar enemy x gånger beroende på enmiesRemaning
        {
            SpawnEnemy();
        }
    }

}
