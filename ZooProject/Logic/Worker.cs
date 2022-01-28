using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ZooProject.CageTypes;
using ZooProject.Types;

namespace ZooProject.Logic
{
    class Worker
    {
        private Zoo Zoo { get; set; }
        public Worker()
        {
            this.Zoo = new Zoo();
        }

        public void FeedAnimals()
        {
            Timer timer = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds);

            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                for(int i = 0; i < Zoo.Cages.Count; i++)
                {
                    Zoo.Cages[i].LeaveFood();
                }
            }
        }

        public void AddCage(Cage cage)
        {
            Zoo.Cages.Add(cage);
            FeedAnimals();
        }

        public void EditCage(Cage cage, List<Animal> animals)
        {
            for(int i = 0; i < animals.Count; i++)
            {
                cage.Animals.Add(animals[i]);
            }
        }

        public Cage GetCage(string code)
        {
            foreach (Cage cage in Zoo.Cages)
            {
                if (cage.CheckCageCode(code))
                {
                    return cage;
                }
            }
            throw new Exception("Invalid code;");
        }
    }
}
