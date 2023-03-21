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
        if (a.moving) a.Name = "K_Run";
        else a.Name = "K_Idle";
    }

    public override void Draw()
    {
        sword.Draw(this);
        base.Draw();
    }
}
