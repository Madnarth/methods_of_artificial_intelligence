using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace NeuronNetwork
{
    public partial class DrawLiner : Window
    {
        private double [,] weights;

        private void Draw()
        {
            canvas1.Children.Clear();
            Line ukladx = new Line();
            Line uklady = new Line();
            double wspx=canvas1.Width / 2; 
            double wspy= canvas1.Height / 2;

            ukladx.X1 = 0;
            ukladx.Y1 = wspy;
            ukladx.X2 = canvas1.Width;
            ukladx.Y2 = wspy;

            uklady.X1 = wspx;
            uklady.Y1 = 0;
            uklady.X2 = wspx;
            uklady.Y2 = canvas1.Height;
            ukladx.Stroke = System.Windows.Media.Brushes.Black;
            uklady.Stroke = System.Windows.Media.Brushes.Black;
          
            canvas1.Children.Add(ukladx);
            canvas1.Children.Add(uklady);

            Line myLine = null;
            double x11 = -wspx;
            double x12 = canvas1.Width;
            double x3 = -1;
            double[,] PointX = new double[3, 2];
            double[,] PointY = new double[3, 2];

            for (int i = 0; i < 3; i++)
            {
                PointX[i, 0] = x11;
                PointX[i, 1] = x12;
  
                PointY[i, 0] = (weights[i, 0] * x11 + x3 * weights[i, 2]) / (weights[i, 1] );
                PointY[i, 1] = (weights[i, 0] * x12 + x3 * weights[i, 2]) / (weights[i, 1] );
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
    
                myLine.X1 = PointX[i, 0]+wspx;
                myLine.X2 = PointX[i, 1]+ wspx;
                myLine.Y1 = PointY[i, 0] + wspy;
                myLine.Y2 = PointY[i, 1]+ wspy;
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
