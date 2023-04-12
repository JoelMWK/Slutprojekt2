public class Knight : Player
{
    private Sword sword = new Sword(); //Instans av sword som knight använder sig av
    public Knight() //Konstruktor som definerar hur stor knight är
    {
        rect = new Rectangle(400, 200, 45, 66);
        a.source.width = 45;
        a.source.height = 66;
    }

    public override void Update() //Updaterar svärdet,base och animationerna.
    {
        sword.Update(this);
        base.Update();
        if (a.Moving) a.Name = "K_Run";
        else a.Name = "K_Idle";
    }

    public override void Draw() //Ritar svärdet, och karaktären
    {
        sword.Draw(this);
        base.Draw();
    }
}
