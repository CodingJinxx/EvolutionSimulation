global using Raylib_cs;
using DesktopUI;


GameContext context = new GameContext();
context.Init(1200, 600);
while (!Raylib.WindowShouldClose())
{
    context.Update();
    context.Render();
}