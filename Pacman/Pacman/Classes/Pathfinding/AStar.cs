using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Pathfinding
{
    public class AStar
    {
        public static List<Node> Find_Path(Node node_start, Node node_goal)
        {
            List<Node> path = new List<Node>();

            //Create OPEN and CLOSED list
            SortedNodeList openNodes = new SortedNodeList();
            SortedNodeList closedNodes = new SortedNodeList();

            //Put node_start on the OPEN list
            openNodes.Add(node_start);

            //while the OPEN list is not empty
            while (openNodes.Count > 0)
            {
                //Get the node off the open list 
                //with the lowest f and call it node_current
                Node node_current = openNodes.TakeOutNode();

                //if node_current is the same state as node_goal we have found the solution;
                //break from the while loop;
                if (node_current.isMatch(node_goal))
                {
                    node_goal.ParentNode = node_current.ParentNode;
                    break;
                }

                //Generate each state node_successor that can come after node_current
                List<Node> successors = node_current.GetSuccessors();

                //for each node_successor or node_current   ```
                foreach (Node node_successor in successors)
                {
                    //Set the cost of node_successor to be the cost of node_current plus
                    //the cost to get to node_successor from node_current
                    //--> already set while we are getting successors

                    //find node_successor on the OPEN list
                    int oFound = openNodes.IndexOf(node_successor);

                    //if node_successor is on the OPEN list but the existing one is as good
                    //or better then discard this successor and continue
                    if (oFound > 0)
                    {
                        Node existing_node = openNodes.NodeAt(oFound);
                        if (existing_node.CompareTo(node_current) <= 0)
                            continue;
                    }

                    //find node_successor on the CLOSED list
                    int cFound = closedNodes.IndexOf(node_successor);

                    //if node_successor is on the CLOSED list but the existing one is as good
                    //or better then discard this successor and continue;
                    if (cFound > 0)
                    {
                        Node existing_node = closedNodes.NodeAt(cFound);
                        if (existing_node.CompareTo(node_current) <= 0)
                            continue;
                    }

                    //Remove occurences of node_successor from OPEN and CLOSED
                    if (oFound != -1)
                        openNodes.RemoveAt(oFound);
                    if (cFound != -1)
                        closedNodes.RemoveAt(cFound);

                    //Set the parent of node_successor to node_current;
                    //--> already set while we are getting successors

                    //Set h to be the estimated distance to node_goal (Using heuristic function)
                    //--> already set while we are getting successors

                    //Add node_successor to the OPEN list
                    openNodes.Add(node_successor);
                }
                //Add node_current to the CLOSED list
                closedNodes.Add(node_current);
            }


            //follow the parentNode from goal to start node
            //to find solution
            Node p = node_goal;
            while (p != null)
            {
                path.Insert(0, p);
                p = p.ParentNode;
            }
            return path;
        }
        //-------------------------------------------------------------
    }
}

