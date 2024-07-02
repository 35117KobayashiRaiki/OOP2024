using System.ComponentModel;
using System.Data;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        private void btAddReport_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

        }

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return CarReport.MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return CarReport.MakerGroup.日産;
            if (rbHonda.Checked)
                return CarReport.MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return CarReport.MakerGroup.スバル;
            if (rbImport.Checked)
                return CarReport.MakerGroup.輸入車;
            if (rbOther.Checked)
                return CarReport.MakerGroup.その他;

            return CarReport.MakerGroup.その他;
        }

        //選択されているメーカー名を列挙型で返す
        private void setRadioButtoMaker(CarReport.MakerGroup targetMaker) {

            switch (targetMaker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbImport.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;  //画像表示しない
        }

        private void dgvCarReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.Rows.Count == 0) return;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
            setRadioButtoMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;

        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            //if (dgvCarReport.CurrentRow != null) {
                //CarReport selectedReport = (CarReport)dgvCarReport.CurrentRow.DataBoundItem;
                //listCarReports.Remove(selectedReport);

            //}
        }

        private void btModifyReport_Click(object sender, EventArgs e) {
            CarReport selectedReport = listCarReports[dgvCarReport.CurrentRow.Index];

            selectedReport.Date = dtpDate.Value;
            selectedReport.Author = cbAuthor.Text;
            selectedReport.Maker = GetRadioButtonMaker();
            selectedReport.CarName = cbCarName.Text;
            selectedReport.Report = tbReport.Text;
            selectedReport.Picture = pbPicture.Image;

            dgvCarReport.Refresh(); //データグリッドビューの更新
        }
    }
}
