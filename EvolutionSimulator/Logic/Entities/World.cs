using System.Numerics;

namespace Logic.Entities;

public class World
{
    public int Width;
    public int Height;
    public Creature[,] Creatures;

    public World(int width, int height)
    {
        Width = width;
        Height = height;
        Creatures = new Creature[Width, Height];
    }
}