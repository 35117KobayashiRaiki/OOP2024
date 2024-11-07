using SampleWeightUnitConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    // ポンド単位を表すクラス
    public class PoundUnit : WeightUnit {
        private static List<PoundUnit> units = new List<PoundUnit> {
            new PoundUnit { Name = "oz", Coefficient = 1, }, // 1oz = 28.3495g
            new PoundUnit { Name = "lb", Coefficient = 16, }, // 1lb = 453.592g
        };

        public static ICollection<PoundUnit> Units { get { return units; } }

        /// <summary>
        /// グラム単位からポンド単位へ変換します
        /// </summary>
        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 28.35 / Coefficient;
        }
    }
}
