using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.CageTypes;
using ZooProject.Types;

namespace ZooProject
{
    public sealed class CodeCheck : System.Attribute
    {
        public string Description { get; set; }

        public int Code { get; set; }
        public CodeCheck(Animal animal)
        {
            this.Code = animal.GetCode();
            if (Code < 0 || Code > 10000)
            {
                throw new Exception("Animal code must be positive and less than 10000");
            }
        }

        public CodeCheck(Cage cage)
        {
            this.Code = cage.GetCode();
            if (Code < 0 || Code > 100000)
            {
                throw new Exception("Cage code must be positive and less than 100000");
            }
        }

        public CodeCheck() { }
    }
}
