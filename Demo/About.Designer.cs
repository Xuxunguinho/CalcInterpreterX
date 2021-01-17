namespace Demo
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Demo.Ui.CornersProperty cornersProperty4 = new Demo.Ui.CornersProperty();
            Demo.Ui.CornersProperty cornersProperty5 = new Demo.Ui.CornersProperty();
            Demo.Ui.CornersProperty cornersProperty6 = new Demo.Ui.CornersProperty();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.header = new Demo.TextView();
            this.txtAbout = new Demo.TextView();
            this.textView1 = new Demo.TextView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Demo.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(27, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // header
            // 
            this.header.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            cornersProperty4.All = 1;
            cornersProperty4.LowerLeft = 1;
            cornersProperty4.LowerRight = 1;
            cornersProperty4.UpperLeft = 1;
            cornersProperty4.UpperRight = 1;
            this.header.Corners = cornersProperty4;
            this.header.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(93, 35);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(302, 55);
            this.header.TabIndex = 1;
            this.header.Text = "AlgoritmX";
            this.header.TextAligment = System.Drawing.StringAlignment.Near;
            this.header.UseBorder = false;
            // 
            // txtAbout
            // 
            this.txtAbout.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            cornersProperty5.All = 1;
            cornersProperty5.LowerLeft = 1;
            cornersProperty5.LowerRight = 1;
            cornersProperty5.UpperLeft = 1;
            cornersProperty5.UpperRight = 1;
            this.txtAbout.Corners = cornersProperty5;
            this.txtAbout.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtAbout.Location = new System.Drawing.Point(12, 108);
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.Size = new System.Drawing.Size(441, 225);
            this.txtAbout.TabIndex = 1;
            this.txtAbout.Text = "AlgoritmX";
            this.txtAbout.TextAligment = System.Drawing.StringAlignment.Near;
            this.txtAbout.UseBorder = false;
            // 
            // textView1
            // 
            this.textView1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            cornersProperty6.All = 1;
            cornersProperty6.LowerLeft = 1;
            cornersProperty6.LowerRight = 1;
            cornersProperty6.UpperLeft = 1;
            cornersProperty6.UpperRight = 1;
            this.textView1.Corners = cornersProperty6;
            this.textView1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textView1.Location = new System.Drawing.Point(94, 12);
            this.textView1.Name = "textView1";
            this.textView1.Size = new System.Drawing.Size(302, 33);
            this.textView1.TabIndex = 1;
            this.textView1.Text = "AlgoritmX © 2019";
            this.textView1.TextAligment = System.Drawing.StringAlignment.Near;
            this.textView1.UseBorder = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(240)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(460, 339);
            this.Controls.Add(this.header);
            this.Controls.Add(this.txtAbout);
            this.Controls.Add(this.textView1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private TextView header;
        private TextView txtAbout;
        private TextView textView1;
    }
}