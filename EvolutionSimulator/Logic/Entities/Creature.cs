using Logic.Entities.Records;

namespace Logic.Entities;

public record Creature
{
    public Vector2<int> Position;
    public Color Color;

    public Creature(Vector2<int> position, Color color)
    {
        Color = color;
        Position = position;
    }

    public Creature(Vector2<int> position) : this(position, new Color(0,0,0))
    {
        Color = Color.Random();
    }

    public Creature(int X, int Y) : this(new Vector2<int>(X, Y))
    {

    }
}