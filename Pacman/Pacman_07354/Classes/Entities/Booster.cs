using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public class Booster : Abstract_Entity
    {
        public Booster(int row, int column) : base(row, column, 50, Color.White)
        {
        }

        public override void Draw(Graphics g)
        {
            //Draw the background
            base.Draw_Background(g);

            //Draw the Circle
            int PointX = (base.Column * Map.Tile_Size) + (Map.Tile_Size / 4);
            int PointY = (base.Row * Map.Tile_Size) + (Map.Tile_Size / 4);
            int width = Map.Tile_Size / 2;
            int height = Map.Tile_Size / 2;
            Rectangle myBounds = new Rectangle(PointX, PointY, width, height);
            Brush myBrush = new SolidBrush(base.Entity_Color);
            g.FillEllipse(myBrush, myBounds);

            //Release the memory
            myBrush.Dispose();

        }
    }
}
