public class Demon : Enemy
{
    public Demon()
    {
        rect = new Rectangle(100, 100, 64, 83);
        Hp = 8;
        a.source.width = 64;
        a.source.height = 83;
        speed.X = 2;
    }

    public override void Update()
    {
        if (a.moving) a.Name = "D_Walk";
        else a.Name = "D_Idle";

        base.Update();
    }
}
