using System;
using System.Windows;

namespace NeuronNetwork
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            CalculateWindow cw = new CalculateWindow();
            cw.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            double[,] weights = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    weights[i, j] = rand.Next(-100, 100);
                }
            }

            CalculateWindow cw = new CalculateWindow(weights);
            cw.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            UsersWeights uw = new UsersWeights();
            uw.Show();
            this.Close();
        }
    }
}
