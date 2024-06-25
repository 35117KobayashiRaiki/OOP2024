namespace DateTimeAPP {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDateCount_Click(object sender, EventArgs e) {

            var today = DateTime.Today;

            TimeSpan diff = today - dtpDate.Value;

            //tbDisp.Text = "››“ú–Ú";
            tbDisp.Text = (diff.Days + 1) + "“ú–Ú";
        }

        private void btDayBefore_Click(object sender, EventArgs e) {
            var pass = dtpDate.Value.AddDays(-(double)nudDay.Value);
            tbDisp.Text = pass.ToString();
        }

        private void btDayAfter_Click(object sender, EventArgs e) {
            var future = dtpDate.Value.AddDays((double)nudDay.Value);
            tbDisp.Text = future.ToString();
        }

        private void btAge_Click(object sender, EventArgs e) {
            var birthday = dtpDate.Value;
            var today = DateTime.Today;
            int age = GetAge(birthday, today);
            tbDisp.Text = age.ToString();
        }

        public static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age).AddDays(-1)) {
                age--;
            }
            return age;
        }
    }
}
