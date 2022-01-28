using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.CageTypes;
using ZooProject.Logic;
using ZooProject.Types;

namespace ZooProject.UI
{
    class UIConsole
    {
        private Worker Worker { get; set; }

        public UIConsole()
        {
            this.Worker = new Worker();
        }

        public void Start()
        {
            Console.WriteLine("A.Add Cage     S.See Cage");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    AddCage();
                    Console.Clear();
                    Start();
                    break;
                case ConsoleKey.S:
                    Console.Clear();
                    SeeCage();
                    Console.Clear();
                    Start();
                    break;
                default:
                    Console.Clear();
                    Start();
                    break;
            }
        }

        public void SeeCage()
        {
            Console.Write("CageCode: ");
            string cageCode = Console.ReadLine();
            try
            {
                 Worker.GetCage(cageCode);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                SeeCage();
            }

            Cage cage = Worker.GetCage(cageCode);
            Console.WriteLine(" E.Edit Cage    Esc.Back");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.E:
                    Console.Clear();
                    EditCage(cage);
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Start();
                    break;
            }
        }

        public void AddCage()
        {
            Console.WriteLine("Cage code: ");
            string cageCode = Console.ReadLine();

            Console.WriteLine("Type of animals in cage: D.Dog  L.Lion   F.Fish");
            ConsoleKey key = Console.ReadKey().Key;
            Cage cage = new LionCage(cageCode);

            switch (key)
            {
                case ConsoleKey.D:
                    cage = new DogCage(cageCode);
                    break;
                case ConsoleKey.F:
                    cage = new FishCage(cageCode);
                    break;
            }
            Console.Clear();

            Worker.AddCage(cage);
            EditCage(cage);
        }

        public void EditCage(Cage cage)
        {
            List<Animal> animals = new List<Animal>();
            bool state = true;

            while (state)
            {
                Console.WriteLine("A.Add Animals     Esc.Back");
                ConsoleKey key1 = Console.ReadKey().Key;

                switch (key1)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        animals.Add(AddAnimal(cage));
                        break;
                    default:
                        Console.Clear();
                        state = false;
                        break;
                }
            }

            Worker.EditCage(cage, animals);
        }

        public Animal AddAnimal(Cage cage)
        {
            AnimalType animalType;
            Console.WriteLine("Type: L.Lion  D.Dog  F.Fish");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.L:
                    animalType = AnimalType.lion;
                    break;
                case ConsoleKey.F:
                    animalType = AnimalType.fish;
                    break;
                default:
                    animalType = AnimalType.dog;
                    break;
            }
            Console.Clear();
                
            try
            {
                CheckAnimalType(cage, animalType);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AddAnimal(cage);
            }

            Console.Write("Animal Code: ");
            string code = Console.ReadLine();
            Console.Clear();

            Console.Clear();
            Console.Write("Stomach size: ");
            int stomach = int.Parse(Console.ReadLine());

            Animal animal;
            switch (animalType)
            {
                case AnimalType.lion:
                    animal = new Lion(animalType, code, stomach);
                    break;
                case AnimalType.dog:
                    animal = new Dog(animalType, code, stomach);
                    break;
                default:
                    animal = new Fish(animalType, code, stomach);
                    break;
            }

            return animal;
        }
     

        public void CheckAnimalType(Cage cage, AnimalType animalType)
        {
            if(cage.AnimalType == animalType)
            {
                return;
            }
            throw new Exception("This cage cannot contain that type of animals.");
        }
        /*
         public void FeedAnimal()
         {
            Console.Write("Code: ");
            string code = Console.ReadLine();
            
            try
            {
                 Worker.GetAnimal(code);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                FeedAnimal();
            }

            Animal animal = Worker.GetAnimal(code);
            Console.WriteLine("Which food you prefer?");
            Console.WriteLine("A.cereal  B.meat  C.dryFood D.meat  E.dryFood F.larva  G.crustaceans");


            FeedTypes feed;
            ConsoleKey key = Console.ReadKey().Key;
            
            if (key == ConsoleKey.A)
            {
                feed = FeedTypes.cereal;
            }
            else if (key == ConsoleKey.B || key == ConsoleKey.D)
            {
                feed = FeedTypes.meat;
            }
            else if (key == ConsoleKey.C || key == ConsoleKey.E)
            {
                feed = FeedTypes.dryFood;
            }
            else if (key == ConsoleKey.F)
            {
                feed = FeedTypes.larvae;
            }
            else if (key == ConsoleKey.G)
            {
                feed = FeedTypes.crustaceans;
            }
            else
            {
                feed = FeedTypes.dryFood;
            }

            Console.Clear();

            try
            {
                animal.Feed(feed);
                Console.WriteLine("Done");
                Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                FeedAnimal();
            }
        }
        */

    }
}
