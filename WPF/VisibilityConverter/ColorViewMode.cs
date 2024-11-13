using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VisibilityConverter {
    public class ColorViewMode {
        private static IList<ColorViewMode> colors = new List<ColorViewMode> {
            new ColorViewMode{ Name = "赤", Color = Colors.Red },
            new ColorViewMode{ Name = "黄", Color = Colors.Yellow },
            new ColorViewMode{ Name = "青", Color = Colors.Blue },
        };

        public static IList<ColorViewMode> ColorList { get { return colors; } }
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
