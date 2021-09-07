namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            return DFS(this, 0);
        }

        public string DFS(IAbstractBinaryTree<T> node, int indent)
        {
            string result = $"{new string(' ', indent)}{node.Value}\r\n";

            if (node.LeftChild != null)
            {
                result += DFS(node.LeftChild, indent + 2);
            }

            if (node.RightChild != null)
            {
                result += DFS(node.RightChild, indent + 2);
            }

            return result;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            InOrderDFS(this, result);
            return result;
        }

        private IAbstractBinaryTree<T> InOrderDFS(IAbstractBinaryTree<T> node,
           List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                InOrderDFS(node.LeftChild, result);
            }

            result.Add(node);
            
            if (node.RightChild != null)
            {
                InOrderDFS(node.RightChild, result);
            }

            return node;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            PostOrderDFS(this, result);
            return result;
        }

        private IAbstractBinaryTree<T> PostOrderDFS(IAbstractBinaryTree<T> node, 
            List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                PostOrderDFS(node.LeftChild, result);
            }

            if (node.RightChild != null)
            {
                PostOrderDFS(node.RightChild, result);
            }

            result.Add(node);

            return node;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            PreOrderDFS(this, result);
            return result;
        }

        private IAbstractBinaryTree<T> PreOrderDFS(IAbstractBinaryTree<T> node, 
            List<IAbstractBinaryTree<T>> result)
        {
            result.Add(node);

            if (node.LeftChild != null)
            {
                PreOrderDFS(node.LeftChild, result);
            }
            if (node.RightChild != null)
            {
                PreOrderDFS(node.RightChild, result);
            }

            return node;
        }

        public void ForEachInOrder(Action<T> action)
        {
            List<IAbstractBinaryTree<T>> inorderNodes = InOrder();
            
            foreach (var node in inorderNodes)
            {
                action.Invoke(node.Value);
            }
        }
    }
}
