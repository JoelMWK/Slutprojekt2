public class Knight : Player
{
    Sword sword = new Sword();
    public Knight()
    {
        a.source.width = 45;
        a.source.height = 81;
    }

    public override void Update()
    {
        sword.Update(this);
        base.Update();
        if (a.moving && !inAir) a.Name = "runK";
        else if (inAir) a.Name = "jumpK";
        else a.Name = "idleK";
    }

    public override void Draw()
    {
        sword.Draw();
        base.Draw();
    }
}
