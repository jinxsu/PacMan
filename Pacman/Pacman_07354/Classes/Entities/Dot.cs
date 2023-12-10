﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public class Dot : Abstract_Entity
    {
        public Dot(int row, int column) : base(row, column, 10, Color.White)
        {
        }

        public override void Draw(Graphics g)
        {
            //Draw the background
            base.Draw_Background(g);

            //Draw the circle
            int pointX = (base.Column * Map.Tile_Size) + ( 2 * Map.Tile_Size) / 5;
            int pointY = (base.Row * Map.Tile_Size) + (2 * Map.Tile_Size) / 5;
            int width  = Map.Tile_Size / 5;
            int height = Map.Tile_Size / 5;
            Rectangle myBounds = new Rectangle(pointX, pointY, width, height);
            Brush myBrush = new SolidBrush(base.Entity_Color);
            g.FillEllipse(myBrush, myBounds);

            //Release memory
            myBrush.Dispose();
        }
    }
}
