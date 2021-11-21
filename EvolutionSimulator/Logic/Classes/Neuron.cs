using Logic.Records;

namespace Logic.Classes;

public delegate bool ActivationFunction(float input);

public abstract class Neuron
{
    public static Dictionary<Guid, Neuron> NeuronRegistry = new Dictionary<Guid, Neuron>();

    public Neuron(Guid id)
    {
        SinkNeurons = new List<NeuronConnection>();
        

        this.Id = id;
        NeuronRegistry.Add(this.Id, this);
    }

    ~Neuron()
    {
        NeuronRegistry.Remove(this.Id);
    }
    public Guid Id { get; set; }
    public List<NeuronConnection> SinkNeurons { get; set; }
    public float Bias { get; set; }

    public ActivationFunction? Predicate { get; set; }
    public event EventHandler<float> OnActivation;

    public virtual void Activate(float input)
    {
        var biased_input = input + Bias;
        var predicate_output = Predicate?.Invoke(biased_input) ?? false;
        if (predicate_output)
        {
            OnActivation?.Invoke(this, biased_input);
            foreach (var neuronConnection in SinkNeurons)
            {
                var weighted_input = biased_input * neuronConnection.Weight;
                neuronConnection.Sink.Activate(weighted_input);
            }
        }
        else
        {
            Console.WriteLine("No Predicate Set, doing nothing");
        }
     
    }



}