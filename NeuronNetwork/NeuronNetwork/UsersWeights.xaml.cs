using System;
using System.Windows;

namespace NeuronNetwork
{
    public partial class UsersWeights : Window
    {
        public UsersWeights()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            double[,] wagi = new double[3, 3];
            wagi[0, 0] = Convert.ToDouble(textBox1.Text);
            wagi[0, 1] = Convert.ToDouble(textBox2.Text);
            wagi[0, 2] = Convert.ToDouble(textBox3.Text);
            wagi[1, 0] = Convert.ToDouble(textBox4.Text);
            wagi[1, 1] = Convert.ToDouble(textBox5.Text);
            wagi[1, 2] = Convert.ToDouble(textBox6.Text);
            wagi[2, 0] = Convert.ToDouble(textBox7.Text);
            wagi[2, 1] = Convert.ToDouble(textBox8.Text);
            wagi[2, 2] = Convert.ToDouble(textBox9.Text);

            CalculateWindow cw = new CalculateWindow(wagi);
            cw.Show();
            this.Close();
        }
    }
}
