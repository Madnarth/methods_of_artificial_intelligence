using System.Collections.Generic;

namespace NeuronNetwork
{
    class Layer
    {
        public List<NeuralCell> NeuralCells = new List<NeuralCell>(100);

        public Layer(int NeuralCellsQuantity, int inputQuantity)
        {
            for (int i = 0; i < NeuralCellsQuantity; i++)
            {
                NeuralCells.Add(new NeuralCell(inputQuantity));
            }
        }

        public void SetInput(double[] data)
        {
            int i = 0;

            foreach (var item in NeuralCells)
            {
                {
                    for (int j = 0; j < data.Length; j++)
                    {
                        this.NeuralCells[i].SetInputData(j, data[j]);
                    }
                }

                i++;
            }
        }
        public void SetInput(double[,] data, int numerDanych)
        {
            int i = 0;

            foreach (var item in NeuralCells)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    this.NeuralCells[i].SetInputData(j, data[numerDanych, j]);
                }

                i++;
            }
        }
        public void SetWeights(double[,] weights)
        {
            for (int i = 0; i < weights.GetLength(0); i++)
            {
                for (int j = 0; j < weights.GetLength(1); j++)
                {
                    this.NeuralCells[i].SetInputWeight(j, weights[i, j]);
                }
            }
        }
    }
}
