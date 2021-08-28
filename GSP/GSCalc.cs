using System;
using System.Collections.Generic;
using System.Text;

namespace GSP
{
    class GSCalc
    {
        Node head;
        List<Node> nodePath = new List<Node>();
        Dictionary<String,String> path = new Dictionary<String, String>();
        List<Waygate> waygates;
        List<Node> wgMap = new List<Node>();
        int searchLevel = 0;
        bool finished = false;
        List<Node> cache = new List<Node>();
        Waygate final;
        public GSCalc(Waygate start, Waygate finish,List<Waygate> waygates)
        {
            this.waygates = waygates;
            final = finish;
            this.head = new Node(start,searchLevel);
            waygates.Remove(start);
            wgMap.Add(head);
            mapChildren(head);
            isFinish(head);
            wgMap.AddRange(cache);
            cache.Clear();
            ++searchLevel;
            while (!finished)
            {
                foreach(Node search in wgMap)
                {
                    if(search.getLevel() == searchLevel)
                    {
                        mapChildren(search);
                        isFinish(search);
                    }
                }
                wgMap.AddRange(cache);
                cache.Clear();
                ++searchLevel;
            }
        }

        //PROBLEM: REMOVE FROM waygates ON mapChildren METHOD

        public void pathInfoSet()
        {
            for(int i = 0; i < nodePath.Count; ++i)
            {
                path.Add(nodePath[i].GetWaygate().getData("Location"),getNextPathType(i));
            }
        }

        public String getNextPathType(int i)
        {
            foreach(KeyValuePair<String,String> node in nodePath[i].GetWaygate().getAllData())
            {
                try
                {
                    if (node.Value.Equals(nodePath[i + 1].GetWaygate().getData("Location")))
                    {
                        return node.Key;
                    }
                }
                catch(Exception e)
                {
                    return "Destination";
                }
                
            }
            return null;
        }
        public bool isFinish(Node node)
        {
            foreach(Node child in node.getChildren())
            {
                if (child.GetWaygate().getData("Location").Equals(final.getData("Location")))
                {
                    setPath(child);
                    nodePath.Reverse();
                    pathInfoSet();
                    finished = true;
                    return true;
                }
            }
            return false;
        }
        public Dictionary<String,String> getEntirePath()
        {
            return path;
        }
        public void setPath(Node node)
        {
            nodePath.Add(node);
            while(node.getParent() != null)
            {
                setPath(node.getParent());
                return;
            }
        }

        public int getTrips()
        {
            return searchLevel;
        }

       
        public void mapChildren(Node node)
        {
            List<Waygate> cache = new List<Waygate>();
            foreach(String child in node.GetWaygate().getAllData().Values)
            {
                if (isWaygateAdded(child))
                {
                    continue;
                }
                foreach (Waygate way in waygates)
                {
                    if (way.getData("Location").Equals(child) && !cache.Contains(way))
                    {
                        Node toAdd = new Node(way, searchLevel+1);
                        toAdd.addParent(node);
                        node.addChild(toAdd);
                        cache.Add(way);
                        this.cache.Add(toAdd);
                        goto endOfLoop;
                    }
                }
            endOfLoop: {}
            }
            foreach(Waygate wg in cache)
            {
                if (waygates.Contains(wg))
                {
                    waygates.Remove(wg);
                }
            }
            //make it so can detect if finishing value is here, and cut off if so - save time 
        }

        public bool isWaygateAdded(String child)
        {
            foreach(Node node in wgMap)
            {
                if (node.GetWaygate().getData("Location").Equals(child))
                {
                    return true;
                }
            }
            return false;
        }
    }
    //                    if (way.getData("Location").Equals(child) && !cache.Contains(way) && !isWaygateAdded(way.getData("Location")))
}
