using Pacman_07354.Classes.Entities;
//using Pacman_Game.Classes.Pathfinding;
using Pacman_07354.Classes.Djikstra;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_07354.Classes.Behaviors
{
    public class Random_Behavior: IBehavior
    {
        #region Singleton
        private static Random_Behavior instance = null;
        private Random_Behavior() { }

        public static Random_Behavior GetInstance()
        {
            if (instance == null)
            {
                instance = new Random_Behavior();
            }
            return instance;
        }


        #endregion
        public List<Node> Find_Path(Ghost ghost)
        {
            Empty_Tile random_Tile = Get_Random_Empty_Tile();
            Node goal_Node = new Node(random_Tile.Row, random_Tile.Column, null, null);
            Node ghost_Node = new Node(ghost.Row, ghost.Column, goal_Node, null);

            return AStar_Algorithm.Find_Path(ghost_Node, goal_Node);
        }

        private Empty_Tile Get_Random_Empty_Tile() {

            int index = RNG.GetInstance().Next(0, Map.Empty_Tiles_List.Count);
            return Map.Empty_Tiles_List[index];
        }

    }
}
