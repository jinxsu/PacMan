using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Entities
{
    public class Ghost_Room : Tile
    {
        private bool isEmpty;
        public Ghost_Room(int row, int column) : base(row, column, Map.BackColor)
        {
            isEmpty = true;
        }

        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    }
}
