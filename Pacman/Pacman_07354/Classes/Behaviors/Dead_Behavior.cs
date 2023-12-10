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
    public class Dead_Behavior: IBehavior
    {
        #region Singleton
        private static Dead_Behavior instance = null;
        private Dead_Behavior() { }

        public static Dead_Behavior GetInstance()
        {
            if (instance == null)
            {
                instance = new Dead_Behavior();
            }
            return instance;
        }


        #endregion

        public List<Node> Find_Path(Ghost ghost)
        {
            Ghost_Room random_Tile = Get_Random_Ghost_Room();
            Node goal_Node = new Node(random_Tile.Row, random_Tile.Column, null, null);
            Node ghost_Node = new Node(ghost.Row, ghost.Column, goal_Node, null);

            return AStar_Algorithm.Find_Path(ghost_Node, goal_Node);
        }

        private Ghost_Room Get_Random_Ghost_Room()
        {
            int index = RNG.GetInstance().Next(0, Map.Ghost_Room_List.Count);
            return Map.Ghost_Room_List[index];
        }
    }
}
