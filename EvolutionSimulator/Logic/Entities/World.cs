using System.Numerics;
using Logic.Entities.Records;

namespace Logic.Entities;

public class World
{
    private static Random r = new Random();

    public int Width;
    public int Height;
    public Creature[,] Creatures;

    public World(int width, int height)
    {
        Width = width;
        Height = height;
        Creatures = new Creature[Width, Height];
    }

    public void Populate(int population)
    {
        HashSet<Vector2<int>> PopulatedAlready = new HashSet<Vector2<int>>();
        Creatures = new Creature[Width, Height];
        for (int i = 0; i < population; i++)
        {
            int X = r.Next(0, Width);
            int Y = r.Next(0, Height);
            if (PopulatedAlready.Contains(new Vector2<int>(X, Y)))
            {
                i--;
                continue;
            }
            else
                PopulatedAlready.Add(new Vector2<int>(X, Y));
            Creatures[X, Y] = new Creature(X, Y);
        }
    }
}