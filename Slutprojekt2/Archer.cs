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
        if (a.moving && !inAir) a.Name = "runA";
        else if (inAir) a.Name = "jumpA";
        else a.Name = "idleA";
    }
    public override void Draw()
    {
        bow.Draw(this);
        base.Draw();
    }
}
