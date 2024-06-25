using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {

            var today = DateTime.Today;
            var to = today.ToString("f");
            var time = string.Format("{0}年{1,2}月{2,2}日",today.Year,today.Month,today.Day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = today.ToString("ggyy年M月d日(dddd)", culture);

            tbDisp.Text = today + "\r\n" + time + "\r\n" + str.ToString();


        }
    }
}
