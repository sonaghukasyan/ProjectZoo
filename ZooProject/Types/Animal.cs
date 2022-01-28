using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ZooProject.Types
{
    public abstract class Animal
    {
        protected int Stomach { get; set; }
        protected int MaxSize { get; set; }
        protected string Code { get; set; }
        protected int StomachSize { get; set; }
        protected int StomachDelta { get; set; }
        protected int Seconds { get; set; }
        public bool IsAlive { get; set; }
        public bool IsHungry { get; set; }
        

        public AnimalType Type { get; set; }
        public List<FeedTypes> FeedTypes { get; set; }

        public virtual void Feed(FeedTypes food)
        {
            this.State();
            if (this.IsAlive == false)
            {
                throw new Exception("This animal is dead and cannot eat.");
            }
            else if (this.IsHungry == false)
            {
                throw new Exception("This animal is not hungry.");
            }
            //TODO Իսկ հակառակ դեպքում, ոչ մի բան չի? անում
            //ես մեթոդը կանչել եմ կլասներում առանձին ու հակառակ դեպքում էդ տեղի գրածնա անում
        }

        public virtual void GetHungry()
        {
            this.State();
            Timer timer = new Timer(TimeSpan.FromSeconds(this.Seconds).TotalMilliseconds);

            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


            void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                this.Stomach -= this.StomachDelta;
            }
        }

        public  void AliveState()
        {
            if(this.Stomach <= 0)
            {
                this.IsAlive = false;
            }
        }

        public virtual bool CheckCode(string code)
        {
            return this.Code == code;
        }

        public virtual void State()
        {
            AliveState();
            if (this.Stomach <= this.StomachSize)
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


