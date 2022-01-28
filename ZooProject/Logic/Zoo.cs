using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.CageTypes;
using ZooProject.Types;

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
