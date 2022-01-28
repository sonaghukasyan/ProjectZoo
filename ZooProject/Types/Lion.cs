using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ZooProject.Types
{
    class Lion : Animal
    {
        public Lion(AnimalType type, string code, int stomach)
        {
            this.Type = type;
            this.Code = code;
            this.MaxSize = stomach;
            this.Stomach = stomach;

            this.FeedTypes = new List<FeedTypes>() {Types.FeedTypes.meat, Types.FeedTypes.dryFood };
            this.IsAlive = true;
            this.IsHungry = false;

            this.StomachSize = this.Stomach - 200;
            this.StomachDelta = 200;
            this.Seconds = 15;

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
                    Console.WriteLine("This lion successfully ate.");
                    return;
                }
            }

            throw new Exception("Lions cannot eat that food. Check their menu))");
        }
    }
}
