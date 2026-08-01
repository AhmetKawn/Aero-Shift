using Raylib_cs;
using System.Numerics;

class Program
{
    static void Main()
    {
        const int screenWidth = 800;
        const int screenHeight = 450;

        Raylib.InitWindow(screenWidth, screenHeight, "PlatX - Modüler 2D Platformer");
        Raylib.SetTargetFPS(60);

        // Nesneleri Oluşturma
        Level level = new Level();
        Player player = new Player(new Vector2(100, 100));

        while (!Raylib.WindowShouldClose())
        {
            float deltaTime = Raylib.GetFrameTime();

            // --- 1. GÜNCELLEME (UPDATE) ---
            player.Update(deltaTime, level.Platforms);

            // --- 2. ÇİZİM (DRAW) ---
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Bileşenleri Çizdirme
            level.Draw();
            player.Draw();

            // Arayüz Metinleri
            Raylib.DrawText("PlatX Projesi", 20, 20, 20, Color.DarkBlue);
            Raylib.DrawText("Hareket: A / D veya Sol / Sağ Ok | Zıplama: Boşluk", 20, 50, 14, Color.Gray);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
