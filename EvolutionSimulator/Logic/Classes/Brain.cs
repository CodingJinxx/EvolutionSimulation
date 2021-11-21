using Logic.Interfaces;
using Logic.Records;

namespace Logic.Classes;

public class Brain : IUpdateable
{
    private static NeuronFactory factory = new NeuronFactory();
    public Brain(List<Genome> dna)
    {
        NeuralNetwork = new Dictionary<Guid, Neuron>();

        foreach (var genome in dna)
        {
            // Create or Get all Neurons in Genome
            Neuron source;
            if (!NeuralNetwork.ContainsKey(genome.SourceId))
            {
                source = factory.CreateNew(genome.SourceType);
                source.Id = genome.SourceId;
                NeuralNetwork.Add(source.Id, source);
            }
            else
            {
                source = NeuralNetwork[genome.SourceId];
            }

            Neuron sink;
            if (!NeuralNetwork.ContainsKey(genome.SinkId))
            {
                sink = factory.CreateNew(genome.SinkType);
                sink.Id = genome.SinkId;
                NeuralNetwork.Add(sink.Id, sink);
            }
            else
            {
                sink = NeuralNetwork[genome.SinkId];
            }

            // Build Connections
            source.SinkNeurons.Add(new NeuronConnection(genome.Weight, sink));
        }
    }

    public Dictionary<Guid, Neuron> NeuralNetwork { get; set; }

    public void Update()
    {
        foreach (var neuron in NeuralNetwork)
            if(neuron.Value is IUpdateable updateableNeuron)
                updateableNeuron.Update();
    }
}