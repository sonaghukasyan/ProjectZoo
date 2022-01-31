using System;
using System.Collections.Generic;
using ZooProject.FileLogger;

namespace ZooProject.Types
{
    class Fish : Animal
    {
        public Fish(AnimalType type, string code, int stomach)
        {
            this.Type = type;
            this._code = code;
            this._stomach = stomach;
            this._maxSize = stomach;

            this.FeedTypes = new List<FeedTypes>() { Types.FeedTypes.larvae, Types.FeedTypes.crustaceans };
            this.IsAlive = true;
            this.IsHungry = false;

            this._stomachSize = this._stomach - 10;
            this._stomachDelta = 5;
            this._seconds = 3;
            _logger = Logger.GetOrSetLogger();
            this.GetHungry();
        }

    }
}
