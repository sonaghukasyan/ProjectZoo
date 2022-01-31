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
            this._menu = new List<FeedTypes>() { Types.FeedTypes.meat, Types.FeedTypes.dryFood };
            this._logger = FileLogger.Logger.GetOrSetLogger();
        }
    }
}
