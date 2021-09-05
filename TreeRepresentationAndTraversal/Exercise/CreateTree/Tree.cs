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
            Tree<T> deepestNode = default;
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> current = queue.Dequeue();
                current.children.Reverse();

                foreach (var child in current.children)
                {
                    queue.Enqueue(child);
                }

                if (queue.Count == 0)
                {
                    deepestNode = current;
                }
            }
            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            List<Tree<T>> leafs = GetLeafs(children, new List<Tree<T>>());
            return leafs.Select(n => n.Key).OrderBy(x => x).ToList();
        }

        private List<Tree<T>> GetLeafs(List<Tree<T>> children, List<Tree<T>> leafs)
        {
            foreach (var child in children)
            {
                if (child.children.Count == 0)
                {
                    leafs.Add(child);
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
            List<T> path = new List<T>();
            Tree<T> deepstNode = GetDeepestLeftomostNode();
            Tree<T> currentNode = deepstNode;
            
            while (currentNode!= null)
            {
                path.Add(currentNode.Key);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<List<T>> paths = new List<List<T>>();
            List<Tree<T>> leafs = GetLeafs(children, new List<Tree<T>>());
            
            foreach (var leaf in leafs)
            {
                List<T> currentPath = new List<T>();
                Tree<T> node = leaf;

                while (node != null)
                {
                    currentPath.Add(node.Key);
                    node = node.Parent;
                }
                int currentSum = currentPath.Sum(n => int.Parse(n.ToString()));

                if (sum == currentSum)
                {
                    currentPath.Reverse();
                    paths.Add(currentPath);
                }
            }

            return paths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> roots = new List<Tree<T>>();
            GetSubTreesWithSumDFS(this, roots, sum);

            return roots;
        }

        private int GetSubTreesWithSumDFS(Tree<T> node, List<Tree<T>> roots, int sum)
        {
            int currentSum = Convert.ToInt32(node.Key);

            foreach (var child in node.children)
            {
                currentSum += GetSubTreesWithSumDFS(child, roots, sum);
            }

            if (currentSum == sum)
            {
                roots.Add(node);
            }

            return currentSum;
        }
    }
}
