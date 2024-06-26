﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            var num = numbers.Max();
            Console.WriteLine(num);
        }

        private static void Exercise1_2(int[] numbers) {
            var num = numbers.Skip(numbers.Length - 2);
            foreach (var nums in num) {
                Console.WriteLine(nums);
            }

            // var skip = numbers.Length - 2;
            // foreach (var nums in numbers.Skip(skip)) {
            //     Console.WriteLine(nums);
            // }

        }

        private static void Exercise1_3(int[] numbers) {
            var num = numbers.Select(n => n.ToString());
            foreach (var nums in num) {
                Console.WriteLine(nums);
            }
        }

        private static void Exercise1_4(int[] numbers) {
            var num = numbers.OrderBy(n => n).Take(3).ToList();
            foreach (var nums in num) {
                Console.WriteLine(nums);
            }

            //foreach (var nums in numbers.OrderBy(x=>x).Take(3)) {
            //    Console.WriteLine(nums);
            //}
        }


        private static void Exercise1_5(int[] numbers) {
            var num = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine(num);
        }
    }
}


