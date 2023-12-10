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
    public class Follow_Behavior: IBehavior
    {
        #region Singleton
        private static Follow_Behavior instance = null;
        private Follow_Behavior() { }

        public static Follow_Behavior GetInstance()
        {
            if (instance == null)
            {
                instance = new Follow_Behavior();
            }
            return instance;
        }

        #endregion

        public List<Node> Find_Path(Ghost ghost)
        {
            Node pacMan_Node = new Node(Game_Manager.Player.Row, Game_Manager.Player.Column, null, null);
            Node ghost_Node = new Node(ghost.Row, ghost.Column, pacMan_Node, null);

            return AStar_Algorithm.Find_Path(ghost_Node, pacMan_Node);
           
        }
    }
}
