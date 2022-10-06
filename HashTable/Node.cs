using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Node
    {
        public object Key;
        public object value;
        public int hash;
        public Node next;

        public Node(object key, object value, int hash, Node next)
        {
            this.Key = key;
            this.value = value;
            this.hash = hash;
            this.next = next;
        }
    }
}
