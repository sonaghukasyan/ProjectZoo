using System;
using System.Collections.Generic;
using System.Timers;
using ZooProject.CageTypes;
using ZooProject.FileLogger;

namespace ZooProject.Types
{
    public abstract class Animal
    {
        protected int _stomach { get; set; }
        protected int _maxSize { get; set; }
        protected string _code { get; set; }
        protected int _stomachSize { get; set; }
        protected int _stomachDelta { get; set; }
        protected int _seconds { get; set; }
        public bool IsAlive { get; set; }
        public bool IsHungry { get; set; }

        protected Cage Cage { get; set; }
        protected Logger _logger { get; set; }

        public AnimalType Type { get; set; }
        public List<FeedTypes> FeedTypes { get; set; }

        public void SetCage(Cage cage)
        {
            this.Cage = cage;
            Cage.FoodArived += Feed;
        }

       
        public virtual void Feed(FeedTypes food)
        {
            this.State();
            if (this.IsAlive == false)
            {
                throw new Exception($"{this.Type} with code {this._code} is dead and cannot eat.");
            }
            else if (this.IsHungry == false)
            {
                throw new Exception($" This {this.Type}  with code {this._code} is not hungry.");
            }

            for (int i = 0; i < this.FeedTypes.Count; i++)
            {
                if (FeedTypes[i] == food)
                {
                    this._stomach = this._maxSize;
                    _logger.Info($" This {this.Type}  with code {this._code} successfuly ate.");
                    return;
                }
            }
            throw new Exception($"Not suitable food for {this.Type}.");
        }

        public virtual void GetHungry()
        {
            this.State();
            Timer timer = new Timer(TimeSpan.FromSeconds(this._seconds).TotalMilliseconds);

            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


            void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                this._stomach -= this._stomachDelta;
            }
        }

        public void AliveState()
        {
            if (this._stomach <= 0)
            {
                this.IsAlive = false;
            }
        }

        public virtual void State()
        {
            AliveState();
            if (this._stomach <= this._stomachSize)
            {
                this.IsHungry = true;
            }
            else
            {
                this.IsHungry = false;
            }
        }
    }
}


