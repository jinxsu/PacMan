namespace Pacman
{
    partial class Form_Exit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Exit));
            this.Exit = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.Red;
            this.Exit.Location = new System.Drawing.Point(29, 304);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(170, 94);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Restart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Restart.BackgroundImage")));
            this.Restart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Restart.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Restart.ForeColor = System.Drawing.Color.Lime;
            this.Restart.Location = new System.Drawing.Point(231, 304);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(208, 94);
            this.Restart.TabIndex = 1;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Pacman.Properties.Resources.Title;
            this.pictureBox1.Location = new System.Drawing.Point(33, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Yellow;
            this.Title.Location = new System.Drawing.Point(8, 175);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(449, 93);
            this.Title.TabIndex = 1;
            this.Title.Text = "Title";
            // 
            // Form_Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.Exit);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Form_Exit";
            this.Text = "Form_Exit";
            this.Load += new System.EventHandler(this.Form_Exit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Title;
    }
}