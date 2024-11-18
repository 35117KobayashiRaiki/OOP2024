using CustomerApp.Objects;
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

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        public MainWindow() {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
            };

            using(var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase(); //ListView表示

            // テキストボックスをクリア
            //NameTextBox.Clear();
            //PhoneTextBox.Clear();
            //AddressTextBox.Clear();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            //// ListViewで選択されているアイテムを取得
            //var selectedCustomer = CustomerListView.SelectedItem as Customer;

            //// 顧客が選択されていない場合
            //if (selectedCustomer == null) {
            //    MessageBox.Show("更新する顧客を選択してください");
            //    return;
            //}

            //// テキストボックスに選択した顧客の情報をロード
            //NameTextBox.Text = selectedCustomer.Name;
            //PhoneTextBox.Text = selectedCustomer.Phone;
            //AddressTextBox.Text = selectedCustomer.Address;

            //// 保存ボタンの処理を更新に合わせて変更
            //// 保存ボタンを押した後、選択した顧客を更新するコードを追加
            //SaveButton.Click -= SaveButton_Click; // 既存のクリックイベントハンドラーを削除
            //SaveButton.Click += (s, args) => {
            //    // 更新された情報を取得
            //    selectedCustomer.Name = NameTextBox.Text;
            //    selectedCustomer.Phone = PhoneTextBox.Text;
            //    selectedCustomer.Address = AddressTextBox.Text;

            //    // データベースで更新処理
            //    using (var connection = new SQLiteConnection(App.databasePass)) {
            //        connection.CreateTable<Customer>();
            //        connection.Update(selectedCustomer);
            //    }

            //    // ListViewを再読み込みして更新後のデータを表示
            //    ReadDatabase();
            //};
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
            if(item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);

                ReadDatabase(); //ListView表示
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ReadDatabase(); //ListView表示
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                // 顧客が選択されていれば、テキストボックスに値を設定
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;
            }
        }
    }
}
