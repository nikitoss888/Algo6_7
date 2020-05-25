using System.Collections.Generic;
using System.Linq;

namespace Lab6_7
{
    class BFS
    {
        private HashSet<Node> WasVisited;
        private LinkedList<Node> Path;
        private Node Goal;

        public LinkedList<Node> BFSList(Node start, Node goal)
        {
            WasVisited = new HashSet<Node>();
            Path = new LinkedList<Node>();
            this.Goal = goal;
            BFSRecursion(start);
            if (Path.Count > 0)
            {
                Path.AddLast(start);
            }
            return Path;
        }

        private bool BFSRecursion(Node node)
        {
            if (node == Goal)
            {
                return true;
            }
            WasVisited.Add(node);
            foreach (var child in node.Children.Where(x => !WasVisited.Contains(x)))
            {
                if (BFSRecursion(child))
                {
                    Path.AddFirst(child);
                    return true;
                }
            }
            return false;
        }
    }
}