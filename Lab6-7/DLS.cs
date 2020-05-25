using System.Collections.Generic;
using System.Linq;

namespace Lab6_7
{
    class DLS
    {
        private HashSet<Node> WasVisited;
        private LinkedList<Node> Path;
        private Node Goal;
        private bool Limit;
        public LinkedList<Node> DLSList(Node start, Node goal, int limit)
        {
            WasVisited = new HashSet<Node>();
            Path = new LinkedList<Node>();
            Limit = true;
            this.Goal = goal;
            DLSRecurion(start, limit);
            if (Path.Count > 0)
            {
                Path.AddFirst(start);
            }
            return Path;
        }

        private bool DLSRecurion(Node node, int limit)
        {
            if (node == Goal)
            {
                return true;
            }
            if (limit == 0)
            {
                Limit = false;
                return false;
            }
            WasVisited.Add(node);
            foreach (var child in node.Children.Where(x => !WasVisited.Contains(x)))
            {
                if (DLSRecurion(child, limit - 1))
                {
                    Path.AddFirst(child);
                    return true;
                }
            }
            return false;
        }
    }
}