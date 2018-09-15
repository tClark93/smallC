using System;

namespace SLLs
{
    public class SinglyLinkedList
    {
        public SllNode head;
        public SinglyLinkedList() 
        {
            head = null;
        }
        public void add(int value) 
        {
            SllNode newNode = new SllNode(value);
            if(head == null) 
            {
                head = newNode;
            } 
            else
            {
                SllNode runner = head;
                while(runner.next != null) {
                    runner = runner.next;
                }
                runner.next = newNode;
            }
        } 
        public SllNode remove() 
        {
            SllNode runner = head;
            while(runner.next.next != null) 
            {
                runner = runner.next;
            }
            SllNode temp = runner.next;
            runner.next = null;
            return temp;
        }
        public void PrintValues()
        {
            SllNode runner = head;
            while(runner.next != null)
            {
                Console.Write(runner.value + " --> ");
                runner = runner.next;
            }
            Console.Write(runner.value);
        }    
    }
}