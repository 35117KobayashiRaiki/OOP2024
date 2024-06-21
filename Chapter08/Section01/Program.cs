using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            
            Console.WriteLine("生年月日を入力");
            Console.Write("年:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("月:");
            int t = int.Parse(Console.ReadLine());
            Console.Write("日:");
            int h = int.Parse(Console.ReadLine());
            
            var birthday = new DateTime(n, t, h);

            //あなたは平成○○年○月○日○曜日に生まれました。
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthday.ToString("ggyy年M月d日dddd",culture);  
            Console.WriteLine("あなたは" + str + "に生まれました");

            //あなたは生まれてから今日で○○○○日目です
            var today = DateTime.Today;
            TimeSpan diff = today - birthday;
            Console.WriteLine("あなたは生まれてから今日で{0}日目です", diff.Days + 1);
            
            //switch (dayOfWeek) {
            //    case DayOfWeek.Sunday:
            //        Console.WriteLine("日曜日");
            //        break;
            //    case DayOfWeek.Monday:
            //         Console.WriteLine("月曜日");
            //         break;
            //    case DayOfWeek.Tuesday:
            //         Console.WriteLine("火曜日");
            //         break;
            //    case DayOfWeek.Wednesday:
            //         Console.WriteLine("水曜日");
            //         break;
            //    case DayOfWeek.Thursday:
            //         Console.WriteLine("木曜日");
            //         break;
            //    case DayOfWeek.Friday:
            //         Console.WriteLine("金曜日");
            //         break;
            //   case DayOfWeek.Saturday:
            //         Console.WriteLine("土曜日");
            //         break;
            //}
        }
    }
}
