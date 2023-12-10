using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public class Wall : Tile
    {
        public Wall(int row, int column) : base(row, column, Map.WallColor)
        {
        }
    }
}
