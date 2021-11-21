using System.Collections;
using System.Collections.Generic;

namespace Logic.Tests.Data;

public record ChainedNeuronRecord(float Input, float Bias, float Weight, float threshold, float ExpectedOutput);

public class ChainedNeuronData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new object[]
            {
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f)
            },
        };
        yield return new object[]
        {
            new object[]
            {
                new ChainedNeuronRecord(1.0f, 1.0f, 0.5f, 0.5f, 1.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f),
                new ChainedNeuronRecord(0.0f, 0.0f, 1.0f, 0.5f, 0.0f)
            },
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}