using System.Collections.Generic;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    class FishCage: Cage
    {
        public FishCage(string code)
        {
            this.Animals = new List<Animal>();
            this.AnimalType = AnimalType.fish;
            this._cageCode = code;
            this._menu = new List<FeedTypes>() { Types.FeedTypes.larvae, Types.FeedTypes.crustaceans };
            this._logger = FileLogger.Logger.GetOrSetLogger();
        }
    }
}
