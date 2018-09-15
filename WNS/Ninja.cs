using System;
using System.Collections.Generic;

namespace WNS
{
    public class Ninja : Human
    {
        public Ninja(string x) : base(x)
        {
            dexterity = 175;
        }
        public void Steal(Human victim)
        {
            Human Victim = victim;
            Victim.health -= 10;
            health += 10;
        }
        public void GetAway()
        {
            health -= 15;
        }
    }
}