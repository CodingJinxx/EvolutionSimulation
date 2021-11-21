using Logic.Classes;
using Logic.Records;

namespace Logic.Entities;

public record Creature
{
    public Vector2<int> Position;
    public Color Color;
    public Brain brain;
    public List<Genome> DNA;


    public Creature(Vector2<int> position, Color color, List<Genome> dna)
    {
        Color = color;
        Position = position;
        this.DNA = dna;
        brain = new Brain(this.DNA);
    }

    public Creature(Vector2<int> position, List<Genome> dna) : this(position, new Color(0,0,0), dna)
    {
        Color = Color.Random();
    }

    public Creature(int X, int Y, List<Genome> dna) : this(new Vector2<int>(X, Y), dna)
    {


    }
}