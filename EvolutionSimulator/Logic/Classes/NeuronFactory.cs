using System.Diagnostics;
using Logic.Enums;

namespace Logic.Classes;

public class NeuronFactory
{
    // TODO Actual Implementation, this is just temporary
    public Neuron CreateNew(ENeuronTypes type)
    {
        return type switch
        {
            ENeuronTypes.Input => new InputNeuron(() => 0.5f),
            ENeuronTypes.Output => new OutputNeuron(),
            ENeuronTypes.Internal => new InternalNeuron()
        };
    }
}