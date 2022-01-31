using System;
using System.Collections.Generic;
using System.Timers;
using ZooProject.CageTypes;
using ZooProject.FileLogger;
using ZooProject.Types;

namespace ZooProject.Logic
{
    class Worker
    {
        private Zoo _zoo { get; set; }
        public Worker()
        {
            this._zoo = new Zoo();
        }

        public void FeedAnimals()
        {
            Timer timer = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds);

            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                for (int i = 0; i < _zoo.Cages.Count; i++)
                {
                    _zoo.Cages[i].LeaveFood();
                }
            }
        }

        public void AddCage(Cage cage)
        {
            _zoo.Cages.Add(cage);
            FeedAnimals();
        }

        public void EditCage(Cage cage, List<Animal> animals)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                cage.AddAnimal(animals[i]);
            }
        }

        public Cage GetCage(string code)
        {
            foreach (Cage cage in _zoo.Cages)
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
