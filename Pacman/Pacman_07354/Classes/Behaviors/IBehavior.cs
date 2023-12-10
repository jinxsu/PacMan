using Pacman_07354.Classes.Djikstra;
using Pacman_07354.Classes.Entities;
//using Pacman_Game.Classes.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Behaviors
{
    public interface IBehavior
    {
        List<Node> Find_Path(Ghost ghost);
    }
}
