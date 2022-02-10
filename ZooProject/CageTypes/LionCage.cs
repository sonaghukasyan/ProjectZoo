using System.Collections.Generic;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    class LionCage: Cage
    {
        public LionCage(string code)
        {
            this.Animals = new List<Animal>();
            this.AnimalType = AnimalType.lion;
            this._cageCode = code;
            this.Food = FeedTypes.meat;
            this.FoodWeight = 0;
            this.MaxWeight = 1000;
            this._logger = FileLogger.Logger.GetOrSetLogger();
        }
    }
}
