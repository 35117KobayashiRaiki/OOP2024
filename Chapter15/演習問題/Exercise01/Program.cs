﻿using Section01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var price = Library.Books
                .Max(b => b.Price);

            var book = Library.Books
                .First(b => b.Price == price);

            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var groups = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(g => new {
                    Year = g.Key,
                    Count = g.Count(),
                })
                .OrderBy(g => g.Year);

            foreach (var group in groups) {
                Console.WriteLine($"発行年: {group.Year}, 書籍数: {group.Count}");
                
            }
        }

        private static void Exercise1_4() {
            var sortedBooks = Library.Books
               .OrderByDescending(b => b.PublishedYear)
               .ThenByDescending(b => b.Price);

            foreach (var book in sortedBooks) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_5() {
            var categories = Library.Books
                .Where(b => b.PublishedYear == 2016)
                .Select(b => Library.Categories.First(c => c.Id == b.CategoryId).Name)
                .Distinct();

            foreach (var category in categories) {
                Console.WriteLine(category);
            }
        }

        private static void Exercise1_6() {
            
        }

        private static void Exercise1_7() {
            
        }

        private static void Exercise1_8() {
            
        }
    }
}
