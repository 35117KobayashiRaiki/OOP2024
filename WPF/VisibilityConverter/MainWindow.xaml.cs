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

namespace VisibilityConverter {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        // SelectedColor プロパティ（バインディング用）
        public SolidColorBrush SelectedColor { get; set; }

        public MainWindow() {
            InitializeComponent();
        }

        // ラジオボタンがクリックされた時に呼ばれるイベントハンドラ
        private void RadioButton_Checked(object sender, RoutedEventArgs e) {

            var radioButton = sender as RadioButton;

            if (radioButton != null) {
                string colorName = radioButton.Tag.ToString();
                SolidColorBrush colorBrush;

                if (colorName == "Red") {
                    colorBrush = new SolidColorBrush(Colors.Red);
                } else if (colorName == "Blue") {
                    colorBrush = new SolidColorBrush(Colors.Blue);
                } else if (colorName == "Green") {
                    colorBrush = new SolidColorBrush(Colors.Green);
                } else {
                    colorBrush = new SolidColorBrush(Colors.Aqua);
                }

                // ボタンの背景色を変更
                Resources["ButtonBrushKey"] = colorBrush;
            }
        }

        //private void Button_Click(object sender, RoutedEventArgs e) {
        //    Resources["ButtonBrushkey"] = new SolidColorBrush(Colors.DarkGreen);
        //}

        //private void RadioButton_Click(object sender, RoutedEventArgs e) {
        //    RadioButton selectedRadioButton = (RadioButton)sender;

        //    switch(selectedRadioButton.Content) {
        //        case "赤":
        //            Resources["ButtonBrushKey"] = new SolidColorBrush(Colors.Red);
        //            break;
        //        case "青":
        //            Resources["ButtonBrushKey"] = new SolidColorBrush(Colors.Blue);
        //            break;
        //        case "緑":
        //            Resources["ButtonBrushKey"] = new SolidColorBrush(Colors.Green);
        //            break;

        //    }
        //}
    }
}
