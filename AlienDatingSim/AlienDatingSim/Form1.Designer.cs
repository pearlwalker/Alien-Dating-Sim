namespace AlienDatingSim
{
    partial class Form1
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
            this.btnOption1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTextBox = new System.Windows.Forms.Label();
            this.btnOption2 = new System.Windows.Forms.Button();
            this.btnOption3 = new System.Windows.Forms.Button();
            this.btnOption4 = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOption1
            // 
            this.btnOption1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOption1.Location = new System.Drawing.Point(120, 355);
            this.btnOption1.Name = "btnOption1";
            this.btnOption1.Size = new System.Drawing.Size(150, 150);
            this.btnOption1.TabIndex = 0;
            this.btnOption1.Text = "btnOption1";
            this.btnOption1.UseVisualStyleBackColor = true;
            this.btnOption1.Visible = false;
            this.btnOption1.Click += new System.EventHandler(this.btnOption1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AlienDatingSim.Properties.Resources.solarSystem;
            this.pictureBox1.Location = new System.Drawing.Point(239, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTextBox
            // 
            this.lblTextBox.AutoSize = true;
            this.lblTextBox.Location = new System.Drawing.Point(391, 307);
            this.lblTextBox.Name = "lblTextBox";
            this.lblTextBox.Size = new System.Drawing.Size(56, 13);
            this.lblTextBox.TabIndex = 2;
            this.lblTextBox.Text = "lblTextBox";
            // 
            // btnOption2
            // 
            this.btnOption2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOption2.Location = new System.Drawing.Point(276, 355);
            this.btnOption2.Name = "btnOption2";
            this.btnOption2.Size = new System.Drawing.Size(150, 150);
            this.btnOption2.TabIndex = 3;
            this.btnOption2.Text = "btnOption2";
            this.btnOption2.UseVisualStyleBackColor = true;
            this.btnOption2.Visible = false;
            this.btnOption2.Click += new System.EventHandler(this.btnOption2_Click);
            // 
            // btnOption3
            // 
            this.btnOption3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOption3.Location = new System.Drawing.Point(432, 355);
            this.btnOption3.Name = "btnOption3";
            this.btnOption3.Size = new System.Drawing.Size(150, 150);
            this.btnOption3.TabIndex = 4;
            this.btnOption3.Text = "btnOption3";
            this.btnOption3.UseVisualStyleBackColor = true;
            this.btnOption3.Visible = false;
            this.btnOption3.Click += new System.EventHandler(this.btnOption3_Click);
            // 
            // btnOption4
            // 
            this.btnOption4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOption4.Location = new System.Drawing.Point(588, 355);
            this.btnOption4.Name = "btnOption4";
            this.btnOption4.Size = new System.Drawing.Size(150, 150);
            this.btnOption4.TabIndex = 5;
            this.btnOption4.Text = "btnOption4";
            this.btnOption4.UseVisualStyleBackColor = true;
            this.btnOption4.Visible = false;
            this.btnOption4.Click += new System.EventHandler(this.btnOption4_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(12, 12);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(194, 43);
            this.btnStartGame.TabIndex = 6;
            this.btnStartGame.Text = "btnStartGamebtnStartGame";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(624, 75);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(182, 142);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 517);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnOption4);
            this.Controls.Add(this.btnOption3);
            this.Controls.Add(this.btnOption2);
            this.Controls.Add(this.lblTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOption1);
            this.Name = "Form1";
            this.Text = "HoneyMoon";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOption1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTextBox;
        private System.Windows.Forms.Button btnOption2;
        private System.Windows.Forms.Button btnOption3;
        private System.Windows.Forms.Button btnOption4;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

