using System;
using System.Collections.Generic;

namespace WNS
{
        public class Samurai : Human
    {
        public Samurai(string x) : base(x)
        {
            health = 200;
        }
        public void DeathBlow(Human victim)
        {
            Human Victim = victim;
            if(Victim.health <= 50)
            {
                Victim.health = 0;
            }
        }
        public void Meditate()
        {
            health = 200;
        }
    }
}