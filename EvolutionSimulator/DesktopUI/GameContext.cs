using DesktopUI.Extensions;
using DesktopUI.Extensions.Logic;
using Logic.Entities;

namespace DesktopUI;

public class GameContext
{
    private World world;
    private int windowWidth;
    private int windowHeight;
    private int tileSize;

    public void Init(int width, int height)
    {
        this.windowWidth = width;
        this.windowHeight = height;
        this.tileSize = width / width.GreatestCommonDenominator(height);
        world = new World(width / tileSize, height / tileSize);
        world.Populate(1000);

        Raylib.InitWindow(width, height, "Evolution Simulator");
    }

    public void Render()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.WHITE);
        foreach (var creature in world.Creatures)
        {
            if (creature is not null)
            {
                var (x, y) = creature.Position;
                Raylib.DrawRectangle(x * this.tileSize, y * this.tileSize, this.tileSize, this.tileSize, creature.Color.ToRaylibColor());
            }
          
        }
        Raylib.EndDrawing();
    }
}