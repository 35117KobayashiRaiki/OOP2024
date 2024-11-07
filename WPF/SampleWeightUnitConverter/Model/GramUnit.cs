using SampleWeightUnitConverter;
using System.Collections.Generic;

namespace SampleWeightUnitConverter {
    // グラム単位を表すクラス
    public class GramUnit : WeightUnit {
        private static List<GramUnit> units = new List<GramUnit> {
            new GramUnit { Name = "g", Coefficient = 1, }, // 基本単位
            new GramUnit { Name = "kg", Coefficient = 1000, }, // 1kg = 1000g
        };

        public static ICollection<GramUnit> Units { get { return units; } }

        /// <summary>
        /// ポンド単位からグラム単位へ変換します
        /// </summary>
        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) * 28.35 / Coefficient;
        }
    }
}
