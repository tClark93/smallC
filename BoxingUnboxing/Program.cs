using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> Boxing = new List<object>();
            Boxing.Add(7);
            Boxing.Add(28);
            Boxing.Add(-1);
            Boxing.Add(true);
            Boxing.Add("chair");

            foreach (object item in Boxing)
            {
                Console.WriteLine(item);
            }
            int count = 0;
            foreach (object item in Boxing)
            {
                if (item is int)
                {
                    int num = (int)item;
                    count += num;
                    Console.WriteLine(count);
                }
            }
        }
    }
}
