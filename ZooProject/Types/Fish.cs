using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ZooProject.Types
{
    class Fish : Animal
    {
        public Fish(AnimalType type, string code, int stomach)
        {
            this.Type = type;
            this.Code = code;
            this.Stomach = stomach;
            this.MaxSize = stomach;

            this.FeedTypes = new List<FeedTypes>() { Types.FeedTypes.larvae, Types.FeedTypes.crustaceans};
            this.IsAlive = true;
            this.IsHungry = false;
           
            this.StomachSize = this.Stomach - 10;
            this.StomachDelta = 5;
            this.Seconds = 3;
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
                    Console.WriteLine("This fish successfully ate.");
                    return;
                }
            }
            throw new Exception("This fish cannot eat " + food);
        }
    }
}
