using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btEx8_1_Click(object sender, EventArgs e) {

            var datetime = DateTime.Now;
            
            var str1 = string.Format("{0:yyyy/M/d HH:mm}",datetime);
            tbDisp.Text = str1 + "\r\n";

            var str2 = string.Format("{0}�N{1,2}��{2,2}��", datetime.Year, datetime.Month, datetime.Day);
            tbDisp.Text += str2 + "\r\n";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str3 = datetime.ToString("ggyy�NM��d��(dddd)", culture);
            tbDisp.Text += str3;



        }

        private void btEx8_2_Click(object sender, EventArgs e) {

            var date = DateTime.Today;
            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))){

                var str = string.Format("{0:yyyy/MM/dd}�̎��T��{1}",date,(DayOfWeek)dayofweek);
                tbDisp.Text += str + ":" + NextWeek(date,(DayOfWeek) dayofweek) + "\r\n";
                //���T�̓��t���擾(�߂�l���󂯎��)
                //var days = NextDay(date, (DayOfWeek)dayofweek);
            }
            
            
        }

        //�������Ŏw�肵�����t�̗��T�̃C���X�^���X��ԋp����B�������A�������Ŏw�肵�����T�̗j���Ƃ���
        public static DateTime NextWeek(DateTime date,DayOfWeek dayOfWeek) {
            var nextweek = date.AddDays(7);
            var days = (int)dayOfWeek - (int)date.DayOfWeek;
            if (days <= 0) 
                days += 7;
                
            return date.AddDays(days);

        }
    }
}
