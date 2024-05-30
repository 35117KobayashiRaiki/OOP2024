using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            Console.WriteLine("-----");

            Exercise3_6(text);
            Console.WriteLine("-----");

        }

        private static void Exercise3_1(string text) {
            var spaceCount = text.Count(c => c == ' ');
            Console.WriteLine("空白数:" + spaceCount);
        }

        private static void Exercise3_2(string text) {
            var replace = text.Replace("big", "small");
            Console.WriteLine(replace);
        }

        private static void Exercise3_3(string text) {
            var wordCount = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", wordCount);

        }

        private static void Exercise3_4(string text) {
            var moji = text.Split(' ').Where(s => s.Length <= 4).ToArray();
            foreach (var item in moji) {
                Console.WriteLine(item);
            }
        }

        private static void Exercise3_5(string text) {
            var array = text.Split(' ').ToArray();
            var sb = new StringBuilder();

            foreach (var word in array) {
                sb.Append(word);
                sb.Append(' ');
            }
            Console.WriteLine(sb.ToString());
        }

        private static void Exercise3_6(string text) {
            var array = text.Split(new[] { ' ',',','-','_'}).ToArray();
            foreach (var word in array) {
                Console.WriteLine(word);
            }
            
        }
    }
}
