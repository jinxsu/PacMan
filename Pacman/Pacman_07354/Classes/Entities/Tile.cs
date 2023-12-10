using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public class Tile : Abstract_Entity
    {
        public Tile(int row, int column, Color entity_Color) : base(row, column, 0, entity_Color)
        {
        }

        public override void Draw(Graphics g)
        {
            Rectangle myRectangle = base.GetRectangle();
            Brush myBrush = new SolidBrush(base.Entity_Color);
            g.FillRectangle(myBrush, myRectangle);

            //Release the memory
            myBrush.Dispose();
        }
    }
}
