using System.Collections.Generic;
using Raylib_cs;

public class Level
{
    public List<Rectangle> Platforms = new List<Rectangle>();

    public Level()
    {
        // Zemin ve platformlar (X, Y, Genişlik, Yükseklik)
        Platforms.Add(new Rectangle(0, 400, 800, 50));   // Ana zemin
        Platforms.Add(new Rectangle(150, 300, 180, 20)); // 1. Platform
        Platforms.Add(new Rectangle(400, 220, 180, 20)); // 2. Platform
        Platforms.Add(new Rectangle(200, 130, 150, 20)); // 3. Platform
    }

    public void Draw()
    {
        foreach (var p in Platforms)
        {
            Raylib.DrawRectangle((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height, Color.DarkGray);
        }
    }
}
