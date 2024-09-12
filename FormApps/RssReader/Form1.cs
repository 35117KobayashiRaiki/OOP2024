using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Web.WebView2.WinForms;


namespace RssReader {

    public partial class Form1 : Form {
        List<ItemData> items;

        // RSSフィードのURLを定義します。
        private readonly Dictionary<string, string> rssUrls = new Dictionary<string, string> {
            { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
            { "科学", "https://news.yahoo.co.jp/rss/topics/science.xml" },
            { "国際", "https://news.yahoo.co.jp/rss/topics/world.xml" },
            { "スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
            { "地域", "https://news.yahoo.co.jp/rss/topics/local.xml" }
        };

        // 重複しない履歴を管理するための HashSet
        private readonly HashSet<string> rssUrlHistory = new HashSet<string>();

        public Form1() {
            InitializeComponent();
            InitializeRssUrls();  // 初期 RSS URL を設定
        }

        private void InitializeRssUrls() {
            foreach (var kvp in rssUrls) {
                var item = new ComboBoxItem(kvp.Key, kvp.Value);
                cbRssUrl.Items.Add(item);
                rssUrlHistory.Add(kvp.Value); // 初期 URL を履歴に追加
            }

        }

        private void btGet_Click(object sender, EventArgs e) {
            // コンボボックスの選択が履歴からのものであれば、その URL を使用
            if (cbRssUrl.SelectedItem is ComboBoxItem selectedItem) {
                // 履歴の URL またはトピック名の選択を処理
                string urlToLoad = selectedItem.Url;

                // トピック名から URL を取得する場合
                if (rssUrls.ContainsKey(selectedItem.Name)) {
                    urlToLoad = rssUrls[selectedItem.Name];
                } else if (Uri.IsWellFormedUriString(urlToLoad, UriKind.Absolute)) {
                    // 直接 URL が指定された場合
                    // ここでの URL の検証は省略
                } else {
                    // 無効な URL または名称の場合
                    MessageBox.Show("正しいURLまたは名称を入力してください。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // URL を読み込み、タイトルを表示
                LoadRssFeed(urlToLoad);
            }
        }


        private void LoadRssFeed(string url) {
            using (var wc = new WebClient()) {
                var xdoc = XDocument.Load(url);



                items = xdoc.Root.Descendants("item")
                                    .Select(item => new ItemData {
                                        Title = item.Element("title").Value,
                                        Link = item.Element("link").Value,
                                    }).ToList();

                lbRssTitle.Items.Clear();

                foreach (var item in items) {
                    lbRssTitle.Items.Add(item.Title);
                }
            }
            setCbRssUrl(url);
        }

        private void setCbRssUrl(string rssUrl) {
            // URL が履歴にない場合のみ追加
            if (rssUrlHistory.Add(rssUrl)) {
                // コンボボックス内で重複していないか確認
                if (!cbRssUrl.Items.OfType<ComboBoxItem>().Any(item => item.Url == rssUrl)) {
                    // `ComboBoxItem` を追加
                    var newItem = new ComboBoxItem("Custom", rssUrl);
                    cbRssUrl.Items.Add(newItem);
                }
            }
        }




        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex >= 0 && lbRssTitle.SelectedIndex < items.Count) {
                var selectedItem = items[lbRssTitle.SelectedIndex];
                if (Uri.IsWellFormedUriString(selectedItem.Link, UriKind.Absolute)) {
                    webView21.Source = new Uri(selectedItem.Link);
                } else {
                    MessageBox.Show("The selected link is not a valid URL.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cbRssUrl_SelectedIndexChanged(object sender, EventArgs e) {
            
        }

        private void cbRssUrl_TextChanged(object sender, EventArgs e) {

        }

        private void btRegistration_Click(object sender, EventArgs e) {
            // テキストボックスからURLと名前を取得
            string newUrl = tbRssUrl.Text.Trim();
            string newName = tbRssName.Text.Trim();

            // 名前が空でないか、URLが正しい形式かを確認
            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newUrl) || !Uri.IsWellFormedUriString(newUrl, UriKind.Absolute)) {
                MessageBox.Show("無効なURLまたは名前です。正しいURLと名前を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // URL がすでに履歴に存在するか確認
            if (rssUrlHistory.Contains(newUrl)) {
                MessageBox.Show("このURLはすでに登録されています。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // コンボボックスに新しいURLを追加
            var newItem = new ComboBoxItem(newName, newUrl);
            cbRssUrl.Items.Add(newItem);
            rssUrlHistory.Add(newUrl);

            // コンボボックスに登録したURLを表示
            cbRssUrl.SelectedItem = newItem;

            // 成功メッセージを表示
            MessageBox.Show("URLが登録されました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // テキストボックスの内容をクリアする（オプション）
            tbRssUrl.Clear();
            tbRssName.Clear();
        }
    }

    public class ItemData {
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class ComboBoxItem {
        public string Name { get; }
        public string Url { get; }

        public ComboBoxItem(string name, string url) {
            Name = name;
            Url = url;
        }

        public override string ToString() {
            return Name;
        }
    }
}
