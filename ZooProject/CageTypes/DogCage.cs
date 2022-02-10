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
            this.Food = FeedTypes.cereal;
            this.FoodWeight = 0;
            this.MaxWeight = 1000;
            this._logger = FileLogger.Logger.GetOrSetLogger(); 
        }
    }
}
