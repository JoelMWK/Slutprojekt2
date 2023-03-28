public class Wogol : Enemy
{
    public Wogol()
    {
        rect = new Rectangle(Rx, Ry, 32, 32);
        Hp = 1;
        Damage = 0.5f;
        DropChance = 4;
        a.source.width = 32;
        a.source.height = 32;
        MarginY = 167;
        speed = new Vector2(2.5f, 2.5f);
    }

    public override void Update()
    {
        if (a.moving) a.Name = "W_Walk";
        else a.Name = "W_Idle";

        base.Update();
    }
}
