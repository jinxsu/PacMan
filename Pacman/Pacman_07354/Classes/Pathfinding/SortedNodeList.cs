using System.Collections;

namespace Pacman_Game.Classes.Pathfinding
{
    public class SortedNodeList
    {
        ArrayList list;
        NodeComparer nodeComparer;


        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public SortedNodeList()
        {
            list = new ArrayList();
            nodeComparer = NodeComparer.Get_Instance();
        }


        public Node NodeAt(int i)
        {
            return (Node)list[i];
        }

        public void RemoveAt(int i)
        {
            list.RemoveAt(i);
        }

        public int IndexOf(Node n)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Node nodeInTheList = (Node)list[i];
                if (nodeInTheList.isMatch(n))
                    return i;
            }
            return -1;
        }

        public int Add(Node n)
        {
            int k = list.BinarySearch(n, nodeComparer);

            if (k == -1) // no element
                list.Insert(0, n);
            else if (k < 0) // find location by complement
            {
                k = ~k;
                list.Insert(k, n);
            }
            else if (k >= 0)
                list.Insert(k, n);

            return k;
        }

        public Node TakeOutNode()
        {
            Node r = (Node)list[0];
            list.RemoveAt(0);
            return r;
        }
    }
}