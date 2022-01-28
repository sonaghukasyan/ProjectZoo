using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    class LionCage: Cage
    {
        public LionCage(string code)
        {
            this.Animals = new List<Animal>();
            this.AnimalType = AnimalType.lion;
            this.CageCode = code;
            this.Menu = new List<FeedTypes>() { Types.FeedTypes.meat, Types.FeedTypes.dryFood };
        }
    }
}
