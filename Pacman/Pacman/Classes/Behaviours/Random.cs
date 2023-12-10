using Pacman.Classes.Dijkstra;
using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Behaviours
{
    public class Random : IBehaviour
    {
        #region Singleton
        private static Random instance = null;
        private Random() { }

        public static Random GetInstance()
        {
            if (instance == null)
            {
                instance = new Random();
            }
            return instance;
        }


        #endregion

        public List<Node> Find_Path(Ghost ghost)
        {
            EmptyTile random_Tile = Get_Random_Empty_Tile();
            Node goal_Node = new Node(random_Tile.Row, random_Tile.Column, null, null);
            Node ghost_Node = new Node(ghost.Row, ghost.Column, goal_Node, null);

            return AStar_Algorithm.Find_Path(ghost_Node, goal_Node);
        }

        private EmptyTile Get_Random_Empty_Tile()
        {

            int index = RNG.Get_Instance().Next(0, Map.empty_tile.Count);
            return Map.empty_tile[index];
        }
    }
}
