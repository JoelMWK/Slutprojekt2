public class Wogol : Enemy
{
    public Wogol()
    {
        rect = new Rectangle(0, 0, 32, 32);
        Hp = 4;
        a.source.width = 32;
        a.source.height = 32;
        MarginY = 167;
        speed.X = 2.5f;
    }

    public override void Update()
    {
        if (a.moving) a.Name = "W_Walk";
        else a.Name = "W_Idle";

        base.Update();
    }
}
