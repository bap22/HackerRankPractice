using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15LinkedList
{
    class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }

    }

    class Program
    {
        private static LinkedList<Node> _linkedList = new LinkedList<Node>();
        private static int listCount = 0;

        static void Main(String[] args)
        {

            Node head = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                head = insert(head, data);
            }
            display(head);
            Console.ReadLine();
        }

        public static Node insert(Node head, int data)
        {
            if (listCount > 0)
            {
                LinkedListNode<Node> lastNode = _linkedList.Last;
                Node nextNode = new Node(data);
                lastNode.Value.next = nextNode;
                _linkedList.AddAfter(lastNode, nextNode);
            }
            else
            {
                head = new Node(data);
                _linkedList.AddFirst(head);
            }
            listCount++;
            return head;
        }

        public static void display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }

    }
}
