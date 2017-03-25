using System;
using System.Collections.Generic;

namespace NeuronNetwork
{
    class NeuralCell
    {
        private List<Double> Dendrites;
        private List<Double> Synapses;

        public NeuralCell()
        {
            Dendrites = new List<double>(100);
            Synapses = new List<double>(100);
        }

        public NeuralCell(int inputQuantity)
        {
            Dendrites = new List<double>(inputQuantity);
            Synapses = new List<double>(inputQuantity);
            this.AddInput(inputQuantity);
        }

        public double FinalizeData(double membranePotential)
        {
            return membranePotential;
        }

        public int GetInputSize()
        {
            return Dendrites.Capacity;
        }

        public void AddInput()
        {
            Dendrites.Add(0.0);
            Synapses.Add(1.0);
        }

        public void AddInput(int count)
        {
            for (int i = 1; i <= count; i++)
                this.AddInput();
        }

        public double GetInputData(int index)
        {
            return Dendrites[index];
        }

        public void SetInputData(int index, double value)
        {
            Dendrites[index] = value;
        }

        public double GetInputWeight(int index)
        {
            return Synapses[index];
        }

        public void SetInputWeight(int index, double weight)
        {
            Synapses[index] = weight;
        }

        public double ProcessCellNode(int index)
        {
            return (Dendrites[index] * Synapses[index]);
        }

        public double GetMembranePotential()
        {
            double sum = 0;

            if (GetInputSize() == 0)
            {
                return -1;
            }
 
            for (int i = 0; i < GetInputSize(); i++)
            {
                sum += ProcessCellNode(i);
            }

            return sum;
        }

        public double ActivationFunction()
        {
            if (GetInputSize() == 0)
            {
                return -1;
            }

            return FinalizeData(GetMembranePotential());
        }

        public double GetOutput()
        {
            return Math.Sign(ActivationFunction());
        }
    }
}
