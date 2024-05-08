namespace BallApp {
    public partial class Form1 : Form {
        Obj ball;
        PictureBox pb;

        //コンストラクタ
        public Form1() {
            InitializeComponent();

        }

        //フォームが最初にロードされるとき一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {

            ball.Move();
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {

            pb = new PictureBox();   //画像を表示するコントロール
            pb.Size = new Size(50, 50);

            if (e.Button == MouseButtons.Left) {
                ball = new SoccerBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(50, 50);

            } else if (e.Button == MouseButtons.Right) {
                ball = new TennisBall(e.X - 12, e.Y - 12);
                pb.Size = new Size(25, 25);

            }
            pb.Image = ball.Image;
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;
            timer1.Start();
        }
    }
}
