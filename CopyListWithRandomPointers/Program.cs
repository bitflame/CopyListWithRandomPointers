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
            PrintNode(cloneExtraSpace(head));
        }
        private static void PrintNode(Node n)
        {
            Console.WriteLine("{0}{1}{2}", n.val, n.next, n.random);
            Console.ReadLine();
        }
        private static Node cloneExtraSpace(Node n)
        {
            if (n == null)
            {
                return null;
            }
            Dictionary<Node, Node> mapping = new Dictionary<Node, Node>();
            Node copy = new Node();
            Node nCurr = n;
            var copyCurr = copy;
            mapping.Add(nCurr, copyCurr);
            while (nCurr.next != null)
            {
                copyCurr.next = new Node();
                nCurr = nCurr.next;
                copyCurr = copyCurr.next;
                mapping.Add(nCurr, copyCurr);
            }
            nCurr = n;
            copyCurr = copy;
            while (copyCurr != null)
            {
                mapping.TryGetValue(nCurr.random, out Node tempNode);
                copyCurr.random = tempNode;
                nCurr = nCurr.next;
                copyCurr = copyCurr.next;
            }
            return copy;
        }
        //private static Node cloneNoExtraSpace(Node n)
        //{
        //    if ( n == null)
        //    {
        //        return null;
        //    }
        //}
    }
}
