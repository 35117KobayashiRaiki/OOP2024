﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom") {
                PrintFeetToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            } else {
                PrintMeterToFeetList(int.Parse(args[1]), int.Parse(args[2]));
            }

        }

        //フィートからメートルへの対応表を出力
        private static void PrintFeetToMeterList(int start, int stop) {  
            for (int feet = 1; feet <= stop; feet++) {
                double meter = FeetConverter.ToMeter(feet);
                Console.WriteLine("{0}ft = {1:0.0000}m", feet, meter);
            }
        }

        //メートルからフィートへの対応表を出力
        private static void PrintMeterToFeetList(int start, int stop) {
            for (int meter = 1; meter <= stop; meter++) {
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine("{0}m = {1:0.0000}ft", meter, feet);
            }
        }
    }
}
