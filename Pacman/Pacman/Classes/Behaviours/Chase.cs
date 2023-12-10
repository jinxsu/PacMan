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
    public class Chase : IBehaviour
    {
        #region Singleton
        private static Chase instance = null;
        private Chase() { }

        public static Chase GetInstance()
        {
            if (instance == null)
            {
                instance = new Chase();
            }
            return instance;
        }
        #endregion
        public List<Node> Find_Path(Ghost ghost)
        {
            Node pacMan_Node = new Node(GameManager.Player.Row, GameManager.Player.Column, null, null);
            Node ghost_Node = new Node(ghost.Row, ghost.Column, pacMan_Node, null);

            return AStar_Algorithm.Find_Path(ghost_Node, pacMan_Node);
        }
    }
}
