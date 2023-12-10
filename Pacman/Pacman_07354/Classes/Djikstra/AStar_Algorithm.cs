using System.Collections.Generic;

namespace Pacman_07354.Classes.Djikstra
{
    public static class AStar_Algorithm
    {
        public static List<Node> Find_Path(Node start, Node goal)
        {
            List<Node> path_solution = new List<Node>();
            List<Node> open_List   = new List<Node>();
            List<Node> closed_List = new List<Node>();

            open_List.Add(start);
            //while open list is not empty and the goal node is not found
            while (open_List.Count > 0)
            {
                Node current_Node = Remove_Min_Node(open_List);
                //Check if goal is found
                if (current_Node.Equals(goal))
                {
                    goal.Previous_Node = current_Node.Previous_Node;
                    break;
                }
                //Explore the neighbors
                List<Node> neighbors_List = current_Node.Get_Neighbors();
                foreach(Node neighbor in neighbors_List)
                {
                    //Check if the neighbor already exists in Open List
                    int index_Open_List = open_List.IndexOf(neighbor);
                    //the neighbor already exists in Open List
                    if (index_Open_List > 0)
                    {
                        if(open_List[index_Open_List].F <= neighbor.F)
                        {
                            continue;//Skip the current neighbor
                        }
                        else
                        {
                            open_List.RemoveAt(index_Open_List);
                            open_List.Add(neighbor);
                        }
                    }
                    //Check if the neighbor do not exists in Closed List
                    if (!closed_List.Contains(neighbor) && index_Open_List < 0)
                    {
                        open_List.Add(neighbor);
                    }
                }
                //Add current Node to closed list
                closed_List.Add(current_Node);
            }
            //Backtracking from goal to start
            Node node = goal;
            while(node != null)
            {
                path_solution.Insert(0, node);
                node = node.Previous_Node;
            }
            return path_solution;
        }
        public static Node Remove_Min_Node(List<Node> list)
        {
            if (list.Count > 0)
            {
                Node min_node = list[0];
                foreach (Node obj in list)
                {
                    if(obj.F < min_node.F)
                    {
                        min_node = obj;
                    }
                }
                list.Remove(min_node);
                return min_node;
            }
            return null;
        }
    }
}
