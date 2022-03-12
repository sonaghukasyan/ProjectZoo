using System;
using System.Collections.Generic;
using System.Threading;
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

        public int GetCode()
        {
            return int.Parse(this._code);
        }

        public void SetCage(Cage cage)
        {
            this.Cage = cage;
            Cage.FoodArived += FoodArived;
        }

        public void FoodArived(object sender, FoodArrivedArgs args)
        {
            try
            {
                Feed(args.Feed);
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }
            
        }
       
        public virtual void Feed(FeedTypes food)
        {
            if(this.Cage.FoodWeight < this._stomach)
            {
                throw new Exception("No food to eat.");
            }

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
                    this.Cage.FoodWeight -=  this._maxSize - this._stomach;
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

            Thread thread = new Thread(new ThreadStart(Hungry));
            thread.Start();

            //Timer timer = new Timer(TimeSpan.FromSeconds(this._seconds).TotalMilliseconds);

            //timer.AutoReset = true;
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();


            //void Timer_Elapsed(object sender, ElapsedEventArgs e)
            //{
            //    this._stomach -= this._stomachDelta;
            //    this.Feed(this.Cage.Food);
            //}
        }
        
        public void Hungry()
        {
            while (true)
            {
                Thread.Sleep(this._seconds*1000);
                this._stomach -= this._stomachDelta;
                try
                {
                    Feed(this.Cage.Food);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
             
                }
                Console.WriteLine($"animal got hungry");
            }
        }

        public void AliveState()
        {
            if (this._stomach <= 0)
            {
                this.IsAlive = false;
                this._stomach = 0;
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


