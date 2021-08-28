using System;
using System.Collections.Generic;
using System.Text;

namespace GSP
{
    class Node
    {
        Node parent;
        List<Node> children = new List<Node>();
        Waygate waygate;
        int level;
        public Node(Waygate waygate, int level)
        {
            this.waygate = waygate;
            this.level = level;
        }

        public void addParent(Node node)
        {
            this.parent = node;
        }
        public Waygate GetWaygate()
        {
            return waygate;
        }
        public List<Node> getChildren()
        {
            return children;
        }
        public Node getChild(String identifier)
        {
            String nodeName = waygate.getData(identifier);
            foreach(Node child in children)
            {
                if (child.GetWaygate().getData("Location").Equals(nodeName)){
                    return child;
                }
            }
            return null;
        }
        public int getLevel()
        {
            return level;
        }
        public void addChildren(List<Node> children)
        {
            this.children = children;
        }
        public void addChild(Node child)
        {
            children.Add(child);
        }
        public Node getParent()
        {
            return parent;
        }

    }
}
