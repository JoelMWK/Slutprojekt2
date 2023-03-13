public class Weapon
{
    protected static Texture2D sprite;
    protected Rectangle rect;
    protected float rot;
    protected float scale = 1;
    public bool IsActive { get; set; }
    public int Damage { get; set; }
}
