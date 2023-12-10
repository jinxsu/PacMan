using Pacman_07354.Classes.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_Game.Classes.Pathfinding
{
    public class Node: IComparable
    {
        private int row;//Y
        private int column;//X
        private Node goalNode;   //Final Destination (example Pacman position)
        private Node parentNode; //Previous node
        private int g_Cost;      //g value of the edge from parent to current node
        private int total_Cost;  //f value = g + h
        private int heuristic;   //h value = Global estimate of cost to reach the goal.

        public int Total_Cost { get => total_Cost + this.heuristic ; set => total_Cost = value; }
        public Node ParentNode { get => parentNode; set => parentNode = value; }
        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }

        public Node(int row, int column, Node goal, Node parent, int g = 1)
        {
            this.row = row; //y
            this.column = column;//x
            this.goalNode = goal;
            this.parentNode = parent;
            this.g_Cost = g;
            //Estimate of Cost from current node to goal
            this.heuristic = (this.goalNode != null)? (int)Euclidean_Distance() : 0;

            //Exact Cost from start node to current node (Total Cost of the Path)
            this.total_Cost = (this.parentNode != null) ? this.parentNode.total_Cost + this.g_Cost : this.g_Cost;
        }
        private double Manhattan_Distance()
        {
            double xDistance = this.column - this.goalNode.column;
            double yDistance = this.row - this.goalNode.row;
            return Math.Abs(xDistance) + Math.Abs(yDistance);
        }
        private double Euclidean_Distance()
        {
            double xDistance = this.column - this.goalNode.column;
            double yDistance = this.row - this.goalNode.row;
            return Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
        }
        public List<Node> GetSuccessors()
        {
            List<Node> neighbors = new List<Node>();
            // Upper Tile (Grid System) = (Column (x) , Row-1 (y-1))
            Abstract_Entity upperTile = Map.Array_Entities[this.row - 1, this.column];// C.getNighbor()
            if ( ! (upperTile is Wall) )
            {
                Node nodeUp = new Node(this.row - 1, this.column, this.goalNode, this);// this current node is parent node for the neighbor
                if(! nodeUp.isMatch(this.parentNode))//default operator != compares references (Reference types) we have to overload define the operator for Node
                {
                    neighbors.Add(nodeUp);
                }
            }
            // Lower Tile (Grid System) = (Column (x) , Row-+1 (y+1))
            Abstract_Entity lowerTile = Map.Array_Entities[this.row + 1, this.column];// C.getNighbor()
            if (!(lowerTile is Wall))
            {
                Node nodeDown = new Node(this.row + 1, this.column, this.goalNode, this);// this current node is parent node for the neighbor
                if (! nodeDown.isMatch(this.parentNode))//default operator != compares references (Reference types) we have to overload define the operator for Node
                {
                    neighbors.Add(nodeDown);
                }
            }
            // Left Tile (Grid System) = (Column-1 (x -1 ) , Row (y))
            Abstract_Entity leftTile = Map.Array_Entities[this.row, this.column - 1];// C.getNighbor()
            if (!(leftTile is Wall))
            {
                Node nodeLeft = new Node(this.row, this.column - 1, this.goalNode, this);// this current node is parent node for the neighbor
                if (! nodeLeft.isMatch(this.parentNode))//default operator != compares references (Reference types) we have to overload define the operator for Node
                {
                    neighbors.Add(nodeLeft);
                }
            }
            // Right Tile (Grid System) = (Column+1 (x + 1 ) , Row (y))
            Abstract_Entity rightTile = Map.Array_Entities[this.row, this.column + 1];// C.getNighbor()
            if (!(rightTile is Wall))
            {
                Node nodeRight = new Node(this.row, this.column + 1, this.goalNode, this);// this current node is parent node for the neighbor
                if (! nodeRight.isMatch(this.parentNode))//default operator != compares references (Reference types) we have to overload define the operator for Node
                {
                    neighbors.Add(nodeRight);
                }
            }
            return neighbors;
        }

        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }
            else
            {
                Node otherNode = obj as Node;
                if (!(otherNode is null))
                {
                    return this.Total_Cost.CompareTo(otherNode.Total_Cost);
                }
                else
                {
                    return 1;
                }
            }
        }

        public bool isMatch(Node node)
        {
            if (node != null)
                return (this.row == node.row && this.column == node.column);
            else
                return false;
        }

    }
}
