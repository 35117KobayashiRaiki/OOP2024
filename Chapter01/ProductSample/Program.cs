using SampleApp;
using System;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123,"かりんとう",180);
            Product daifuku = new Product(143, "大福", 192);
            Product dorayaki = new Product(98, "どら焼き", 210);


            int price = karinto.Price;  //税抜きの金額
            int taxIncluded = karinto.GetPriceIncludingTax();   //税込みの金額

            int daifukuprice = daifuku.Price;  //税抜きの金額
            int daifukutaxIncluded = daifuku.GetPriceIncludingTax();   //税込みの金額

            int dorayakiTax = dorayaki.GetTax();   //税込みの金額

            Console.WriteLine(karinto.Name + "の税込金額" +
                                                taxIncluded + "円【税抜き" + price + "円】");

            Console.WriteLine(daifuku.Name + "の税込金額" +
                                                daifukutaxIncluded + "円【税抜き" + daifukuprice + "円】");

            Console.WriteLine($"{dorayakiTax}円");


        }
    }
}
