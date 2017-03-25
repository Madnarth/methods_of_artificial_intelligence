using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NeuronNetwork
{
    public partial class CalculateWindow : Window
    {
        private Label[] labelkiInputs;
        private Label[] labelkiWeights;
        private Label[] labelkiActivationF;
        private Label[] labelkiOutput;
        private Label[] labelkiOczekiwanyWynik;
        private Image[] ObrazkiNeuronow;
        private Layer layer;
        private bool przyklad = true;
        private double[,] weights;
        private double[,] data;
        private double[,] wynik;
        private int numerGlownejpetli = 0;
        private int NumerPrzykladu = 0;
        private int PoprawnezRzędu = 0;

        public CalculateWindow()
        {
            InitializeComponent();
        }

        public CalculateWindow(double [,] newWeights)
        {
            weights = newWeights;
            przyklad = false;
            InitializeComponent();
        }

        private void Display()
        {
            int petlawag = 0;
            int i = 0;
            int dodatkowyodstep = 20;
            int odleglosc = 95;

            if (numerGlownejpetli == 0)
            {
                labelkiInputs = new Label[100];
                labelkiWeights = new Label[100];
                labelkiOutput = new Label[100];
                labelkiActivationF = new Label[100];
                labelkiOczekiwanyWynik = new Label[100];
                ObrazkiNeuronow = new Image[100];
            }

            foreach (var item in layer.NeuralCells)
            {
                if (numerGlownejpetli == 0)
                {
                    ObrazkiNeuronow[i] = new Image();
                    labelkiInputs[i] = new Label();
                    labelkiActivationF[i] = new Label();
                    labelkiOutput[i] = new Label();
                    labelkiOczekiwanyWynik[i] = new Label();

                }

                labelkiInputs[i].Margin = new Thickness(0, 0, 0, 0);
                labelkiActivationF[i].Margin = new Thickness(0, 0, 0, 0);
                labelkiOutput[i].Margin = new Thickness(0, 0, 0, 0);
                labelkiOczekiwanyWynik[i].Margin = new Thickness(0, 0, 0, 0);

                labelkiActivationF[i].FontFamily = new FontFamily("Century Gothic");
                labelkiOutput[i].FontFamily = new FontFamily("Century Gothic");
                labelkiOczekiwanyWynik[i].FontFamily = new FontFamily("Century Gothic");
                labelkiActivationF[i].FontSize = 22;
                labelkiOutput[i].FontSize = 22;
                labelkiOczekiwanyWynik[i].FontSize = 22;
                labelkiInputs[i].FontFamily = new FontFamily("Century Gothic");

                labelkiInputs[i].FontSize = 22;
                labelkiInputs[i].Content = layer.NeuralCells[i].GetInputData(i).ToString();
                labelkiActivationF[i].Content = layer.NeuralCells[i].GetMembranePotential().ToString();
                labelkiOutput[i].Content = layer.NeuralCells[i].GetOutput().ToString();
                labelkiOczekiwanyWynik[i].Content = wynik[NumerPrzykladu, i].ToString();

                if (numerGlownejpetli == 0)
                {
                    InputPanel.Children.Add(labelkiInputs[i]);
                    ActivePanel.Children.Add(labelkiActivationF[i]);
                    OutputPanel.Children.Add(labelkiOutput[i]);
                    ResultPanel.Children.Add(labelkiOczekiwanyWynik[i]);
                }

                for (int j = 0; j < 3; j++)
                {

                    if (numerGlownejpetli == 0)
                    {
                        labelkiWeights[petlawag] = new Label();
                    }

                    if (j == wynik.GetLength(0) - 1)
                    {
                        labelkiWeights[petlawag].Margin = new Thickness(0, 0, 0, 15);
                        odleglosc += dodatkowyodstep;
                    }
                    else
                    {
                        labelkiWeights[petlawag].Margin = new Thickness(0, 0, 0, 0);
                    }

                    labelkiWeights[petlawag].FontFamily = new FontFamily("Century Gothic");
                    labelkiWeights[petlawag].FontSize = 22;

                    if (numerGlownejpetli == 0)
                    {
                        WeightPanel.Children.Add(labelkiWeights[petlawag]);
                    }

                    labelkiWeights[petlawag].Content = layer.NeuralCells[i].GetInputWeight(j).ToString();
                    petlawag++;
                }

                ++i;
            }
        }

        private void Skoryguj(double[,] wynik, int numerwyniku)
        {
            bool bezkorekty = true;

            for (int i = 0; i < 3; i++)
            {
                if (wynik[numerwyniku, i] != layer.NeuralCells[i].GetOutput())
                {
                    for (int j = 0; j < 3; j++)
                    {
                        double nowawaga = layer.NeuralCells[i].GetInputWeight(j) - layer.NeuralCells[i].GetInputData(j);
                        layer.NeuralCells[i].SetInputWeight(j, nowawaga);
                        weights[i, j] = nowawaga;
                    }

                    bezkorekty = false;
                    PoprawnezRzędu = 0;
                }
            }

            if (bezkorekty)
            {
                PoprawnezRzędu++;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (numerGlownejpetli == 0)
            {
                layer = new Layer(3, 3);
                data = new double[3, 3] { { 10, 2, -1 },
                { 2, -5, -1 },
                { -5, 5, -1 }
            };

                if (przyklad)
                {
                    weights = new double[3, 3] 
                    { 
                        { 1, -2, 0 },
                        { 0, -1, 2 },
                        { 1,  3,-1 },
                    };
                }

                wynik = new double[3, 3]
                {
                    { 1, -1, -1 },
                    {- 1, 1, -1 },
                    { -1, -1, 1 },
                };
            }

            layer.SetInput(data, NumerPrzykladu);
            layer.SetWeights(weights);
            Display();
            Skoryguj(wynik, NumerPrzykladu);
            NumerPrzykladu++;
            numerGlownejpetli++;

            if (NumerPrzykladu >= wynik.GetLength(0))
            {
                NumerPrzykladu = 0;
            }

            if (PoprawnezRzędu >= 4)
            {
                CountOfRow_lab.Content = "Gotowe";
                button3.Visibility = Visibility;
                label8.Visibility = Visibility;
                label9.Visibility = Visibility;
                textBox.Visibility = Visibility;
                textBox1.Visibility = Visibility;
                textBox2.Visibility = Visibility;
                R1_lab.Visibility = Visibility;
                R2_lab.Visibility = Visibility;
                R3_lab.Visibility = Visibility;
            }
            else
            {
                CountOfRow_lab.Content = (PoprawnezRzędu).ToString();
            }

           ilPetli_lab.Content = numerGlownejpetli.ToString();
           numberOfExample_lab.Content = (NumerPrzykladu+1).ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double[,] tmpdata = new double[1, 3];
            tmpdata[0, 0] = Convert.ToDouble(textBox.Text);
            tmpdata[0, 1] = Convert.ToDouble(textBox1.Text);
            tmpdata[0, 2] = Convert.ToDouble(textBox2.Text);

            layer.SetInput(tmpdata, 0);
            layer.SetWeights(weights);
            Display();

            R1_lab.Content = layer.NeuralCells[0].GetOutput().ToString();
            R2_lab.Content = layer.NeuralCells[1].GetOutput().ToString();
            R3_lab.Content = layer.NeuralCells[2].GetOutput().ToString();

            R1_lab.FontFamily = new FontFamily("Gothic Century");
            R1_lab.FontSize = 22;
            R2_lab.FontFamily = new FontFamily("Gothic Century");
            R2_lab.FontSize = 22;
            R3_lab.FontFamily = new FontFamily("Gothic Century");
            R3_lab.FontSize = 22;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            DrawLiner dl = new DrawLiner(weights);
            dl.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
