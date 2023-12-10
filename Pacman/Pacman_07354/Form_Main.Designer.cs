namespace Pacman_07354
{
    partial class Form_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Timer_Ghost = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_Score = new System.Windows.Forms.Label();
            this.label_Lives = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_Hint = new System.Windows.Forms.PictureBox();
            this.label_Hint = new System.Windows.Forms.Label();
            this.Timer_Pacman = new System.Windows.Forms.Timer(this.components);
            this.Timer_Collision = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hint)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 265);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Timer_Ghost
            // 
            this.Timer_Ghost.Enabled = true;
            this.Timer_Ghost.Interval = 300;
            this.Timer_Ghost.Tick += new System.EventHandler(this.timer_Ghost_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score";
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Score.ForeColor = System.Drawing.Color.Yellow;
            this.label_Score.Location = new System.Drawing.Point(116, 13);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(31, 33);
            this.label_Score.TabIndex = 2;
            this.label_Score.Text = "0";
            // 
            // label_Lives
            // 
            this.label_Lives.AutoSize = true;
            this.label_Lives.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Lives.ForeColor = System.Drawing.Color.Red;
            this.label_Lives.Location = new System.Drawing.Point(374, 13);
            this.label_Lives.Name = "label_Lives";
            this.label_Lives.Size = new System.Drawing.Size(31, 33);
            this.label_Lives.TabIndex = 4;
            this.label_Lives.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(271, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lives";
            // 
            // pictureBox_Hint
            // 
            this.pictureBox_Hint.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Hint.Image")));
            this.pictureBox_Hint.Location = new System.Drawing.Point(472, 4);
            this.pictureBox_Hint.Name = "pictureBox_Hint";
            this.pictureBox_Hint.Size = new System.Drawing.Size(42, 42);
            this.pictureBox_Hint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Hint.TabIndex = 5;
            this.pictureBox_Hint.TabStop = false;
            this.pictureBox_Hint.Click += new System.EventHandler(this.pictureBox_Hint_Click);
            // 
            // label_Hint
            // 
            this.label_Hint.AutoSize = true;
            this.label_Hint.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hint.ForeColor = System.Drawing.Color.Gold;
            this.label_Hint.Location = new System.Drawing.Point(520, 13);
            this.label_Hint.Name = "label_Hint";
            this.label_Hint.Size = new System.Drawing.Size(81, 33);
            this.label_Hint.TabIndex = 1;
            this.label_Hint.Text = "HINT";
            this.label_Hint.Click += new System.EventHandler(this.label_Hint_Click);
            // 
            // Timer_Pacman
            // 
            this.Timer_Pacman.Enabled = true;
            this.Timer_Pacman.Interval = 160;
            this.Timer_Pacman.Tick += new System.EventHandler(this.Timer_Pacman_Tick);
            // 
            // Timer_Collision
            // 
            this.Timer_Collision.Enabled = true;
            this.Timer_Collision.Interval = 10;
            this.Timer_Collision.Tick += new System.EventHandler(this.Timer_Collision_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox_Hint);
            this.Controls.Add(this.label_Lives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.label_Hint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_Main";
            this.Text = "PacMan Game 2021";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer Timer_Ghost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Score;
        private System.Windows.Forms.Label label_Lives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox_Hint;
        private System.Windows.Forms.Label label_Hint;
        private System.Windows.Forms.Timer Timer_Pacman;
        private System.Windows.Forms.Timer Timer_Collision;
    }
}

