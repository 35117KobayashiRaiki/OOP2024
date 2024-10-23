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

        private List<MyColor> colorStock = new List<MyColor>();

        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            rValue.Text = r.ToString();
            gValue.Text = g.ToString();
            bValue.Text = b.ToString();

            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
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

                colorArea.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
            }
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var currentColor = ((SolidColorBrush)colorArea.Background).Color;

            // 重複チェック
            if (!colorStock.Any(c => c.Color == currentColor)) {
                var myColor = new MyColor { Color = currentColor, Name = "Color " + (colorStock.Count + 1) };
                colorStock.Add(myColor);
                stockList.Items.Add(myColor);
            } else {
                MessageBox.Show("この色はすでに登録されています。", "重複エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                byte r = selectedColor.Color.R;
                byte g = selectedColor.Color.G;
                byte b = selectedColor.Color.B;

                rSlider.Value = r;
                gSlider.Value = g;
                bSlider.Value = b;

                rValue.Text = r.ToString();
                gValue.Text = g.ToString();
                bValue.Text = b.ToString();
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
            }
        }
    }
}
