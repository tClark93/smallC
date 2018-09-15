using System.Collections.Generic;
using System;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = {1,2,3,4,5,6,7,8,9,10};
            string[] wordArray = {"Tim", "Martin", "Nikki", "Sarah"};
            bool[] boolArray = {true, false, true, false, true, false, true, false, true, false};

            List<string> iceCream = new List<string>();
            iceCream.Add("Vanilla");
            iceCream.Add("Chocolate");
            iceCream.Add("Strawberry");
            iceCream.Add("Pumpkin");
            iceCream.Add("Cinnamon");
            Console.WriteLine(iceCream.Count);
            Console.WriteLine(iceCream[2]);
            iceCream.Remove("Strawberry");
            Console.WriteLine(iceCream.Count);

            Dictionary<string,string> dict = new Dictionary<string,string>();
            dict.Add("Tim", null);
            dict.Add("Martin", null);
            dict.Add("Nikki", null);
            dict.Add("Sarah", null);
            dict["Tim"] = "Vanilla";
            dict["Martin"] = "Strawberry";
            dict["Nikki"] = "Pumpkin";
            dict["Sarah"] = "Cinnamon";

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
