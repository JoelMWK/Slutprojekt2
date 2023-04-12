public class Wogol : Enemy
{
    public Wogol() //Konstructor för Wogol som specificerar, hur stor, hp, damage, Coin dropchance och hur snabb
    {
        rect = new Rectangle(Rx, Ry, 32, 32);
        Hp = 1;
        Damage = 0.5f;
        DropChance = 4;
        a.source.width = 32;
        a.source.height = 32;
        MarginY = 167; //Spritsheet y posiition (top vänstra hörn). 
        speed = new Vector2(2.5f, 2.5f);
    }

    public override void Update() //Updaterar wogul base updadte och animationerna.
    {
        if (a.Moving) a.Name = "W_Walk";
        else a.Name = "W_Idle";

        base.Update();
    }
}
