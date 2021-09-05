namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            int level = 0;
            string line = $"{new string(' ', level)}{Key}";
            sb.AppendLine(line);
            
            sb = DFS(this.children, sb, level + 2);

            return sb.ToString().TrimEnd();
        }

        private StringBuilder DFS(List<Tree<T>> children, StringBuilder sb, int level)
        {
            foreach (var child in children)
            {
                sb.AppendLine($"{new string(' ', level)}{child.Key}");
                DFS(child.children, sb, level + 2);
            }

            return sb;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            Tree<T> leftmostKey = default;
            int deepestLevel = 0;
            int level = 1;

            return FindDeepestKey(level, deepestLevel, children, leftmostKey);
        }

        private Tree<T> FindDeepestKey(int Level, int deepestLevel, 
            List<Tree<T>> children, Tree<T> leftmostKey)
        {
            foreach (var child in children)
            {
                if(Level > deepestLevel)
                {
                    deepestLevel = Level;
                    leftmostKey = child;
                }

                FindDeepestKey(Level + 1, deepestLevel, child.children, leftmostKey);
            }

            return leftmostKey;
        }

        public List<T> GetLeafKeys()
        {
            List<T> leafs = GetLeafs(children, new List<T>());
            return leafs.OrderBy(x => x).ToList();
        }

        private List<T> GetLeafs(List<Tree<T>> children, List<T> leafs)
        {
            foreach (var child in children)
            {
                if (child.children.Count == 0)
                {
                    leafs.Add(child.Key);
                }
                else
                {
                    GetLeafs(child.children, leafs);
                }
            }
            return leafs;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> middleKeys = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> current = queue.Dequeue();
                if (current.Parent != null && current.children.Count > 0)
                {
                    middleKeys.Add(current.Key);
                }

                foreach (var child in current.children)
                {
                    queue.Enqueue(child);
                }
            }

            return middleKeys.OrderBy(n => n).ToList();
        }

        public List<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
