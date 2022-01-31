using System;
using System.Collections.Generic;
using ZooProject.FileLogger;

namespace ZooProject.Types
{
    class Lion : Animal
    {
        public Lion(AnimalType type, string code, int stomach)
        {
            this.Type = type;
            this._code = code;
            this._maxSize = stomach;
            this._stomach = stomach;

            this.FeedTypes = new List<FeedTypes>() {Types.FeedTypes.meat, Types.FeedTypes.dryFood };
            this.IsAlive = true;
            this.IsHungry = false;

            this._stomachSize = this._stomach - 200;
            this._stomachDelta = 200;
            this._seconds = 15;

            _logger = Logger.GetOrSetLogger();
            this.GetHungry();

        }
    }
}
