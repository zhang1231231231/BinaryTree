using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // 构造一颗二叉树，根节点为"A"
            BinaryTree<string> bTree = new BinaryTree<string>("A");
            Node<string> rootNode = bTree.Root;
            // 向根节点"A"插入左孩子节点"B"和右孩子节点"C"
            bTree.InsertLeft(rootNode, "B");
            bTree.InsertRight(rootNode, "C");
            // 向节点"B"插入左孩子节点"D"和右孩子节点"E"
            Node<string> nodeB = rootNode.LChild;
            bTree.InsertLeft(nodeB, "D");
            bTree.InsertRight(nodeB, "E");
            // 向节点"C"插入右孩子节点"F"
            Node<string> nodeC = rootNode.RChild;
            bTree.InsertRight(nodeC, "F");

            // 前序遍历
            Console.WriteLine("---------PreOrder---------");
            bTree.PreOrder(bTree.Root);
            Console.WriteLine("");

            // 中序遍历
            Console.WriteLine("---------MidOrder---------");
            bTree.MidOrder(bTree.Root);
            Console.WriteLine("");
            // 后序遍历
            Console.WriteLine("---------PostOrder---------");
            bTree.PostOrder(bTree.Root);
            Console.WriteLine("");

            // 前序无递归遍历
            Console.WriteLine("---------PreOrderNoRecursion---------");
            bTree.PreOrderNoRecursion(bTree.Root);
            Console.WriteLine("");

            // 中序无递归遍历
            Console.WriteLine("---------MidOrderNoRecursion---------");
            bTree.MidOrderNoRecursion(bTree.Root);
            Console.WriteLine("");

            // 前序无递归遍历
            Console.WriteLine("---------PostOrderNoRecursion---------");
            bTree.PostOrderNoRecursion(bTree.Root);
            Console.ReadLine();

        }
    }

    public class Node<T>
    {
        public Node<T> LChild { get; set; }
        public Node<T> RChild { get; set; }
        public T Item { get; set; }

        public Node(T item)
        {
            this.Item = item;
        }
        public Node(T item, Node<T> lChild, Node<T> rChild)
        {
            this.Item = item;
            this.LChild = lChild;
            this.RChild = rChild;
        }

        public Node()
        {
        }
    }

    public class BinaryTree<T>
    {
        private Node<T> root;
        public Node<T> Root
        {
            get
            {
                return this.root;
            }
        }

        public BinaryTree(T item)
        {
            this.root = new Node<T>(item);
        }

        public BinaryTree()
        {

        }
        /// <summary>
        /// 判断该二叉树是否为空树
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.root == null;
        }
        public void InsertLeft(Node<T> p, T item)
        {
            Node<T> tempNode = new Node<T>(item);
            p.LChild = tempNode;
        }

        public void InsertRight(Node<T> p, T item)
        {
            Node<T> tempNode = new Node<T>(item);
            p.RChild = tempNode;
        }

        // Method04:删除节点p下的左子树
        public Node<T> RemoveLeft(Node<T> p)
        {
            if (p == null || p.LChild == null)
            {
                return null;
            }

            Node<T> tempNode = p.LChild;
            p.LChild = null;
            return tempNode;
        }

        // Method05:删除节点p下的右子树
        public Node<T> RemoveRight(Node<T> p)
        {
            if (p == null || p.RChild == null)
            {
                return null;
            }

            Node<T> tempNode = p.RChild;
            p.RChild = null;
            return tempNode;
        }
        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node">当前节点</param>
        public void PreOrder(Node<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Item + " ");
                PreOrder(node.LChild);
                PreOrder(node.RChild);

            }
        }
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node">当前节点</param>
        public void MidOrder(Node<T> node)
        {
            if (node != null)
            {
                MidOrder(node.LChild);
                Console.Write(node.Item + " ");
                MidOrder(node.RChild);
            }
        }
        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node">当前节点</param>
        public void PostOrder(Node<T> node)
        {
            if (node != null)
            {
                PostOrder(node.LChild);
                PostOrder(node.RChild);
                Console.Write(node.Item + " ");
            }
        }
        /// <summary>
        /// 不用递归的方式前序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PreOrderNoRecursion(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(node);
            Node<T> tempNode = null;
            while (stack.Count > 0)
            {
                //遍历根节点
                tempNode = stack.Pop();
                Console.Write(tempNode.Item + " ");
                //右子树入栈
                if (tempNode.RChild != null)
                {
                    stack.Push(tempNode.RChild);
                }
                //左子树入栈
                if (tempNode.LChild != null)
                {
                    stack.Push(tempNode.LChild);
                }
            }
        }
        /// <summary>
        /// 不用递归的方式中序遍历
        /// </summary>
        /// <param name="node"></param>
        public void MidOrderNoRecursion(Node<T> node)
        {
            if (node == null)
            {
                return;
            }
            Stack<Node<T>> stack = new Stack<Node<T>>();
            Node<T> tempNode = new Node<T>();
            tempNode = node;
            while (tempNode != null || stack.Count > 0)
            {
                //依次将所有左子树节点压栈
                while (tempNode != null)
                {
                    stack.Push(tempNode);
                    tempNode = tempNode.LChild;
                }
                //出栈遍历节点
                tempNode = stack.Pop();
                Console.Write(tempNode.Item + " ");
                //左子树遍历结束则跳转到又子树
                tempNode = tempNode.RChild;
            }
        }
        /// <summary>
        /// 无递归后序遍历
        /// </summary>
        /// <param name="node"></param>
        public void PostOrderNoRecursion(Node<T> node)
        {
            if (node ==null)
            {
                return;
            }

            //两个栈，一个存储，一个输出
            Stack<Node<T>> stackIn = new Stack<Node<T>>();
            Stack<Node<T>> stackOut = new Stack<Node<T>>();
            Node<T> tempNode = null;
            //根节点首先压栈
            stackIn.Push(node);
            //左->右->根
            while (stackIn.Count > 0)
            {
                tempNode = stackIn.Pop();
                stackOut.Push(tempNode);
                if (tempNode.LChild != null)
                {
                    stackIn.Push(tempNode.LChild);
                }
                if (tempNode.RChild != null)
                {
                    stackIn.Push(tempNode.RChild);
                }
            }

            while (stackOut.Count > 0)
            {
                //依次遍历各节点
                Node<T> outNode = stackOut.Pop();
                Console.Write(outNode.Item + " ");
            }
        }
    }

}
