//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Net;
//using System.Net.NetworkInformation;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml.Linq;
//using Microsoft.Web.WebView2.WinForms;


//namespace RssReader {

//    public partial class Form1 : Form {
//        private List<ItemData> items;

//        // RSSフィードのURLを定義します。
//        private readonly Dictionary<string, string> rssUrls = new Dictionary<string, string> {
//            { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
//            { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml" },
//            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
//            { "国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
//            { "エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
//            { "科学", "https://news.yahoo.co.jp/rss/topics/science.xml" },
//            { "国際", "https://news.yahoo.co.jp/rss/topics/world.xml" },
//            { "スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
//            { "地域", "https://news.yahoo.co.jp/rss/topics/local.xml" }
//        };

//        private readonly HashSet<string> rssUrlHistory = new HashSet<string>();

//        // エラーメッセージ定義
//        private const string InvalidUrlMessage = "正しいURLまたは名称を入力してください。";
//        private const string LoadErrorMessage = "RSS フィードの読み込み中にエラーが発生しました: ";
//        private const string AlreadyRegisteredMessage = "このURLはすでに登録されています。";
//        private const string SuccessMessage = "URLが登録されました。";

//        public Form1() {
//            InitializeComponent();
//            InitializeRssUrls();
//        }

//        private void InitializeRssUrls() {
//            foreach (var kvp in rssUrls) {
//                cbRssUrl.Items.Add(new ComboBoxItem(kvp.Key, kvp.Value));
//                rssUrlHistory.Add(kvp.Value);
//            }
//        }

//        private void btGet_Click(object sender, EventArgs e) {
//            string urlToLoad = GetUrlToLoad();

//            if (Uri.IsWellFormedUriString(urlToLoad, UriKind.Absolute)) {
//                if (IsUrlDefined(urlToLoad)) {
//                    try {
//                        LoadRssFeed(urlToLoad);
//                    }
//                    catch (Exception ex) {
//                        MessageBox.Show(LoadErrorMessage + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                } else {
//                    MessageBox.Show("このURLは定義されていないRSSフィードです。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            } else {
//                MessageBox.Show(InvalidUrlMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        private string GetUrlToLoad() {
//            if (cbRssUrl.SelectedItem is ComboBoxItem selectedItem) {
//                return selectedItem.Url;
//            }
//            return cbRssUrl.Text.Trim();
//        }

//        private bool IsUrlDefined(string url) {
//            return rssUrls.Values.Contains(url) || cbRssUrl.Items.OfType<ComboBoxItem>().Any(item => item.Url == url);
//        }

//        private void LoadRssFeed(string url) {
//            using (var wc = new WebClient()) {
//                var xdoc = XDocument.Load(url);
//                items = xdoc.Root.Descendants("item")
//                    .Select(item => new ItemData {
//                        Title = item.Element("title")?.Value ?? "タイトルなし",
//                        Link = item.Element("link")?.Value ?? string.Empty,
//                    }).ToList();

//                UpdateRssTitleList();
//            }
//            AddToRssUrlHistory(url);
//        }

//        private void UpdateRssTitleList() {
//            lbRssTitle.Items.Clear();
//            lbRssTitle.Items.AddRange(items.Select(item => item.Title).ToArray());
//        }

//        private void AddToRssUrlHistory(string rssUrl) {
//            if (rssUrlHistory.Add(rssUrl) && !cbRssUrl.Items.OfType<ComboBoxItem>().Any(item => item.Url == rssUrl)) {
//                cbRssUrl.Items.Add(new ComboBoxItem("Custom", rssUrl));
//            }
//        }

//        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
//            if (lbRssTitle.SelectedIndex >= 0 && lbRssTitle.SelectedIndex < items.Count) {
//                var selectedItem = items[lbRssTitle.SelectedIndex];
//                if (Uri.IsWellFormedUriString(selectedItem.Link, UriKind.Absolute)) {
//                    webView21.Source = new Uri(selectedItem.Link);
//                } else {
//                    MessageBox.Show("選択されたリンクは無効なURLです。", "無効なURL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }
//        }

//        private void btRegistration_Click(object sender, EventArgs e) {
//            string newUrl = tbRssUrl.Text.Trim();
//            string newName = tbRssName.Text.Trim();

//            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newUrl) || !Uri.IsWellFormedUriString(newUrl, UriKind.Absolute)) {
//                MessageBox.Show(InvalidUrlMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (rssUrlHistory.Contains(newUrl)) {
//                MessageBox.Show(AlreadyRegisteredMessage, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            var newItem = new ComboBoxItem(newName, newUrl);
//            cbRssUrl.Items.Add(newItem);
//            rssUrlHistory.Add(newUrl);
//            cbRssUrl.SelectedItem = newItem;

//            MessageBox.Show(SuccessMessage, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            tbRssUrl.Clear();
//            tbRssName.Clear();
//        }
//    }

//    public class ItemData {
//        public string Title { get; set; }
//        public string Link { get; set; }
//    }

//    public class ComboBoxItem {
//        public string Name { get; }
//        public string Url { get; }

//        public ComboBoxItem(string name, string url) {
//            Name = name;
//            Url = url;
//        }

//        public override string ToString() {
//            return Name;
//        }
//    }
//}