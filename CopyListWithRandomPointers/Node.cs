using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyListWithRandomPointers
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node() { }
        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }
    }
}
