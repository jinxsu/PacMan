using Pacman.Classes.Entities;
using Pacman.Classes.Dijkstra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pacman.Classes.Behaviours
{
    public interface IBehaviour
    {
        List<Node> Find_Path(Ghost ghost);
    }
}
