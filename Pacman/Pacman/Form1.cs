using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private bool DISPLAY_PATH=false;
        private const int PACMAN_SPEED = 160;
        private const int GHOST_SPEED = 300;
        public Form1()
        {
            InitializeComponent();
            this.Ghost_Timer.Interval = GHOST_SPEED;
            this.PacMan_Timer.Interval = PACMAN_SPEED;
            
            GameManager.StartGame();
            
            this.pictureBox_Map.Width = Map.Max_Columns * Map.Tile_Size;
            this.pictureBox_Map.Height = Map.Max_Rows * Map.Tile_Size;

            int width=this.pictureBox_Map.Width;
            int height = this.pictureBox_Map.Height + this.pictureBox_Map.Location.Y;
            this.pictureBox_Map.Location = new Point(0, 60);
            this.ClientSize = new Size(width, height+60);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_Map_Paint(object sender, PaintEventArgs e)
        {
            foreach(Abstract_entities obj in Map.abstract_Entities)
            {
                obj.Draw(e.Graphics);

            }
            foreach(Ghost obj in GameManager.Ghost_List)
            {
                obj.Draw(e.Graphics);
            }
            //draw path
            if(DISPLAY_PATH)
            {
                foreach(Ghost obj in GameManager.Ghost_List)
                {
                    obj.Draw_Path(e.Graphics);
                }
            }
            GameManager.Player.Draw(e.Graphics);
        
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    GameManager.Player.CurrentDirection = Direction.UP;
                    break;
                case Keys.Down:
                case Keys.S:
                    GameManager.Player.CurrentDirection = Direction.DOWN;
                    break;
                case Keys.Right:
                case Keys.D:
                    GameManager.Player.CurrentDirection = Direction.RIGHT;
                    break;
                case Keys.Left:
                case Keys.A:
                    GameManager.Player.CurrentDirection = Direction.LEFT;
                    break;
            }
            this.Refresh();
        }


        private void Hint_Click(object sender, EventArgs e)
        {
            if(!DISPLAY_PATH)
            {
                DISPLAY_PATH = true;
            }
            else
            {
                DISPLAY_PATH=false;
            }
        }

        private void Ghost_Timer_Tick(object sender, EventArgs e)
        {
            if(!GameManager.IsGameWinner&&!GameManager.IsGameOver)
            {
                foreach(Ghost obj in GameManager.Ghost_List)
                {
                    obj.Move();
                }
                this.Refresh();
            }
        }

        private void PacMan_Timer_Tick(object sender, EventArgs e)
        {
            if(!GameManager.IsGameWinner&&!GameManager.IsGameOver)
            {
                GameManager.Player.Move();
                GameManager.Player.Check_Boost_Time();
                this.Counter_Lives.Text = GameManager.Player.Lives.ToString();
                this.Counter_Score.Text = GameManager.Player.Score.ToString();
                this.Refresh();
            }
        }

        private void Collision_Timer_Tick(object sender, EventArgs e)
        {
            if(!GameManager.IsGameWinner&&!GameManager.IsGameOver)
            {
                GameManager.Player.Check_Ghost_Collision();
            }
        }
    }
}
