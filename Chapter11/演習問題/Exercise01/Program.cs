using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            //          var sports = xdoc.Elements()
            //                             .Select(x => new {
            //                                 Name = x.Element("name").Value,
            //                                 Temmembers = x.Element("teammembers").Value,
            //                             });
            //          foreach (var sport in sports){
            //              Console.WriteLine("{0} {1}",sport.Name,sport.Temmembers);

            foreach (var sport in xdoc.Root.Elements("ballsport")) {
                var name = sport.Element("name").Value;
                var teamMembers = sport.Element("teammembers").Value;

                Console.WriteLine("{0}{1}",name, teamMembers);
            }
        
        }

        private static void Exercise1_2(string file) {
           
        }

        private static void Exercise1_3(string file) {
            
        }

        private static void Exercise1_4(string file, string newfile) {
            
        }
    }
}
