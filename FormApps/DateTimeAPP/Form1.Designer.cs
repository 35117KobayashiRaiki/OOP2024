namespace DateTimeAPP {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            dtpDate = new DateTimePicker();
            btDateCount = new Button();
            tbDisp = new TextBox();
            nudDay = new NumericUpDown();
            btDayAfter = new Button();
            btDayBefore = new Button();
            btAge = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(23, 40);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpDate
            // 
            dtpDate.CalendarFont = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(113, 40);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(236, 39);
            dtpDate.TabIndex = 1;
            // 
            // btDateCount
            // 
            btDateCount.Location = new Point(205, 96);
            btDateCount.Name = "btDateCount";
            btDateCount.Size = new Size(144, 70);
            btDateCount.TabIndex = 2;
            btDateCount.Text = "今日までの日数";
            btDateCount.UseVisualStyleBackColor = true;
            btDateCount.Click += btDateCount_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(12, 352);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(383, 39);
            tbDisp.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(23, 223);
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 39);
            nudDay.TabIndex = 4;
            // 
            // btDayAfter
            // 
            btDayAfter.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayAfter.Location = new Point(205, 243);
            btDayAfter.Name = "btDayAfter";
            btDayAfter.Size = new Size(98, 41);
            btDayAfter.TabIndex = 5;
            btDayAfter.Text = "日後";
            btDayAfter.UseVisualStyleBackColor = true;
            btDayAfter.Click += btDayAfter_Click;
            // 
            // btDayBefore
            // 
            btDayBefore.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDayBefore.Location = new Point(205, 186);
            btDayBefore.Name = "btDayBefore";
            btDayBefore.Size = new Size(98, 41);
            btDayBefore.TabIndex = 5;
            btDayBefore.Text = "日前";
            btDayBefore.UseVisualStyleBackColor = true;
            btDayBefore.Click += btDayBefore_Click;
            // 
            // btAge
            // 
            btAge.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btAge.Location = new Point(205, 301);
            btAge.Name = "btAge";
            btAge.Size = new Size(98, 45);
            btAge.TabIndex = 6;
            btAge.Text = "年齢";
            btAge.UseVisualStyleBackColor = true;
            btAge.Click += btAge_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btAge);
            Controls.Add(btDayBefore);
            Controls.Add(btDayAfter);
            Controls.Add(nudDay);
            Controls.Add(tbDisp);
            Controls.Add(btDateCount);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDate;
        private Button btDateCount;
        private TextBox tbDisp;
        private NumericUpDown nudDay;
        private Button btDayAfter;
        private Button btDayBefore;
        private Button btAge;
    }
}
