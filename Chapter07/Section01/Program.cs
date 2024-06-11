using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> employeeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            String todou, kentyo;

            //入力処理
            Console.WriteLine("県庁所在地の登録");
            while (true) {
                //都道府県の入力
                Console.Write("都道府県   : ");
                todou = Console.ReadLine();

                if (todou == null) {
                    break;
                }

                //県庁所在地の入力
                Console.Write("県庁所在地 : ");
                kentyo = Console.ReadLine();

                //既に都道府県が登録されているか
                if (employeeDict.ContainsKey(todou)) {
                    //登録済み
                    Console.WriteLine("上書きしますか？(y/n)");
                    if (Console.ReadLine() == "n") {
                        continue;  //上書きする
                    } 
                }
                employeeDict[todou] = kentyo;
            }
            Console.WriteLine();    //改行

            Boolean endFlg = false; //終了フラグ(無限ループを抜け出す用)
            while (!endFlg) {
                switch (menuDisp()) {
                    case "1":
                        allDisplay();
                        break;

                    case "2":
                        searchPref();
                        break;

                    case "9":
                        endFlg = true;
                        break;
                }
            }
        }

        //都道府県の入力
        private static void searchPref() {
            Console.Write("都道府県   : ");
            var searcTodou = Console.ReadLine();
            Console.WriteLine($"{searcTodou}の県庁所在地は{employeeDict[searcTodou]}です");
        }

        //一覧出力処理
        private static void allDisplay() {
            foreach (var item in employeeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です");
            }
        }

        //メニュー表示
        private static string menuDisp() {
            Console.WriteLine("**** メニュー ****");
            Console.WriteLine("1 :一覧表示");
            Console.WriteLine("2 :検索");
            Console.WriteLine("9 :終了");
            Console.Write(">");
            string menuSelect = Console.ReadLine();
            return menuSelect;
        }
    }
}
