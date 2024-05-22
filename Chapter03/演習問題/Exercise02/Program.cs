using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(names);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(names);

            Console.WriteLine("***** 3.2.4 *****");
            Console.WriteLine();
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            
            do {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;  //空行だったら抜ける

                    var index = names.FindIndex(n => n == line);
                    Console.WriteLine(index);

            } while (true) ;


            }

        private static void Exercise2_2(List<string> names) {
            var count = names.Count(n => n.Contains("o"));
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<string> names) {
            names.Where(n => n.Contains("o")).ToList()
                 .ForEach(n => Console.WriteLine(n));
        }

        private static void Exercise2_4(List<string> names) {
            
        }
    }
}
