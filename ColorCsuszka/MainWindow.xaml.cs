using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => UpdateColorFromSlider();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string hexCode = textColor.Text;
                Color color = (Color)ColorConverter.ConvertFromString(hexCode);
                byte r = color.R;
                byte g = color.G;
                byte b = color.B;

                sliderRed.Value = r;
                sliderGreen.Value = g;
                sliderBlue.Value = b;

                txtRgb.Text = $"RGB: {r}, {g}, {b}";
                BrushConverter brushConverter = new BrushConverter();
                Brush brush = (Brush)brushConverter.ConvertFromString(hexCode);
                colorPreview.Background = brush;
            }
            catch (Exception)
            {
                MessageBox.Show("Rossz input!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            byte r = (byte)random.Next(256);
            byte g = (byte)random.Next(256);
            byte b = (byte)random.Next(256);

            sliderRed.Value = r;
            sliderGreen.Value = g;
            sliderBlue.Value = b;


            Color color = Color.FromRgb(r, g, b);
            SolidColorBrush brush = new SolidColorBrush(color);
            colorPreview.Background = brush;
            textColor.Text = $"#{r:X2}{g:X2}{b:X2}";
            txtRgb.Text = $"RGB: {r}, {g}, {b}";
        }

        private void textColor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sliderRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorFromSlider();

        }

        private void sliderGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorFromSlider();
        }

        private void sliderBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColorFromSlider();
        }

        private void UpdateColorFromSlider() 
        {
            if (sliderRed == null || sliderGreen == null || sliderBlue == null || colorPreview == null || textColor == null || txtRgb == null) 
            {
                return;
            }
            byte r = (byte)sliderRed.Value;
            byte g = (byte)sliderGreen.Value;
            byte b  = (byte)sliderBlue.Value;

            Color color = Color.FromRgb(r, g, b);
            SolidColorBrush brush = new SolidColorBrush(color);

            colorPreview.Background = brush;
            textColor.Text = $"#{r:X2}{g:X2}{b:X2}";
            txtRgb.Text = $"RGB: {r}, {g}, {b}";
        }
    }
}