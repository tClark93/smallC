﻿using System;

namespace Fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }

            for(int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    continue;
                }
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            for(int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                if (i % 3 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                if (i % 5 == 0)
                {
                    Console.WriteLine("Fizz");
                }
            }

            Random rand = new Random();
            for(int i = 1; i <= 10; i++)
            {
                int value = rand.Next(1,15);
                Console.WriteLine(value);
                if (value % 3 == 0 && value % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                if (value % 3 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                if (value % 5 == 0)
                {
                    Console.WriteLine("Fizz");
                }
            }
        }
    }
}
