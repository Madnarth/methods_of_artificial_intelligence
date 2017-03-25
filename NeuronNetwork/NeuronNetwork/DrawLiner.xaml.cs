using System.Windows;
using System.Windows.Shapes;

namespace NeuronNetwork
{
    public partial class DrawLiner : Window
    {
        private double [,] weights;

        private void Draw()
        {
            Line myLine = null;
            double x12 = canvas1.Width;
            double x11 = 250;
            double x21 = -100;
            double x22 = canvas1.Height;
            double x3 = -1;
            double[,] PointX = new double[3, 2];
            double[,] PointY = new double[3, 2];

            for (int i = 0; i < 3; i++)
            {
                PointX[i, 0] = x11;
                PointX[i, 1] = x12;
                PointY[i, 0] = (weights[i, 0] * x11 + x3 * weights[i, 2]) / (weights[i, 1] * x21);
                PointY[i, 1] = (weights[i, 0] * x12  + x3 * weights[i, 2]) / (weights[i, 1] * x22);
                myLine = new Line();

                if (i == 0)
                {
                    myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                }
                else if (i == 1)
                {
                    myLine.Stroke = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    myLine.Stroke = System.Windows.Media.Brushes.Violet;
                }

                myLine.X1 = PointX[0, 0] + 400;
                myLine.X2 = PointX[i, 1] + 400;
                myLine.Y1 = PointY[i, 0] + 100;
                myLine.Y2 = PointY[i, 1] + 100;
                canvas1.Children.Add(myLine);
            }
        }

        public DrawLiner(double [,] weight)
        {
            weights = weight;
            InitializeComponent();
            Draw();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas1.Width = this.Width;
            canvas1.Height = this.Height;
            Draw();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close(); 
        }
    }
}
