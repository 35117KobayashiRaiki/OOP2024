using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CollorChecker {
    public partial class MainWindow : Window {
        private List<MyColor> colorStock = new List<MyColor>();

        public MainWindow() {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColorFromSliders();
        }

        private void Value_TextChanged(object sender, TextChangedEventArgs e) {
            if (int.TryParse(rValue.Text, out int r) &&
                int.TryParse(gValue.Text, out int g) &&
                int.TryParse(bValue.Text, out int b)) {

                rSlider.Value = Clamp(r);
                gSlider.Value = Clamp(g);
                bSlider.Value = Clamp(b);

                UpdateColor();
            }
        }

        private int Clamp(int value) {
            return Math.Max(0, Math.Min(255, value));
        }

        private void UpdateColorFromSliders() {
            UpdateColor();
            rValue.Text = ((byte)rSlider.Value).ToString();
            gValue.Text = ((byte)gSlider.Value).ToString();
            bValue.Text = ((byte)bSlider.Value).ToString();
        }

        private void UpdateColor() {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;
            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var currentColor = ((SolidColorBrush)colorArea.Background).Color;
            if (!colorStock.Any(c => c.Color == currentColor)) {
                var myColor = new MyColor { Color = currentColor };
                colorStock.Add(myColor);
                stockList.Items.Add(myColor);
            } else {
                MessageBox.Show("この色はすでに登録されています。", "重複エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                rSlider.Value = selectedColor.Color.R;
                gSlider.Value = selectedColor.Color.G;
                bSlider.Value = selectedColor.Color.B;

                UpdateColorFromSliders();
            }
        }
    }
}