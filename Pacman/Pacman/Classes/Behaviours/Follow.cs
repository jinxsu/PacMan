using Pacman.Classes.Dijkstra;
using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Behaviours
{
    public class Follow : IBehaviour
    {
        #region Singleton
        private static Follow instance = null;
        private Follow() { }

        public static Follow GetInstance()
        {
            if (instance == null)
            {
                instance = new Follow();
            }
            return instance;
        }

        #endregion
        
        public List<Node> Find_Path(Ghost ghost)
        {
            Node pacman_Node = new Node(GameManager.Player.Row, GameManager.Player.Column, null, null);
            Node ghost_Node = new Node(ghost.Row, ghost.Column, pacman_Node, null);

            return AStar_Algorithm.Find_Path(ghost_Node, pacman_Node);

        }
    }
}
