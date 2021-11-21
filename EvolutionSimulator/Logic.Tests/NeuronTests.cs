using System;
using System.Collections.Generic;
using System.Data;
using Logic.Classes;
using Logic.Enums;
using Logic.Records;
using Logic.Tests.Data;
using Microsoft.VisualBasic;
using Xunit;
using Xunit.Abstractions;

namespace Logic.Tests;

public class NeuronTests
{
    private ITestOutputHelper _output;
    private NeuronFactory _neuronFactory;
    public NeuronTests(ITestOutputHelper output)
    {
        _output = output;
        _neuronFactory = new NeuronFactory();
    }

    [Fact]
    public void NeuronActivationTest()
    {
        var input = _neuronFactory.CreateNew(ENeuronTypes.Input) as InputNeuron;
        input.Predicate = f => f > 0.5f;
        input.InputValueAccessor = () => 0.5f;

        bool didFire = false;
        input.OnActivation += (sender, value) =>
        {
            _output.WriteLine($"{input.Id} Fired with Value {value}");
            didFire = true;
        };

        input.Activate(0.1f);
        Assert.False(didFire);
        input.Activate(0.6f);
        Assert.True(didFire);
    }
    /// <summary>
    /// Im confused, dont know what im doing send help
    /// </summary>
    /// <param name="Data"></param>
    [Theory]
    [ClassData(typeof(ChainedNeuronData))]
    public void ChainedNeuronTest(ChainedNeuronRecord[] Data)
    {
        var neuronCount = Data.Length;

        /// 5 Chained Neurons propagating data between, by the end a certain value should or should not have propagated through
        /// * -> * -> * -> *
        ///
        List<InputNeuron> neurons = new List<InputNeuron>();
        InputNeuron startNeuron;
        InputNeuron endNeuron;
        {
            var (input, bias, weight, threshold, expectedOutput) = Data[0];
            endNeuron = _neuronFactory.CreateNew(ENeuronTypes.Input) as InputNeuron;
            neurons.Add(endNeuron as InputNeuron);
            endNeuron.Predicate = input => input > threshold;
            endNeuron.Bias = bias;
            endNeuron.SinkNeurons = new List<NeuronConnection>();
            var i1 = 0;
            endNeuron.OnActivation += (sender, value) =>
            {
                Assert.True(expectedOutput != 0.0f);
                var senderNeuron = sender as Neuron;
                Assert.True(Math.Abs(value - expectedOutput) < 0.00001f);
                _output.WriteLine($"Fired {senderNeuron.Id} with {value}");
            };
        }
     
        for (int i = 1; i < neuronCount; i++)
        {
            var (input, bias, weight, threshold, expectedOutput ) = Data[i];
            var neuron = _neuronFactory.CreateNew(ENeuronTypes.Input) as InputNeuron;
            neurons.Add(neuron as InputNeuron);
            neuron.Predicate = input => input > threshold;
            neuron.Bias = bias;
            neuron.SinkNeurons = new List<NeuronConnection>();
            neuron.SinkNeurons.Add(new NeuronConnection(weight, neurons[i - 1]));
            var i1 = i;
            neuron.OnActivation += (sender, value) =>
            {
                Assert.True(expectedOutput != 0.0f);
                var senderNeuron = sender as Neuron;
                Assert.True(Math.Abs(value - expectedOutput) < 0.00001f);
                _output.WriteLine($"Fired {senderNeuron.Id} with {value}");
            };

            if (i == neuronCount - 1)
            {
                endNeuron = neurons[i];
            }
        }


        foreach (var entry in Data)
        {
            endNeuron.Activate(entry.Input);
        }
    }
}