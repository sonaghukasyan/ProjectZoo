using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    class FishCage: Cage
    {
        public FishCage(string code)
        {
            this.Animals = new List<Animal>();
            this.AnimalType = AnimalType.fish;
            this.CageCode = code;
            this.Menu = new List<FeedTypes>() { Types.FeedTypes.larvae, Types.FeedTypes.crustaceans };
        }
    }
}
