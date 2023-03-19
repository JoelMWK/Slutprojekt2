public class Demon : Enemy
{
    public Demon()
    {
        rect = new Rectangle(0, 0, 64, 83);
        Hp = 8;
        a.source.width = 64;
        a.source.height = 83;
        speed.X = 1f;
    }

    public override void Update()
    {
        if (a.moving) a.Name = "D_Walk";
        else a.Name = "D_Idle";

        base.Update();
    }
}
