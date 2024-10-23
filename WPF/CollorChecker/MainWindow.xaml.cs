using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        private List<Color> colorStock = new List<Color>();

        public MainWindow() {
            InitializeComponent();
            UpdateColorValues();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColorValues();
        }

        private void UpdateColorValues() {
            int r = (int)rSlider.Value;
            int g = (int)gSlider.Value;
            int b = (int)bSlider.Value;

            rValue.Text = r.ToString();
            gValue.Text = g.ToString();
            bValue.Text = b.ToString();

            Color color = Color.FromRgb((byte)r, (byte)g, (byte)b);
            colorArea.Background = new SolidColorBrush(color);

        }

        private void Value_TextChanged(object sender, TextChangedEventArgs e) {
            if (int.TryParse(rValue.Text, out int r) &&
                int.TryParse(gValue.Text, out int g) &&
                int.TryParse(bValue.Text, out int b)) {

                r = r < 0 ? 0 : (r > 255 ? 255 : r);
                g = g < 0 ? 0 : (g > 255 ? 255 : g);
                b = b < 0 ? 0 : (b > 255 ? 255 : b);

                rSlider.Value = r;
                gSlider.Value = g;
                bSlider.Value = b;

                Color color = Color.FromRgb((byte)r, (byte)g, (byte)b);
                colorArea.Background = new SolidColorBrush(color);
            }
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            Color currentColor = ((SolidColorBrush)colorArea.Background).Color;
            colorStock.Add(currentColor);
            stockList.Items.Add(currentColor.ToString());
        }
    }
}
