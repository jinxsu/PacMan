using Pacman.Classes.Dijkstra;
using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Behaviours
{
    public class Scared : IBehaviour
    {
        #region Singleton
        private static Scared instance = null;
        private Scared() { }

        public static Scared GetInstance()
        {
            if (instance == null)
            {
                instance = new Scared();
            }
            return instance;
        }


        #endregion

        public List<Node> Find_Path(Ghost ghost)
        {
            GhostRoom random_Tile = Get_Random_Ghost_Room();
            Node goal_Node = new Node(random_Tile.Row, random_Tile.Column, null, null);
            Node ghost_Node = new Node(ghost.Row, ghost.Column, goal_Node, null);

            return AStar_Algorithm.Find_Path(ghost_Node, goal_Node);
        }

        private GhostRoom Get_Random_Ghost_Room()
        {
            int index = RNG.Get_Instance().Next(0, Map.ghost_room.Count);
            return Map.ghost_room[index];
        }
    }
}
