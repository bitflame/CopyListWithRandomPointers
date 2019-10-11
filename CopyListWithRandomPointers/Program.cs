using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyListWithRandomPointers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(0, null, null);
            Node firstNode = new Node(1, null, null);
            Node secNode = new Node(2, null, null);
            firstNode.next = secNode;
            firstNode.random = secNode;
            secNode.random = secNode;
            secNode.next = null;
            head = firstNode;
            CopyRandomList(head);
        }
        private static void PrintNode(Node n)
        {
            Console.WriteLine("{0}{1}{2}", n.val, n.next, n.random);
            Console.ReadLine();
        }
        private static Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }
            Node savedOrigNode = head;
            Node clonedNode = new Node(0, null, null);
            Node savedClonedNode = clonedNode;
            Node tempNode = clonedNode;
            while (head != null)
            {
                clonedNode = new Node(head.val, null, head);
                tempNode.next = clonedNode;
                tempNode = tempNode.next;
                head = head.next; 
            }
            clonedNode = savedClonedNode;
            head = savedOrigNode;  //Why does head get set to null even though savedOrigNode is not?
            while (clonedNode != null)
            {
                clonedNode.random = head.random;
                clonedNode = clonedNode.next;
                head = head.next;
            }
            clonedNode = savedClonedNode;
            while (clonedNode != null)
            {
                clonedNode.random = clonedNode.random.random.next;
                clonedNode = clonedNode.next;
            }
            return savedClonedNode;
        }
    }
}
