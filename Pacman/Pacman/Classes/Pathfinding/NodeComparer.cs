using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Pathfinding
{
    public class NodeComparer : IComparer
    {
        private static NodeComparer instance = null;

        private NodeComparer() { }
        public static NodeComparer Get_Instance()
        {
            if (instance == null)
            {
                instance = new NodeComparer();
            }
            return instance;
        }


        public int Compare(object x, object y)
        {

            //for A* Algorithm, we include the Heuristic values
            return ((Node)x).Total_Cost - ((Node)y).Total_Cost;

        }

    }
}
