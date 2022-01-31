using System;
using System.Collections.Generic;
using ZooProject.FileLogger;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    public abstract class Cage
    {
        protected List<Animal> Animals { get; set; }
        public AnimalType AnimalType { get; set; }
        protected string _cageCode { get; set; }
        protected List<FeedTypes> _menu { get; set; }

        public event Action<FeedTypes> FoodArived;
        protected Logger _logger { get; set; }


        public void AddAnimal(Animal animal)
        {
            this.Animals.Add(animal);
            animal.SetCage(this);
        }

        public bool CheckCageCode(string cageCode)
        {
            return cageCode == this._cageCode;
        }
        public void LeaveFood()
        {
            foreach(Animal animal in Animals)
            {
                _logger.Info("Food arrived.");
                try
                {
                    FoodArived?.Invoke(_menu[0]);
                }
                catch(Exception ex)
                {
                    _logger.Error(ex.Message);
                }
                
            }
        }
    }
}
