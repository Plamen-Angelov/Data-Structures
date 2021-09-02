namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private bool rootIsDeleted = false;

        public Tree(T value)
        {
            Value = value;
            Parent = null;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            this.children = children.ToList();
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            ICollection<T> result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subTree = queue.Dequeue();
                result.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            if (rootIsDeleted)
            {
                result.Clear();
                return null;
            }
            return result;
        }

        public ICollection<T> OrderDfs()
        {
            ICollection<T> result = new List<T>();
            //Stack<Tree<T>> stack = new Stack<Tree<T>>();
            //stack.Push(this);
            //result = DFSWithStack(stack, result.ToList(),Children.ToList());

            result = DFS(Children.ToList(), result.ToList());

            if (rootIsDeleted)
            {
                result.Clear();
                return result;
            }
            return result;
        }

        private ICollection<T> DFSWithStack(Stack<Tree<T>> stack, List<T> result, IList<Tree<T>> children)
        {
            foreach (var child in children)
            {
                stack.Push(child);
                DFSWithStack(stack, result, child.Children.ToList());
            }
            if (stack.Count > 0)
            {
                result.Add(stack.Pop().Value);
            }

            return result;
        }

        private ICollection<T> DFS(List<Tree<T>> childern, List<T> result)
        {
            foreach (var child in children)
            {
                child.DFS(child.children, result);
            }

            result.Add(this.Value);
            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = FindBFS(parentKey);
            CheckEmptyNode(parent);

            parent.children.Add(child);
        }

        private void CheckEmptyNode(Tree<T> parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("Node is empty");
            }
        }

        private Tree<T> FindBFS(T parentKey)
        {
            if (Value.Equals(parentKey))
            {
                return this;
            }
            Tree<T> myNode = null;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subTree = queue.Dequeue();

                foreach (var child in subTree.Children)
                {
                    if (child.Value.Equals(parentKey))
                    {
                        myNode = child;
                        return myNode;
                    }
                    queue.Enqueue(child);
                }
            }
            return myNode;
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
