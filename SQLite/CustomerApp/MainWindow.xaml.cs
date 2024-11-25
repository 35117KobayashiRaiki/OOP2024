using CustomerApp.Objects;
using Microsoft.Win32;
using SQLite;
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
using System.IO;

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        private byte[] _imageBytes = null; // 画像のバイト配列を保持するフィールド
        public MainWindow() {
            InitializeComponent();
        }

        private void RegistButton_Click(object sender, RoutedEventArgs e) {
            // 名前が未入力の場合は処理を中止
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)) {
                MessageBox.Show("名前を入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Image = _imageBytes
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase(); //ListView表示

            //テキストボックスと画像をクリア
            ClearInputFields();
        }

        //テキストボックスと画像をクリア
        private void ClearInputFields() {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
            _imageBytes = null; // 画像データをクリア
            CustomerImage.Source = null; // Imageコントロールをクリア
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer != null) {
                // テキストボックスから入力された新しい値を取得
                selectedCustomer.Name = NameTextBox.Text;
                selectedCustomer.Phone = PhoneTextBox.Text;
                selectedCustomer.Address = AddressTextBox.Text;

                if (_imageBytes != null) {
                    // 新しい画像が選ばれている場合、画像を更新
                    selectedCustomer.Image = _imageBytes;
                } else {
                    // 画像が選ばれていない場合、画像をnullに設定
                    selectedCustomer.Image = null;
                }

                // データベースに接続して更新処理を行う
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Update(selectedCustomer); // 顧客データの更新
                }

                // 更新後、ListViewを再読み込み
                ReadDatabase();

                // テキストボックスと画像をクリア
                ClearInputFields();
            } else {
                MessageBox.Show("更新するデータを選択してください");
            }
        }

        //ListView表示
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();

                CustomerListView.ItemsSource = _customers;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var fillterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = fillterList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);

                ReadDatabase(); //ListView表示
            }

            //テキストボックスと画像をクリア
            ClearInputFields();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ReadDatabase(); //ListView表示
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer != null) {
                // テキストボックスに表示
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;

                // 画像を表示
                if (selectedCustomer.Image != null) {
                    var image = new BitmapImage();
                    using (var stream = new MemoryStream(selectedCustomer.Image)) {
                        image.BeginInit();
                        image.StreamSource = stream;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                    }
                    CustomerImage.Source = image;
                } else {
                    // 画像が選択されていない場合は、画像をクリア
                    CustomerImage.Source = null;
                }
            }
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            // OpenFileDialogを使って画像を選択
            var dialog = new OpenFileDialog {
                Filter = "画像ファイル (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg"
            };

            if (dialog.ShowDialog() == true) {
                // 選択した画像のファイルパス
                var filePath = dialog.FileName;

                // 画像をバイト配列に変換
                _imageBytes = File.ReadAllBytes(filePath);

                // 画像をImageコントロールに表示
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(filePath);
                image.EndInit();
                CustomerImage.Source = image;
            }
        }

        private void ClearImageButton_Click(object sender, RoutedEventArgs e) {
            // 画像をクリアする
            _imageBytes = null;
            CustomerImage.Source = null;

        }
    }
}
