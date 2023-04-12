public class Animator
{
    public Animation animations = new Animation();
    public Texture2D currentTexture; //Variabel för spritheet så att man kan ändra i player och enemy
    public Rectangle source; //Rectangle för spritesheet (hur stor del som ska visas eller inte)
    public Vector2 direction = new Vector2(1, 0); //Vector2 för att se vilket håll man går
    public string Name { get; set; } = "A_Idle"; //Namn för animationen
    public float Time { get; set; } //Tid
    public bool Moving { get; set; } = false; //Bool om man rör sig eller inte
    private Vector2 currentFrame; //Vilken frame animationen är på. T.ex 0,1,2,3...
    private int totalFrames; //Int för hur många frames den specifika animationen har

    public void Anim(int row, int column, float frameSpeed, int marginY) //Void för animationerna. Tar in olika varablar så det kan användas för flera objekt.
    {
        totalFrames = row; //Totalet av frames är row som defineras när man spelar upp anim i t.ex. player.

        Time += Raylib.GetFrameTime(); 
        if (Time >= frameSpeed) //Spelas upp om tiden är >= animations hastigheten på animationen
        {
            Time = 0.0f;
            currentFrame.X++; //Byter till nästa frame
        }

        if (currentFrame.X > totalFrames) currentFrame.X = 0; //För att loopa animationen om currentframe är större än totalet
        for (int i = 0; i < animations.ani.Count; i++) currentFrame.Y = column; //Vilken column framen är på spritesheetet

        source.x = currentFrame.X * source.width; //Definerar hur stor x-led ska vara.
        source.y = marginY + currentFrame.Y * source.height; //Definerar hur stor y-led ska vara.
    }
    public void Draw(Character c) //Ritar ut texturen med definerade variablar.
    {
        Raylib.DrawTexturePro(currentTexture, new Rectangle(source.x, source.y, source.width * direction.X, source.height), c.rect, Vector2.Zero, 0, Color.WHITE);
    }
}
