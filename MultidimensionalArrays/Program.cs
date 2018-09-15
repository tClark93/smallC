using System;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] multArray = new int [10,10];

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    multArray[i,j] = (i+1)*(j+1);
                }
            }
            for(int a = 0; a < 10; a++)
            {
                Console.WriteLine("");
                for(int b = 0; b < 10; b++)
                {
                    Console.Write(multArray[a,b] + ", ");
                }
            }
        }
    }
}
