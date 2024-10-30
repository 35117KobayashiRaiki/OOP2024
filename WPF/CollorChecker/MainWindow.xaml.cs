using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CollorChecker {
    public partial class MainWindow : Window {
        MyColor currentColor;   //現在設定している色情報

        public MainWindow() {
            InitializeComponent();
            //αチャンネルの初期値を設定 (起動時すぐにストックボタンが押された場合の対応)
            currentColor.Color = Color.FromArgb(255, 0, 0, 0);
            DataContext = GetColorList();
        }

        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //スライダーを動かすと呼ばれるイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColor.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            currentColor.Name = GetColorList().Where(c => c.Color.Equals(currentColor.Color))
                .Select(c => c.Name)
                .FirstOrDefault() ??
                $"R:{currentColor.Color.R} G:{currentColor.Color.G} B:{currentColor.Color.B}";
            colorArea.Background = new SolidColorBrush(currentColor.Color);
            UpdateStockButtonColor(); // ボタンの色を更新

        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            //既に登録されている場合は登録しない
            if (!stockList.Items.Contains((MyColor)currentColor)){
                stockList.Items.Insert(0, currentColor);
                UpdateStockButtonColor(); // ボタンの色を更新
            } else {
                MessageBox.Show("既に登録されています！", "ColorChecker", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedIndex >= 0) {
                var selectedColor = (MyColor)stockList.Items[stockList.SelectedIndex];
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                // 各スライダーの値を設定する
                setSliderValue(selectedColor.Color);
            }
        }

        //各スライダーの値の設定する
        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var tempCurrentColor = currentColor = (MyColor)((ComboBox)sender).SelectedItem;
            //各スライダーの値の設定する
            setSliderValue(currentColor.Color);
            currentColor.Name = tempCurrentColor.Name;  //Nameプロパティの文字列を再設定
            UpdateStockButtonColor(); // ボタンの色を更新
        }

        private void removeButton_Click(object sender, RoutedEventArgs e) {
            var selectedColor = stockList.SelectedItem as MyColor?;

            if (selectedColor != null) {
                MessageBoxResult result = MessageBox.Show(
                    $"'{selectedColor}' を削除しますか？",
                    "確認",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes) {
                    stockList.Items.Remove(selectedColor);
                    ResetToDefaultColor();
                }
            } else {
                MessageBox.Show("削除するアイテムを選択してください！", "ColorChecker", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ResetToDefaultColor() {
            rSlider.Value = 0;
            gSlider.Value = 0;
            bSlider.Value = 0;

            colorArea.Background = new SolidColorBrush(Colors.Black);
        }

        private void UpdateStockButtonColor() {
            stockButton.Background = new SolidColorBrush(currentColor.Color);
        }

    }
}