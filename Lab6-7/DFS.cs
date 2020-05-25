using System.Collections.Generic;
using System.Linq;

namespace Lab6_7
{
    class DFS
    {
        private HashSet<Node> WasVisited;
        private LinkedList<Node> Path;
        private Node Goal;
        public LinkedList<Node> DFSList(Node start, Node goal)
        {
            WasVisited = new HashSet<Node>();
            Path = new LinkedList<Node>();
            Goal = goal;
            DFSRecursion(start);
            if (Path.Count > 0)
            {
                Path.AddFirst(start);
            }
            return Path;
        }

        private bool DFSRecursion(Node node)
        {
            if (node == Goal)
            {
                return true;
            }
            WasVisited.Add(node);
            foreach (var child in node.Children.Where(x => !WasVisited.Contains(x)))
            {
                if (DFSRecursion(child))
                {
                    Path.AddFirst(child);
                    return true;
                }
            }
            return false;
        }
    }
}
