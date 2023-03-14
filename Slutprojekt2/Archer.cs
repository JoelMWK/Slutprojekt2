public class Archer : Player
{
    Bow bow = new Bow();
    public Archer()
    {
        a.source.width = 45;
        a.source.height = 81;
    }

    public override void Update()
    {
        bow.Update(this);
        base.Update();
        if (a.moving && !inAir) a.Name = "A_Run";
        else if (inAir) a.Name = "A_Jump";
        else a.Name = "A_Idle";
    }
    public override void Draw()
    {
        bow.Draw(this);
        base.Draw();
    }
}
