public class Bow : Weapon
{
    private List<Projectile> projectiles = new List<Projectile>();
    private Vector2 speed = new Vector2(8, 8); //Speed för arrow projectile
    private int arrowCount = 10;
    private Rectangle source = new Rectangle(0, 0, 14, 50); //Bow rectangle source
    private Vector2 pos; //Vector2 som ska spara muspositionen av spelaren.
    private float angle;

    public Bow() //Konstructor för bow
    {
        sprite = Raylib.LoadTexture("./images/character/Items/bow.png");
        Damage = 1;
    }
    public void Update(Player p) //Tar hand om updateringen av projectile och bow
    {
        timer2.Update();
        pos = MousePosition(); //Får musposition
        angle = MathF.Atan2(pos.Y - p.rect.y, pos.X - p.rect.x) * 180 / MathF.PI; //Beräknar vinkeln mellan spelaren och muspositionen. För bow

        if (Raylib.IsMouseButtonPressed(0) && timer2.CheckTimer(0.8f))
        {
            Shoot(p);
            timer2.ResetTimer();
        }

        foreach (Projectile projectile in projectiles) //För varje projectile
        {
            projectile.Update(speed); //Updaterar projectile och lägger till speed
            timer.Update();
            foreach (Enemy e in EnemySpawner.Enemies) //För varje enemy
            {
                if (projectile.CheckCollisionPointRec(e.rect) && timer.CheckTimer(0.5f)) //Kollar kollisionen mellan projectile och enemy
                {
                    e.GetHit(Damage);
                    IsActive = false;
                    timer.ResetTimer();
                }
            }
        }
        projectiles.RemoveAll(projectile => !projectile.IsActive); //Tar bort alla projectiles som är inte aktiva
    }

    public void Shoot(Player p) //Shoot metod
    {
        Projectile projectile = new(p, pos); //skapar en ny projectile

        if (projectiles.Count() < arrowCount) //Lägger till projectile i listan om den inte går över en specifik mängd (arrowCount)
        {
            projectiles.Add(projectile);
            projectile.IsActive = true;
        }
    }

    private Vector2 MousePosition() //Returnerar muspositionen.
    {
        return Raylib.GetScreenToWorld2D(Raylib.GetMousePosition(), Character.P.Cam.Camera2D);
    }

    public void Draw(Player p) //Ritar ut alla projectiles och bow.
    {
        foreach (Projectile projectile in projectiles)
        {
            projectile.Draw();
        }
        Raylib.DrawTexturePro(sprite, source, new Rectangle(p.rect.x + 20, p.rect.y + p.rect.height / 2, source.width, source.height), new Vector2(-40, 25), angle, Color.WHITE);
    }
}
