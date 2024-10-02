using Section01;
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
            //var sortedBooks = Library.Books
            //   .OrderByDescending(b => b.PublishedYear)
            //   .ThenByDescending(b => b.Price);

            //foreach (var book in sortedBooks) {
            //    var categoryName = Library.Categories.First(c => c.Id == book.CategoryId).Name;
            //    Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title} ({categoryName})");
            //}

            var query = Library.Books
                .Join(Library.Categories,
                        book => book.CategoryId,
                        category => category.Id,
                        (book, category) => new {
                            book.Title,
                            book.PublishedYear,
                            book.Price,
                            CategoryName = category.Name,
                        })
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price);

            foreach (var item in query){
                Console.WriteLine("{0}年 {1}円 {2} ({3})",
                                item.PublishedYear,
                                item.Price,
                                item.Title,
                                item.CategoryName
                                );

            }
        }

        private static void Exercise1_5() {
            //var categories = Library.Books
            //    .Where(b => b.PublishedYear == 2016)
            //    .Select(b => Library.Categories.First(c => c.Id == b.CategoryId).Name)
            //    .Distinct();

            //foreach (var category in categories) {
            //    Console.WriteLine(category);
            //}

            var querys = Library.Books
                .Where(b => b.PublishedYear == 2016)
                .Join(Library.Categories,
                        book => book.CategoryId,    //結合する二番目のシーケンス
                        category => category.Id,    //対象シーケンスの結合キー
                        (book, category) => category.Name)     //二番目のシーケンス結合キー
                .Distinct();

            foreach (var name in querys){
                Console.WriteLine(name);
            }


        }

        private static void Exercise1_6() {
            var booksGroupedByCategorys = Library.Books
                .GroupBy(b => Library.Categories.First(c => c.Id == b.CategoryId).Name)
                .OrderBy(g => g.Key);

            foreach (var group in booksGroupedByCategorys) {
                Console.WriteLine($"# {group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"   {book.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var developmentCategoryId = Library.Categories.First(c => c.Name == "Development").Id;

            var booksGroupedByYear = Library.Books
            .Where(b => b.CategoryId == developmentCategoryId)
            .GroupBy(b => b.PublishedYear)
            .OrderBy(g => g.Key);

            foreach (var group in booksGroupedByYear) {
                Console.WriteLine($"#{group.Key}年");
                foreach (var book in group) {
                    Console.WriteLine($" {book.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var query = Library.Categories
                .GroupJoin(
                   Library.Books,
                   category => category.Id,
                   book => book.CategoryId,
                   (category, books) => new {
                       CategoryName = category.Name,
                       BookCount = books.Count()
                   })
               .Where(result => result.BookCount >= 4)
               .Select(result => result.CategoryName)
               .OrderBy(name => name);

            foreach (var categoryName in query) {
                Console.WriteLine($"{categoryName}");

            }
        }
    }
}
