using Raylib_cs;

class Program
{
    static void Main()
    {
        // Pencere boyutları ve başlığı
        const int screenWidth = 800;
        const int screenHeight = 450;

        Raylib.InitWindow(screenWidth, screenHeight, "PlatX - 2D Platformer");
        Raylib.SetTargetFPS(60);

        // Oyun döngüsü (Pencere kapanana kadar çalışır)
        while (!Raylib.WindowShouldClose())
        {
            // --- 1. GÜNCELLEME (UPDATE) ---
            // Karakter hareketleri, fizik ve çarpışmalar buraya gelecek.

            // --- 2. ÇİZİM (DRAW) ---
            Raylib.BeginDrawing();
            
            // Arka planı açık gri yapalım
            Raylib.ClearBackground(Color.RayWhite);

            // Geçici bilgilendirme yazısı
            Raylib.DrawText("PlatX Hazırlanıyor...", 300, 200, 20, Color.DarkGray);

            Raylib.EndDrawing();
        }

        // Kaynakları temizle ve kapat
        Raylib.CloseWindow();
    }
}
