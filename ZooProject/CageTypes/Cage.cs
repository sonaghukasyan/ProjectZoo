using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    public abstract class Cage
    {
        public List<Animal> Animals { get; set; }
        public AnimalType AnimalType { get; set; }
        protected string CageCode { get; set; }
        protected List<FeedTypes> Menu { get; set; }

        public bool CheckCageCode(string cageCode)
        {
            return cageCode == this.CageCode;
        }
        public void LeaveFood()
        {
            foreach(Animal animal in Animals)
            {
                try
                {
                    animal.Feed(this.Menu[0]);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
