using Pacman.Classes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Dijkstra
{
    public class Node
    {
        private int row;
        private int column;
        private Node goal_Node;
        private Node previous_Node;
        private int g;//Cost or distance between current node and the previous

        public Node(int row, int column, Node goal_Node, Node previous_Node, int g = 1)
        {
            this.row = row;
            this.column = column;
            this.goal_Node = goal_Node;
            this.previous_Node = previous_Node;
            this.g = g;
        }

        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public Node Goal_Node { get => goal_Node; set => goal_Node = value; }
        public Node Previous_Node { get => previous_Node; set => previous_Node = value; }

        //Total_G  = Total_G of previous_Node + g
        //Total distance starting from the start_node (A)
        public int Total_G { get => (this.previous_Node != null) ? this.previous_Node.Total_G + this.g : this.g; }

        //Heuristic Value (Euclidean Distance)
        public double H { get => Euclidean_Distance(); }

        //F = Total_G + H
        public double F { get => this.Total_G + this.H; }
        private double Euclidean_Distance()
        {
            double xDistance = this.column - this.goal_Node.column;
            double yDistance = this.row - this.goal_Node.row;
            return Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));
        }
        //Method Get_Neighbors
        public List<Node> Get_Neighbors()
        {
            List<Node> neighbors = new List<Node>();
            //Upper Tile : this.row -1 , this.column
            if (Map.Is_Valid_Tile(this.row - 1, this.column))
            {
                Node upper_Node = new Node(this.row - 1, this.column, this.goal_Node, this);
                if (!upper_Node.Equals(this.previous_Node))
                {
                    neighbors.Add(upper_Node);
                }
            }
            //Lower Tile : this.row +1 , this.column
            if (Map.Is_Valid_Tile(this.row + 1, this.column))
            {
                Node lower_Node = new Node(this.row + 1, this.column, this.goal_Node, this);
                if (!lower_Node.Equals(this.previous_Node))
                {
                    neighbors.Add(lower_Node);
                }
            }
            //Left Tile : this.row , this.column - 1
            if (Map.Is_Valid_Tile(this.row, this.column - 1))
            {
                Node left_Node = new Node(this.row, this.column - 1, this.goal_Node, this);
                if (!left_Node.Equals(this.previous_Node))
                {
                    neighbors.Add(left_Node);
                }
            }
            //Left Tile : this.row , this.column + 1
            if (Map.Is_Valid_Tile(this.row, this.column + 1))
            {
                Node right_Node = new Node(this.row, this.column + 1, this.goal_Node, this);
                if (!right_Node.Equals(this.previous_Node))
                {
                    neighbors.Add(right_Node);
                }
            }
            return neighbors;
        }
        //Method Equals
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is Node)
                {
                    return ((obj as Node).Row == this.row && (obj as Node).column == this.column);
                }
            }
            return false;
        }
    }
}
