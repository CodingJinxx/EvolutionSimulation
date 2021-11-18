using Logic.Entities;

namespace DesktopUI;

public class GameContext
{
    private World world;
    private int windowWidth;
    private int windowHeight;

    public void Init(int width, int height)
    {
        this.windowWidth = width;
        this.windowHeight = height;
        world = new World(width, height);

        Raylib.InitWindow(width, height, "Evolution Simulator");
        Raylib.ClearBackground(Color.WHITE);
    }
}