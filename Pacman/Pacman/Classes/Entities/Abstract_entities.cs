using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Pacman.Classes.Entities
{
    //hiding details or information of this class by changing to abstract
    public abstract class Abstract_entities
    {
        private int row;
        private int column;
        private int score;
        private Color entity_color;

        protected Abstract_entities(int row, int column, int score, Color entity_color)
        {
            this.row = row;
            this.column = column;
            this.score = score;
            this.entity_color = entity_color;
        }
        
        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public int Score { get => score; set => score = value; }
        public Color Entity_color { get => entity_color; set => entity_color = value; }


        //an abstract function is when a function doesn't have a body and an abstract class is where you cannot create an object
        public abstract void Draw(Graphics graphics);

        //Create the background of the game
        public void Draw_Background(Graphics graphics)
        {
            Rectangle myRectangle = this.GetRectangle();
            Brush myBrush = new SolidBrush(Map.BackColor);
            graphics.FillRectangle(myBrush, myRectangle);

            myBrush.Dispose();
        }
        public Rectangle GetRectangle()
        {
            int pointX = this.column * Map.Tile_Size;
            int pointY = this.row * Map.Tile_Size;
            int width = Map.Tile_Size;
            int height = Map.Tile_Size;
            return new Rectangle(pointX, pointY, width, height);
        }

            

    }
  

}
