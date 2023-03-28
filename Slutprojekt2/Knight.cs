public class Knight : Player
{
    private Sword sword = new Sword();
    public Knight()
    {
        rect = new Rectangle(400, 200, 45, 66);
        a.source.width = 45;
        a.source.height = 66;
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
