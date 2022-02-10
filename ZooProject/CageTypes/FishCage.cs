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
            this.Food = FeedTypes.larvae;
            this.FoodWeight = 0;
            this.MaxWeight = 500;
            this._logger = FileLogger.Logger.GetOrSetLogger();
        }
    }
}
