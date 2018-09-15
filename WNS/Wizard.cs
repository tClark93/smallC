using System;
using System.Collections.Generic;

namespace WNS
{
    public class Wizard : Human
    {
        public Wizard(string x) : base(x)
        {
            intelligence = 25;
            health = 50;
        }
        public void Heal()
        {
            health += intelligence*10;
        }
        
        public void Fireball(Human victim)
        {
            Random rand = new Random();
            Human Victim = victim;
            if(Victim != null)
            {
                Victim.health -= rand.Next(20,51);
            }
        }
    }
}