using System;
using System.Collections.Generic;
using ZooProject.FileLogger;
using ZooProject.Types;

namespace ZooProject.CageTypes
{
    
    public abstract class Cage
    {
        public List<Animal> Animals { get; set; }
        public AnimalType AnimalType { get; set; }
        protected string _cageCode { get; set; }
        public FeedTypes Food { get; set; }
        public int FoodWeight { get; set; }
        public int MaxWeight { get; set; }
        protected int _code { get; set; }

        public event EventHandler<FoodArrivedArgs> FoodArived;
        protected Logger _logger { get; set; }

        public int GetCode()
        {
            return this._code;
        }

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
            FoodWeight = MaxWeight;
            _logger.Info("Food arrived.");

            for(int i = 0; i < FoodArived.GetInvocationList().Length; i++)
            {
                try
                {
                    FoodArived?.Invoke(this, new FoodArrivedArgs(Food));
                    
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
            } 
        }
    }
}
