using System.Collections.Generic;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    class DogCage: Cage
    {
        public DogCage(string code)
        {
            this.Animals = new List<Animal>();
            this.AnimalType = AnimalType.dog;
            this._cageCode = code;
            this._menu = new List<FeedTypes>() { Types.FeedTypes.cereal, Types.FeedTypes.meat, Types.FeedTypes.dryFood };
            this._logger = FileLogger.Logger.GetOrSetLogger(); 
        }
    }
}
