using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Entities
{
    public class Tile: Abstract_entities
    {
        public Tile(int row, int column, Color entity_color):base(row, column, 0, entity_color)
        {

        }
        public override void Draw(Graphics graphics)
        {
            Rectangle myRectangle = base.GetRectangle();
            Brush myBrush=new SolidBrush(base.Entity_color);
            graphics.FillRectangle(myBrush, myRectangle);
            myBrush.Dispose();
        }
    }
    
}
