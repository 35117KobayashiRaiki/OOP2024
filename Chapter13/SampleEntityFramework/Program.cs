using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    internal class Program {
        static void Main(string[] args) {

            //UpdateBook();
            //AddBooks();
            //AddAuthors();
            //InsertBooks();
            //DisplayAllBooks();
            //DisplayAllBooks2();

            DisplayAllBooks3();

            Console.WriteLine();
            Console.WriteLine("# 1.4");
            Exercise1_4();

            Console.WriteLine();
            Console.WriteLine("# 1.5");
            Exercise1_5();

            Console.ReadLine(); //コンソールアプリだが F5 でデバッグ実行したいために記述



        }

        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var books = db.Books
                              .OrderBy(b => b.PublishedYear)
                              .Take(3)
                              .Select(b => new {
                                  b.Title,
                                  AuthorName = b.Author.Name
                              })
                              .ToList();

                foreach (var book in books) {
                    Console.WriteLine($"タイトル: {book.Title}, 著者: {book.AuthorName}");
                }
            }
        }

        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authorsWithBooks = db.Authors
                    .OrderByDescending(a => a.Birthday) // 誕生日の遅い順にソート
                    .Select(a => new {
                        Author = a,
                        Books = db.Books.Where(b => b.Author.Id == a.Id)
                    })
                    .ToList();

                foreach (var author in authorsWithBooks) {
                    Console.WriteLine($"著者: {author.Author.Name}");
                    foreach (var book in author.Books) {
                        Console.WriteLine($"  タイトル: {book.Title}, 発行年: {book.PublishedYear}");
                    }
                }
            }
        }

        //データの削除
        private static void DeleteBooks() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if(book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }

        //データの変更
        private static void UpdateBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }

        //書籍の追加
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);
                var author3 = db.Authors.Single(a => a.Name == "夏目漱石");
                var book3 = new Book {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = author3,
                };
                db.Books.Add(book3);
                var author4 = db.Authors.Single(a => a.Name == "川端康成");
                var book4 = new Book {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author4,
                };
                db.Books.Add(book4);
                var author5 = db.Authors.Single(a => a.Name == "菊池寛");
                var book5 = new Book {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = author5,
                };
                db.Books.Add(book5);
                var author6 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book6 = new Book {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = author6,
                };
                db.Books.Add(book6);
                db.SaveChanges();
            }
        }

        //著者の追加
        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子",
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治",
                };
                db.Authors.Add(author2);
                var author3 = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛",
                };
                db.Authors.Add(author3);
                var author4 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成",
                };
                db.Authors.Add(author4);
                db.SaveChanges();
            }
        }

        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);

                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();   //データベースを更新

            }
        }

        //テーブルの全表示
        static void DisplayAllBooks() {
            var books = GetBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title},{book.PublishedYear}");
            }
            Console.ReadLine();
        }

        //13.1.2
        static void DisplayAllBooks2() {
            using(var db = new BooksDbContext()) {
                foreach (var book in db.Books.ToList()){
                    Console.WriteLine("{0}{1}{2}({3:yyyy/MM/dd})",
                        book.Title, book.PublishedYear,
                        book.Author.Name,book.Author.Birthday
                    );
                }
            }
        }

        //13.1.3
        static void DisplayAllBooks3() {
            using (var db = new BooksDbContext()) {
                var book = db.Books
                             .Where(b => b.Title.Length == db.Books.Max(x => x.Title.Length));

                foreach (var item in book) {
                    Console.WriteLine(item.Title);
                }
            }
        }


        //データの取得
        static IEnumerable<Book> GetBooks() {
            using(var db = new BooksDbContext()) {
                return db.Books
                        // .Where(book => book.Author.Name.StartsWith("夏目"))
                         .ToList();
            }
        }

    }
}
