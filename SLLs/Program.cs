using System;

namespace SLLs
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList linked = new SinglyLinkedList();
            linked.add(5);
            linked.add(3);
            linked.add(1);
            linked.add(2);
            linked.add(1);
            linked.add(9);
            linked.PrintValues();
            // SllNode newNode = new SllNode(5);
            // SllNode newNode2 = new SllNode(6);
            // SllNode newNode3 = new SllNode(1);
            
        }
    }
}
