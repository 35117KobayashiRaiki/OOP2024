using System;
using System.Collections.Generic;

namespace SampleWeightUnitConverter {
    // 重さ単位を表すクラス
    public class WeightUnit {
        public string Name { get; set; }       // 単位名（例: "kg", "g", "lb", "oz"）
        public double Coefficient { get; set; } // 基準単位に対する係数
        public override string ToString() {
            return Name;
        }
    }
}
