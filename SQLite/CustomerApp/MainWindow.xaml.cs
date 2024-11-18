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

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase(); //ListView表示

            //テキストボックスをクリア
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer != null) {
                // テキストボックスから入力された新しい値を取得
                selectedCustomer.Name = NameTextBox.Text;
                selectedCustomer.Phone = PhoneTextBox.Text;
                selectedCustomer.Address = AddressTextBox.Text;

                // データベースに接続して更新処理を行う
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();

                    // 顧客情報をデータベースで更新
                    connection.Update(selectedCustomer);
                }

                // 更新後、ListViewを再読み込み
                ReadDatabase(); // 顧客リストを再読み込みして更新を反映

                //テキストボックスをクリア
                NameTextBox.Clear();
                PhoneTextBox.Clear();
                AddressTextBox.Clear();

            } else {
                MessageBox.Show("更新する顧客を選択してください");
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
