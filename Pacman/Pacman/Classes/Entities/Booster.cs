using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Entities
{
    public class Booster:Abstract_entities
    {
        public Booster(int row, int column) : base(row, column, 50, Color.White)
        {

        }
        public override void Draw(Graphics graphics)
        {
            base.Draw_Background(graphics);

            int pointX = (base.Column * Map.Tile_Size) + ( Map.Tile_Size / 4);
            int pointY = (base.Row * Map.Tile_Size) + (Map.Tile_Size / 4);
            int width = Map.Tile_Size / 2;
            int height = Map.Tile_Size / 2;

            Rectangle circleRectangle = new Rectangle(pointX, pointY, width, height);
            Brush myBrush = new SolidBrush(base.Entity_color);
            graphics.FillEllipse(myBrush, circleRectangle);

            myBrush.Dispose();
        }

    }
}
