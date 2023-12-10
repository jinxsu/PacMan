using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman_07354.Classes.Entities;

namespace Pacman_07354
{
    public partial class Form_Main : Form
    {
        private bool DISPLAY_PATH = false;
        private const int PACMAN_SPEED = 160;//milliseconds
        private const int GHOST_SPEED = 300;//milliseconds
        public Form_Main()
        {
            InitializeComponent();

            this.Timer_Ghost.Interval = GHOST_SPEED;
            this.Timer_Pacman.Interval = PACMAN_SPEED;
            Game_Manager.Start_Game();

            int width = Map.Max_Columns * Map.Tile_Size;
            int height = Map.Max_Rows * Map.Tile_Size;
            this.pictureBox1.Width = width;
            this.pictureBox1.Height = height;
            this.pictureBox1.Location = new Point(0, 60);
            this.ClientSize = new Size (width, height + 60);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Abstract_Entity obj in Map.Array_Entities)
            {
                obj.Draw(e.Graphics);
            }
            foreach(Ghost obj in Game_Manager.Ghost_List)
            {
                obj.Draw(e.Graphics);
            }
            //Draw the path 
            if (DISPLAY_PATH)
            {
                foreach (Ghost obj in Game_Manager.Ghost_List)
                {
                    obj.Draw_Path(e.Graphics);
                }
            }
            
            Game_Manager.Player.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    Game_Manager.Player.Current_Direction = Direction.UP;
                    break;
                case Keys.Right:
                case Keys.D:
                    Game_Manager.Player.Current_Direction = Direction.RIGHT;
                    break;
                case Keys.Left:
                case Keys.A:
                    Game_Manager.Player.Current_Direction = Direction.LEFT;
                    break;
                case Keys.Down:
                case Keys.S:
                    Game_Manager.Player.Current_Direction = Direction.DOWN;
                    break;
            }

            this.Refresh();//Call Paint event
        }

        private void timer_Ghost_Tick(object sender, EventArgs e)
        {
            if (!Game_Manager.IsGameOver && !Game_Manager.IsGameWinner)
            {
                foreach (Ghost obj in Game_Manager.Ghost_List)
                {
                    obj.Move();
                }
                this.Refresh();//Call Paint event
            }
                
        }

        private void pictureBox_Hint_Click(object sender, EventArgs e)
        {
            DISPLAY_PATH = !DISPLAY_PATH;
        }

        private void label_Hint_Click(object sender, EventArgs e)
        {
            DISPLAY_PATH = !DISPLAY_PATH;
        }

        private void Timer_Pacman_Tick(object sender, EventArgs e)
        {
            if (!Game_Manager.IsGameOver && !Game_Manager.IsGameWinner)
            {
                Game_Manager.Player.Move();
                Game_Manager.Player.Check_Boost_Time();
                this.label_Lives.Text = Game_Manager.Player.Lives.ToString();
                this.label_Score.Text = Game_Manager.Player.Score.ToString();
                this.Refresh();//Call Paint event
            }
                
        }

        private void Timer_Collision_Tick(object sender, EventArgs e)
        {
            if (!Game_Manager.IsGameOver && !Game_Manager.IsGameWinner)
            {
                Game_Manager.Player.Check_Ghost_Collision();
            }
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }
    }
}
