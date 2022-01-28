using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    class DogCage: Cage
    {
        public DogCage(string code)
        {
            this.Animals = new List<Animal>();
            this.AnimalType = AnimalType.dog;
            this.CageCode = code;
            this.Menu = new List<FeedTypes>() { Types.FeedTypes.cereal, Types.FeedTypes.meat, Types.FeedTypes.dryFood };
        }
    }
}
