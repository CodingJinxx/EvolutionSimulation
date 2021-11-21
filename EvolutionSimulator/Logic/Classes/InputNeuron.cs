using Logic.Interfaces;

namespace Logic.Classes;


public class InputNeuron : Neuron, IUpdateable
{
    public Func<float> InputValueAccessor;

    public InputNeuron(Func<float> inputValueAccessor) : base(Guid.NewGuid())
    {
        InputValueAccessor = inputValueAccessor;
    }

    public void Update()
    {
        float input = InputValueAccessor();
        Activate(input);
    }
}