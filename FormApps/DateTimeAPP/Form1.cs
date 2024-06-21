namespace DateTimeAPP {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {


            //tbDisp.Text = "››“ú–Ú";
            tbDisp.Text = dtpBirthday.Value.ToString("d");
        }
    }
}
