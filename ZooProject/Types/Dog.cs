using System;
using System.Collections.Generic;
using ZooProject.FileLogger;

namespace ZooProject.Types
{
    class Dog : Animal
    {
        public Dog(AnimalType type, string code, int stomach)
        {
            this.Type = type;
            this._code = code;
            this._stomach = stomach;
            this._maxSize = stomach;

            this.FeedTypes = new List<FeedTypes>() { Types.FeedTypes.cereal, Types.FeedTypes.meat, Types.FeedTypes.dryFood };
            this.IsAlive = true;
            this.IsHungry = false;

            this._stomachSize = this._stomach - 50;
            this._stomachDelta = 50;
            this._seconds = 10;

            _logger = Logger.GetOrSetLogger();
            this.GetHungry();
        }
    }
}

