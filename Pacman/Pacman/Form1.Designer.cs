namespace Pacman
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox_Map = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Counter_Score = new System.Windows.Forms.Label();
            this.Lives = new System.Windows.Forms.Label();
            this.Counter_Lives = new System.Windows.Forms.Label();
            this.Hint = new System.Windows.Forms.Label();
            this.Ghost_Timer = new System.Windows.Forms.Timer(this.components);
            this.PacMan_Timer = new System.Windows.Forms.Timer(this.components);
            this.Collision_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Map
            // 
            this.pictureBox_Map.Location = new System.Drawing.Point(0, 90);
            this.pictureBox_Map.Name = "pictureBox_Map";
            this.pictureBox_Map.Size = new System.Drawing.Size(289, 204);
            this.pictureBox_Map.TabIndex = 0;
            this.pictureBox_Map.TabStop = false;
            this.pictureBox_Map.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Map_Paint);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Score.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.Yellow;
            this.Score.Location = new System.Drawing.Point(42, 24);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(97, 33);
            this.Score.TabIndex = 1;
            this.Score.Text = "Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // Counter_Score
            // 
            this.Counter_Score.AutoSize = true;
            this.Counter_Score.BackColor = System.Drawing.Color.Black;
            this.Counter_Score.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counter_Score.ForeColor = System.Drawing.Color.Yellow;
            this.Counter_Score.Location = new System.Drawing.Point(136, 24);
            this.Counter_Score.Name = "Counter_Score";
            this.Counter_Score.Size = new System.Drawing.Size(31, 33);
            this.Counter_Score.TabIndex = 3;
            this.Counter_Score.Text = "0";
            // 
            // Lives
            // 
            this.Lives.AutoSize = true;
            this.Lives.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lives.ForeColor = System.Drawing.Color.Fuchsia;
            this.Lives.Location = new System.Drawing.Point(305, 24);
            this.Lives.Name = "Lives";
            this.Lives.Size = new System.Drawing.Size(87, 33);
            this.Lives.TabIndex = 4;
            this.Lives.Text = "lives";
            // 
            // Counter_Lives
            // 
            this.Counter_Lives.AutoSize = true;
            this.Counter_Lives.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counter_Lives.ForeColor = System.Drawing.Color.Fuchsia;
            this.Counter_Lives.Location = new System.Drawing.Point(389, 24);
            this.Counter_Lives.Name = "Counter_Lives";
            this.Counter_Lives.Size = new System.Drawing.Size(31, 33);
            this.Counter_Lives.TabIndex = 5;
            this.Counter_Lives.Text = "0";
            // 
            // Hint
            // 
            this.Hint.AutoSize = true;
            this.Hint.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hint.ForeColor = System.Drawing.Color.DarkViolet;
            this.Hint.Location = new System.Drawing.Point(531, 24);
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(81, 33);
            this.Hint.TabIndex = 6;
            this.Hint.Text = "Hint";
            this.Hint.Click += new System.EventHandler(this.Hint_Click);
            // 
            // Ghost_Timer
            // 
            this.Ghost_Timer.Enabled = true;
            this.Ghost_Timer.Interval = 300;
            this.Ghost_Timer.Tick += new System.EventHandler(this.Ghost_Timer_Tick);
            // 
            // PacMan_Timer
            // 
            this.PacMan_Timer.Enabled = true;
            this.PacMan_Timer.Interval = 160;
            this.PacMan_Timer.Tick += new System.EventHandler(this.PacMan_Timer_Tick);
            // 
            // Collision_Timer
            // 
            this.Collision_Timer.Enabled = true;
            this.Collision_Timer.Interval = 10;
            this.Collision_Timer.Tick += new System.EventHandler(this.Collision_Timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Hint);
            this.Controls.Add(this.Counter_Lives);
            this.Controls.Add(this.Lives);
            this.Controls.Add(this.Counter_Score);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.pictureBox_Map);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Map;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Counter_Score;
        private System.Windows.Forms.Label Lives;
        private System.Windows.Forms.Label Counter_Lives;
        private System.Windows.Forms.Label Hint;
        private System.Windows.Forms.Timer Ghost_Timer;
        private System.Windows.Forms.Timer PacMan_Timer;
        private System.Windows.Forms.Timer Collision_Timer;
    }
}

