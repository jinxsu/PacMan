using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.States
{
    public interface iState
    {
        bool Eatable(Ghost ghost);
        void Ghost_Collision(Ghost ghost, Entities.Pacman player);
    }
}
