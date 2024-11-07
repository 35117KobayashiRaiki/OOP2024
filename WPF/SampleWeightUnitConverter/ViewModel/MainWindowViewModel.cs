using SampleWeightUnitConverter;
using SampleWeightUnitConverterr;
using System.Linq;
using System.Windows.Input;

namespace SampleWeightUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double gramValue, poundValue;

        // ▲ボタンで呼ばれるコマンド
        public ICommand PoundUnitToGram { get; private set; }

        // ▼ボタンで呼ばれるコマンド
        public ICommand GramToPoundUnit { get; private set; }

        // 上のComboBoxで選択されている値（グラム単位）
        public GramUnit CurrentGramUnit { get; set; }

        // 下のComboBoxで選択されている値（ポンド単位）
        public PoundUnit CurrentPoundUnit { get; set; }

        public double GramValue {
            get { return gramValue; }
            set {
                gramValue = value;
                OnPropertyChanged(); // 値が変更されたら通知
            }
        }

        public double PoundValue {
            get { return poundValue; }
            set {
                poundValue = value;
                OnPropertyChanged(); // 値が変更されたら通知
            }
        }

        // コンストラクタ
        public MainWindowViewModel() {
            // 最初に選択する単位を設定
            CurrentGramUnit = GramUnit.Units.First();
            CurrentPoundUnit = PoundUnit.Units.First();

            // グラム単位からポンド単位へ変換するコマンド
            PoundUnitToGram = new DelegateCommand(
                () => PoundValue = CurrentPoundUnit.FromGramUnit(CurrentGramUnit, GramValue));

            // ポンド単位からグラム単位へ変換するコマンド
            GramToPoundUnit = new DelegateCommand(
                () => GramValue = CurrentGramUnit.FromPoundUnit(CurrentPoundUnit, PoundValue));
        }
    }
}
