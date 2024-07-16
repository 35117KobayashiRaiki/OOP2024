namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btVerrsionOk = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btVerrsionOk
            // 
            btVerrsionOk.Location = new Point(341, 40);
            btVerrsionOk.Name = "btVerrsionOk";
            btVerrsionOk.Size = new Size(75, 23);
            btVerrsionOk.TabIndex = 0;
            btVerrsionOk.Text = "OK";
            btVerrsionOk.UseVisualStyleBackColor = true;
            btVerrsionOk.Click += btVerrsionOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(236, 40);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 1;
            label1.Text = "Ver.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 128);
            label2.Location = new Point(12, 34);
            label2.Name = "label2";
            label2.Size = new Size(203, 32);
            label2.TabIndex = 1;
            label2.Text = "CarReportSystem";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(158, 87);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 1;
            label3.Text = "bit edition";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(33, 138);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 1;
            label4.Text = "copyright";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 267);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btVerrsionOk);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "fmVersion";
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btVerrsionOk;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}