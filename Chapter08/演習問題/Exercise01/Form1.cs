using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {

            var today = DateTime.Today;
            var to = today.ToString("f");
            var time = string.Format("{0}�N{1,2}��{2,2}��",today.Year,today.Month,today.Day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = today.ToString("ggyy�NM��d��(dddd)", culture);

            tbDisp.Text = today + "\r\n" + time + "\r\n" + str.ToString();


        }
    }
}
