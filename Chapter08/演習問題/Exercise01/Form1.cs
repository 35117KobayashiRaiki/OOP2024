using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {

            var datetime = DateTime.Now;
            
            var str1 = string.Format("{0:yyyy/M/d HH:mm}",datetime);
            tbDisp.Text = str1 + "\r\n";

            var str2 = string.Format("{0}”N{1,2}ŒŽ{2,2}“ú", datetime.Year, datetime.Month, datetime.Day);
            tbDisp.Text += str2 + "\r\n";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str3 = datetime.ToString("ggyy”NMŒŽd“ú(dddd)", culture);
            tbDisp.Text += str3;



        }

        private void btEx8_2_Click(object sender, EventArgs e) {

        }

        public static DateTime NextDay(DateTime date,DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0) 
                days += 7;
            return date.AddDays(days);
            
        }
    }
}
