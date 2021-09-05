namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                int[] data = line.Split().Select(int.Parse).ToArray();
                CreateNodeByKey(data[0]);
                CreateNodeByKey(data[1]);
                AddEdge(data[0], data[1]);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            Tree<int> node = null;

            if (!nodesBykeys.ContainsKey(key))
            {
                node = new Tree<int>(key);
                nodesBykeys.Add(key, node);
            }

            return node;
        }

        public void AddEdge(int parent, int child)
        {
            nodesBykeys[parent].AddChild(nodesBykeys[child]);
            nodesBykeys[child].AddParent(nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            Tree<int> node = nodesBykeys.FirstOrDefault().Value;

            while (node.Parent != null)
            {
                node = node.Parent;
            }

            return node;
        }
    }
}
