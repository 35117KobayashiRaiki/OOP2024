using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            string input = Console.ReadLine();
            int num;

            if (int.TryParse(input, out num)) {
                var comma = num.ToString("N0");
                Console.WriteLine(comma);
            } else {
                Console.WriteLine("入力された文字列は数値に変換できませんでした。");
            }
        }

        private static string FormatNumberWithCommas(int number) {
            return number.ToString("N0");
        }

    }
}
