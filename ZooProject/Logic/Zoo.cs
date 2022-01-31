using System.Collections.Generic;
using ZooProject.CageTypes;

namespace ZooProject.Logic
{
    class Zoo
    {
        public List<Cage> Cages { get; set; }

        public Zoo()
        {
            this.Cages = new List<Cage>();
        }
    }
}
