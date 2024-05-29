using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            // 4.2.1
            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2001, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            // 4.2.2
            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
            Console.WriteLine("\n- 4.2.4 ---");

            // 4.2.4
            Exercise2_4(ymCollection);
            Console.WriteLine("\n- 4.2.5 ---");


            // 4.2.5
            Exercise2_5(ymCollection);
        }

        // 4.2.2
        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (YearMonth ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }

        // 4.2.3(4.2.4で呼ぶ出されるメソッド)
        static YearMonth FindFirst21C(YearMonth[] yms) {
            foreach (YearMonth ym in yms) {
                if (ym.Is21Centuty) {
                    return ym;
                }
            }
            return null;
        }

        // 4.2.4
        private static void Exercise2_4(YearMonth[] ymCollection) {
            //var ym = FindFirst21C(ymCollection);

            //if (ym != null) {
            //    Console.WriteLine(ym);
            //} else {
            //    Console.WriteLine("21世紀のデータはありません");

            var ym = FindFirst21C(ymCollection);
            Console.WriteLine(ym == null ? "21世紀のデータはありません" : ym.ToString());

        }

        // 4.2.5
        private static void Exercise2_5(YearMonth[] ymCollection) {
            var arrray = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            foreach (var ym in arrray){
                Console.WriteLine(ym);
            }
        }
    }
}
