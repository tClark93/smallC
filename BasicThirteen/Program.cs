using System;
using System.Collections.Generic;

namespace BasicThirteen
{
    class Program
    {
        static void Main(string[] args)
        {
            // PrintAll();
            // PrintOdd();
            // PrintSum();
            // Iterate();
            // FindMax();
            // FindAverage();
            // OddArray();
            // GreaterThanY(4);
            // SquareValues();
            // EliminateNegs();
            // MinMaxAvg();
            // ShiftVals();
            NumberToString();
        }

        static void PrintAll()
        {
            for(int i = 1; i < 256; i++)
            {
                Console.Write(i + " ");
            }
        }
        static void PrintOdd()
        {
            for(int i = 1; i < 256; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(i + " ");
                }
            }
        }
        static void PrintSum()
        {
            int sum = 0;
            for(int i = 1; i < 256; i++)
            {
                sum += i;
                Console.WriteLine("New Number: " + i + " Sum: " + sum);
            }
        }
        static void Iterate()
        {
            int[] array = {1,3,5,7,9,13};
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        static void FindMax()
        {
            int[] array = {-1,-3,-7};
            int max = array[0];
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.Write(max);
        }
        static void FindAverage()
        {
            int[] array = {1,2,3,4,5};
            int sum = 0;
            for(int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            int avg = sum/array.Length;
            Console.Write(avg);
        }
        static void OddArray()
        {
            int len = 0;
            for(int i = 1; i <= 255; i++)
            {
                if (i % 2 == 1)
                {
                    len++;
                }
            }
            int[] y = new int[len];
            int index = 0;
            for(int i = 1; i <= 255; i++)
            {
                if (i % 2 == 1)
                {
                    y[index] = i;
                    index++;
                }
            }
            Console.WriteLine(string.Join(", ", y));
        }
        static void GreaterThanY(int y)
        {
            int[] array = {6,3,9,2,1,4};
            int count = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] > y)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static void SquareValues()
        {
            int[] array = {1,2,3,4,5};
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = array[i]*array[i];
            }
            Console.WriteLine(string.Join(", ", array));
        }
        static void EliminateNegs()
        {
            int[] array = {10,-3,8,5,-7,2};
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = 0;
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }
        static void MinMaxAvg()
        {
            int[] array = {2,5,4,1,3};
            int min = array[0];
            int max = array[0];
            int sum = 0;
            for(int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                if (array[i] < min)
                {
                    min = array[i];
                }
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            int avg = sum/array.Length;
            Console.WriteLine(min + ", " + max + ", " + avg);
        }
        static void ShiftVals()
        {
            int[] array = {2,4,6,8,10};
            for(int i = 0; i < array.Length; i++)
            {
                if (i == array.Length-1)
                {
                    array[i] = 0;
                }
                else
                {
                    array[i] = array[i+1];
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }
        static void NumberToString()
        {
            int[] array = {2,-4,6,-8,10};
            List<object> newArray = new List<object>();
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    newArray.Add(array[i]);
                }
                else
                {
                    newArray.Add("Dojo");
                }
            }
            Console.WriteLine(string.Join(", ", newArray));
        }
    }
}
