public class Archer : Player
{
    private Bow bow = new Bow();
    public Archer()
    {
        rect = new Rectangle(400, 200, 45, 63);
        a.source.width = 45;
        a.source.height = 63;
        MarginY = 3;
    }

    public override void Update()
    {
        bow.Update(this);
        base.Update();
        if (a.moving) a.Name = "A_Run";
        else a.Name = "A_Idle";
    }
    public override void Draw()
    {
        bow.Draw(this);
        base.Draw();
    }
}
