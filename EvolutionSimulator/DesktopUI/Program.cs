global using Raylib_cs;

Raylib.InitWindow(800, 800, "Hello World");

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();