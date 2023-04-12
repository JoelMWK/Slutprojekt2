public class Demon : Enemy
{
    public Demon() //Konstructor för Demon som specificerar, hur stor, hp, damage, Coin dropchance och hur snabb
    {
        rect = new Rectangle(Rx, Ry, 64, 83);
        Hp = 8;
        Damage = 3;
        DropChance = 1;
        a.source.width = 64;
        a.source.height = 83;
        speed = new Vector2(2, 2);
    }

    public override void Update() //Updaterar enemy
    {//Bestämer vilken animation som ska användas.
        if (a.Moving) a.Name = "D_Walk";
        else a.Name = "D_Idle";

        base.Update();
    }
}
