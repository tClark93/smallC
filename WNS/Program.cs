using System;

namespace WNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard Harry = new Wizard("Harry");
            // Console.WriteLine("Name: " + Harry.Name + " Strength: " + Harry.strength + " Intelligence: " + Harry.intelligence + " Dexterity: " + Harry.dexterity + " Health: " + Harry.health);
            Harry.Heal();
            // Console.WriteLine("Name: " + Harry.Name + " Strength: " + Harry.strength + " Intelligence: " + Harry.intelligence + " Dexterity: " + Harry.dexterity + " Health: " + Harry.health);
            Ninja Michael = new Ninja("Michael");
            // Console.WriteLine("Name: " + Michael.Name + " Strength: " + Michael.strength + " Intelligence: " + Michael.intelligence + " Dexterity: " + Michael.dexterity + " Health: " + Michael.health);
            Harry.Fireball(Michael);
            // Console.WriteLine("Name: " + Michael.Name + " Strength: " + Michael.strength + " Intelligence: " + Michael.intelligence + " Dexterity: " + Michael.dexterity + " Health: " + Michael.health);
            Michael.Steal(Harry);
            // Console.WriteLine("Name: " + Michael.Name + " Strength: " + Michael.strength + " Intelligence: " + Michael.intelligence + " Dexterity: " + Michael.dexterity + " Health: " + Michael.health);
            // Console.WriteLine("Name: " + Harry.Name + " Strength: " + Harry.strength + " Intelligence: " + Harry.intelligence + " Dexterity: " + Harry.dexterity + " Health: " + Harry.health);
            Samurai Jack = new Samurai("Jack");
            Console.WriteLine("Name: " + Jack.Name + " Strength: " + Jack.strength + " Intelligence: " + Jack.intelligence + " Dexterity: " + Jack.dexterity + " Health: " + Jack.health);
            Harry.Fireball(Jack);
            Harry.Fireball(Jack);
            Harry.Fireball(Jack);
            Console.WriteLine("Name: " + Jack.Name + " Strength: " + Jack.strength + " Intelligence: " + Jack.intelligence + " Dexterity: " + Jack.dexterity + " Health: " + Jack.health);
            Jack.Meditate();
            Console.WriteLine("Name: " + Jack.Name + " Strength: " + Jack.strength + " Intelligence: " + Jack.intelligence + " Dexterity: " + Jack.dexterity + " Health: " + Jack.health);


        }
    }
}
