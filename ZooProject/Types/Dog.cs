using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ZooProject.Types
{
    class Dog : Animal
    {
        public Dog(AnimalType type, string code, int stomach)
        {
            this.Type = type;
            this.Code = code;
            this.Stomach = stomach;
            this.MaxSize = stomach;

            this.FeedTypes = new List<FeedTypes>() { Types.FeedTypes.cereal, Types.FeedTypes.meat, Types.FeedTypes.dryFood };
            this.IsAlive = true;
            this.IsHungry = false;

            this.StomachSize = this.Stomach - 50;
            this.StomachDelta = 50;
            this.Seconds = 10;

            this.GetHungry();
        }

        public override void Feed(FeedTypes food)
        {
            base.Feed(food);

            for (int i = 0; i < this.FeedTypes.Count; i++)
            {
                if (FeedTypes[i] == food)
                {
                    this.Stomach = this.MaxSize;
                    Console.WriteLine("This dog successfully ate.");
                    return;
                }
            }
            throw new Exception("Not suitable food");
        }

    }
}

