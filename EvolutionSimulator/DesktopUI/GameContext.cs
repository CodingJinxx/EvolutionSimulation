using System.Numerics;
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
    private Camera2D camera;
    private float speed = 200.0f;

    public void Init(int width, int height)
    {
        this.windowWidth = width;
        this.windowHeight = height;
        this.tileSize = 20;
        world = new World(width / tileSize, height / tileSize);
        world.Populate(100);

        camera = new Camera2D(Vector2.Zero, Vector2.Zero, 0, 1.0f);


        Raylib.SetTargetFPS(144);
        Raylib.InitWindow(width, height, "Evolution Simulator");
    }

    public void Update()
    {
        var delta = Raylib.GetFrameTime();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            camera.target += new Vector2(0, -1) * delta * speed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            camera.target += new Vector2(0, 1) * delta * speed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            camera.target += new Vector2(1, 0) * delta * speed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            camera.target += new Vector2(-1, 0) * delta * speed;
        }

        camera.zoom += Raylib.GetMouseWheelMove() * delta * 2.0f;
    }

    
    public void Render()
    {
        Raylib.BeginDrawing();

        Raylib.ClearBackground(Color.WHITE);
        Raylib.BeginMode2D(camera);

        foreach (var creature in world.Creatures)
        {
            if (creature is not null)
            {
                var (x, y) = creature.Position;
                Raylib.DrawRectangle(x * this.tileSize, y * this.tileSize, this.tileSize, this.tileSize, creature.Color.ToRaylibColor());
            }
          
        }
        Raylib.EndMode2D();
        Raylib.EndDrawing();
    }
}