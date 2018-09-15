using System;
using System.Collections.Generic;

namespace Dojodachi
{
    public class Dachi
    {
        public int Happiness { get; set; } = 20;
        public int Fullness { get; set; } = 20;
        public int Energy { get; set; } = 50;
        public int Meals { get; set; } = 3;
        public string Message {get; set;} = "Get Dachi's happiness, fullness, and energy above 100 to win - if fullness or happiness hit 0 you lose. Feeding your Dachi costs 1 meal and gains a random amount of fullness between 5 and 10 (you cannot feed your Dojodachi if you do not have meals). Playing with your Dachi costs 5 energy and gains a random amount of happiness between 5 and 10. Sometimes your Dachi isn't in the mood to eat or play - energy or meals will still decrease, but happiness and fullness won't change. Working costs 5 energy and earns between 1 and 3 meals. Sleeping earns 15 energy and decreases fullness and happiness each by 5.";
        public Dachi Feed()
        {
            this.Meals -= 1;
            Random rand = new Random();
            Random chance = new Random();
            if(chance.Next(0,4) == 0)
            {
                this.Message = "Dachi is in no mood";
            }
            else
            {
                int growth = rand.Next(5,11);
                this.Fullness += growth;
                this.Message = $"Dachi is {growth} less hungry!";
            }
            
            return this;
        }
        public Dachi Play()
        {
            this.Energy -= 5;
            Random rand = new Random();
            Random chance = new Random();
            if(chance.Next(0,4) == 0)
            {
                this.Message = "Dachi is in no mood";
            }
            else
            {
                int growth = rand.Next(5,11);
                this.Happiness += growth;
                this.Message = $"Dachi is {growth} happier!";
            }
            return this;
        }
        public Dachi Work()
        {
            this.Energy -= 5;
            Random rand = new Random();
            int earned = rand.Next(1,4);
            this.Meals += earned;
            this.Message = $"That was hard, wahhhh! Dachi earned {earned} more meals!";
            return this;
        }
        public Dachi Sleep()
        {
            this.Energy += 15;
            this.Fullness -= 5;
            this.Happiness -= 5;
            this.Message = "i <3 naps";
            return this;
        }
    }

}