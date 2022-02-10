using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    public class FoodArrivedArgs: EventArgs
    {
        public FeedTypes Feed { get; set; }

        public FoodArrivedArgs(FeedTypes feed)
        {
            this.Feed = feed;
        }
    }
}
