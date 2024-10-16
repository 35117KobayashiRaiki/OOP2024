using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using TextNumberSizeChange.Framework;

namespace TextNumberSizeChange {
    class ToHankakuProcessor : ITextFileService{

        //private int _count;
        private string _text = "";

        public void Initialize(string fname) {
            //_count = 0;
            _text = "";
        }

        public void Execute(string line) {
            string convertedLine = ConvertFullWidthToHalfWidth(line);
            Console.WriteLine(convertedLine);
            _text += convertedLine + Environment.NewLine; 
            //_count++;
        }

        public void Terminate() {
            //Console.WriteLine("{0}行", _count);
            Console.WriteLine(_text);
        }

        // 全角数字を半角数字に変換するメソッド
        private string ConvertFullWidthToHalfWidth(string input) {
            char[] fullWidthDigits = { '０', '１', '２', '３', '４', '５', '６', '７', '８', '９' };
            char[] halfWidthDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < fullWidthDigits.Length; i++) {
                input = input.Replace(fullWidthDigits[i], halfWidthDigits[i]);
            }

            return input;
        }
    }
}
