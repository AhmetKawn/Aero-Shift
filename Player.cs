using System.Numerics;
using Raylib_cs;

public class Player
{
    public Vector2 Position;
    public Vector2 Velocity;
    public float Size = 30f;
    public float Speed = 250f;
    public float JumpForce = -450f;
    public float Gravity = 1000f;
    public bool IsGrounded;

    public Player(Vector2 startPos)
    {
        Position = startPos;
        Velocity = Vector2.Zero;
    }

    public void Update(float deltaTime, List<Rectangle> platforms)
    {
        // Yatay Girdi Kontrolleri (A/D veya Sol/Sağ Ok tuşları)
        if (Raylib.IsKeyDown(KeyboardKey.KeyboardD) || Raylib.IsKeyDown(KeyboardKey.KeyboardKeyRight))
        {
            Velocity.X = Speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KeyboardA) || Raylib.IsKeyDown(KeyboardKey.KeyboardLeft))
        {
            Velocity.X = -Speed;
        }
        else
        {
            Velocity.X = 0;
        }

        // Yerçekimi Uygulama
        Velocity.Y += Gravity * deltaTime;

        // Zıplama Kontrolü
        if (IsGrounded && (Raylib.IsKeyPressed(KeyboardKey.KeyboardSpace) || Raylib.IsKeyPressed(KeyboardKey.KeyboardUp)))
        {
            Velocity.Y = JumpForce;
            IsGrounded = false;
        }

        // Yatay Hareket ve Çarpışma Kontrolü
        Position.X += Velocity.X * deltaTime;
        Rectangle playerRect = new Rectangle(Position.X, Position.Y, Size, Size);
        
        foreach (var p in platforms)
        {
            if (CheckCollision(playerRect, p))
            {
                if (Velocity.X > 0) Position.X = p.X - Size;
                else if (Velocity.X < 0) Position.X = p.X + p.Width;
            }
        }

        // Dikey Hareket ve Çarpışma Kontrolü
        Position.Y += Velocity.Y * deltaTime;
        playerRect = new Rectangle(Position.X, Position.Y, Size, Size);
        
        IsGrounded = false;
        foreach (var p in platforms)
        {
            if (CheckCollision(playerRect, p))
            {
                if (Velocity.Y > 0) // Düşerken zemine çarpma
                {
                    Position.Y = p.Y - Size;
                    Velocity.Y = 0;
                    IsGrounded = true;
                }
                else if (Velocity.Y < 0) // Zıplarken tavana çarpma
                {
                    Position.Y = p.Y + p.Height;
                    Velocity.Y = 0;
                }
            }
        }
    }

    private bool CheckCollision(Rectangle r1, Rectangle r2)
    {
        return r1.X < r2.X + r2.Width &&
               r1.X + r1.Width > r2.X &&
               r1.Y < r2.Y + r2.Height &&
               r1.Y + r1.Height > r2.Y;
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Size, (int)Size, Color.Red);
    }
}
