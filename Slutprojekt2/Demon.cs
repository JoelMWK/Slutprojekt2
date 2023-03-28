public class Demon : Enemy
{
    public Demon()
    {
        rect = new Rectangle(Rx, Ry, 64, 83);
        Hp = 8;
        Damage = 3;
        DropChance = 1;
        a.source.width = 64;
        a.source.height = 83;
        speed = new Vector2(2, 2);
    }

    public override void Update()
    {
        if (a.moving) a.Name = "D_Walk";
        else a.Name = "D_Idle";

        base.Update();
    }
}
