using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var xdoc = XDocument.Load("novelists.xml");
            var xelements = xdoc.Root.Descendants("title");
                //.OrderByDescending(e => (DateTime)e.Element("birth"));
                //.Where(x=>((DateTime)x.Element("birth")).Year >= 1900);


            //foreach (var xnovelist in xelements){
              //  var xname = xnovelist.Element("name");  //要素の取得
                //var xkana = xname.Attribute("kana");    //属性の取得
                //var xwork = xnovelist.Element("masterpieces")
                  //                      .Elements("title")
                    //                    .Select(x => x.Value);

                //Console.WriteLine("{0} - {1}",xname.Value,string.Join(",",xwork));
            //}

        }
    }
}
