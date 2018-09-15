using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human nancy = new Human("Nancy");
            Console.WriteLine(nancy.health);
            Human goliath = new Human("Goliath", 10, 1, 4, 1000);
            Console.WriteLine(goliath.name + ", " + goliath.strength + ", " + goliath.intelligence + ", " + goliath.dexterity + ", " + goliath.health);
            goliath.Attack(nancy);
            Console.WriteLine(nancy.name + ", " + nancy.strength + ", " + nancy.intelligence + ", " + nancy.dexterity + ", " + nancy.health);
        }
    }
}
