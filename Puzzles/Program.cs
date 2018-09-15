using System;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // RandomArray();
            // CoinFlip();
            // TossMultiple(8);
            Name();
        }
        static void RandomArray()
        {
            int[] arr = new int[10];
            Random rand = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(5,25);
            }
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if(arr[i] > max)
                {
                    max = arr[i];
                }
                if(arr[i] < min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}", min, max, sum);
            Console.WriteLine(string.Join(", ", arr));
        }
        static int CoinFlip()
        {
            Random rand = new Random();
            string response = "";
            int result = 0;
            Console.WriteLine("Flipping a Coin:");
            if(rand.Next(1,3) == 1){
                response = "Heads";
                result = 1;
            }
            if(rand.Next(1,3) == 2){
                response = "Tails";
                result = 2;
            }
            Console.WriteLine(response);
            return result;
        }
        static Double TossMultiple(int num)
        {
            double sum = 0;
            Random rand = new Random();
            for(int i = 0; i < num; i++)
            {
                if(rand.Next(1,3) == 1)
                {
                    sum++;
                }
            }
            double avg = sum/num;
            Console.WriteLine(avg);
            return avg;
        }
        static string[] Name()
        {
            string[] array = new string[] {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            int count = 0;
            for(int i = 0; i < array.Length; i++)
            {
                int temp = rand.Next(0, 5);
                string swap = array[i];
                array[i] = array[temp];
                array[temp] = swap;
                if(array[i].Length > 5)
                {
                    count++;
                }
            }
            Console.WriteLine(string.Join(", ", array));
            string[] arrNew = new string[count];
            for(int j=0; j < array.Length; j++)
            {
                if(array[j].Length > 5)
                {
                    arrNew[count-1] = array[j];
                    count--;
                }
            }
            Console.WriteLine(string.Join(", ", arrNew));
            return arrNew;
        }
    }
}
