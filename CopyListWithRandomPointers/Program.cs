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
            PrintNode(cloneNoExtraSpace(head));
        }
        private static void PrintNode(Node n)
        {
            Console.WriteLine("{0}{1}{2}", n.val, n.next, n.random);
            Console.ReadLine();
        }
        private static void CompareTwoNodes (Node n1, Node n2)
        {
            Console.WriteLine("The first node: {0}{1}{2}",n1.val, n1.next, n1.random);
            Console.WriteLine("The second node: {0}{1}{2}", n2.val, n2.next, n2.random);
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
            while (nCurr != null)
            {
                //mapping.TryGetValue(nCurr.random, out Node tempNode);
                //copyCurr.random = tempNode;
                //I thought the problem might be with the above two lines so I changed it to what is below
                copyCurr.random = mapping[nCurr.random];
                nCurr = nCurr.next;
                copyCurr = copyCurr.next;
            }
            return copy;
        }
        private static Node cloneNoExtraSpace(Node n)
        {
            if (n == null)
            {
                return null;
            }
            Node nCurr = n;//This line and the line below seem to give the exact same result
            //Node tempNode = new Node(n.val, n.next, n.random);
            //CompareTwoNodes(nCurr, tempNode);
            while (nCurr != null)
            {
                Node temp = new Node();
                temp.val = nCurr.val;
                temp.next = nCurr.next;
                nCurr.next = temp;
                nCurr = nCurr.next.next;
            }
            nCurr = n;
            while (nCurr != null)
            {
                nCurr.next.random = nCurr.random.next;
                nCurr = nCurr.next.next;
            }
            Node copy = n.next;
            nCurr = n;
            while (nCurr.next != null)
            {
                Node temp = nCurr.next;
                nCurr.next = nCurr.next.next;
                nCurr = temp;
            }
            return copy;     
        }
    }
}
