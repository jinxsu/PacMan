using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Entities
{
    public class GhostRoom:Tile
    {
        private bool isEmpty;
    
        
        public GhostRoom(int row, int column):base(row, column,Map.BackColor)
        {
            
            IsEmpty = true;
        }

        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
    }
}
