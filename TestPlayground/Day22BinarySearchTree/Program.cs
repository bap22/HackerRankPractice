using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22BinarySearchTree
{
    class Node
    {
        public Node left, right;
        public int data;
        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }

    class Solution
    {

        public static int getHeight(Node root)
        {
            if (root == null || (root.left == null && root.right == null)) {
                return 0;
            }
            int lefth = getHeight(root.left);
            int righth = getHeight(root.right);

            if (lefth > righth)
            {
                return lefth + 1;
            }
            else
            {
                return righth + 1;
            }
        }

        static void levelOrder(Node root)
        {

            Queue<Node> queue = new Queue<Node>();
            if (root != null) {
                // enqueue current root
                queue.Enqueue(root);
 
                // while there are nodes to process
                while (queue.Count != 0) {
                    // dequeue next node
                    Node tree = queue.Dequeue();

                    //process tree's root;
                    Console.Write($"{tree.data} ");

                    // enqueue child elements from next level in order
                    if (tree.left !=null) {
                        queue.Enqueue(tree.left);
                    }
                    if (tree.right != null)
                    {
                        queue.Enqueue(tree.right);
                    }
                }

            }
        }

        static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
        static void Main(String[] args)
        {
            Node root = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            //int height = getHeight(root);
            //Console.WriteLine(height);
            levelOrder(root);
            Console.ReadLine();

        }
    }
}
