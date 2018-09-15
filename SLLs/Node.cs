using System;

namespace SLLs
{
    public class SllNode
    {
        public int value;
        public SllNode next;
        public SllNode(int input) 
        {
            value = input;
            next = null;
        }
    }
}