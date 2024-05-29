﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
             };

            var query = names.Where(s => s.Length <= 5).ToList();
            foreach (var item in query){
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------");

            names[0] = "Osake";
            foreach (var item in query){
                Console.WriteLine(item);
            }

        }
    }
}