public class Weapon
{
    protected Texture2D sprite; //Sprite som används för alla vapen klasser
    protected Timer timer = new Timer(); //Instans av timer 
    protected Timer timer2 = new Timer(); //Instans av timer
    public bool IsActive { get; set; } //Om vapnet är aktivt eller inte
    public int Damage { get; set; } //Hur myckcet damage vapnet ska göra
}
