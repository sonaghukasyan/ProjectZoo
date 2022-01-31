using System;
using System.Collections.Generic;
using ZooProject.CageTypes;
using ZooProject.FileLogger;
using ZooProject.Logic;
using ZooProject.Types;

namespace ZooProject.UI
{
    class UIConsole
    {
        private Logger _logger { get; set; }
        private Worker _worker { get; set; }

        public UIConsole()
        {
            this._worker = new Worker();
            _logger = Logger.GetOrSetLogger();
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
                _worker.GetCage(cageCode);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                _logger.Error(ex);
                SeeCage();
            }

            Cage cage = _worker.GetCage(cageCode);
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

            _worker.AddCage(cage);
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

            _worker.EditCage(cage, animals);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex);
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
            if (cage.AnimalType == animalType)
            {
                return;
            }
            throw new Exception("This cage cannot contain that type of animals.");
        }
    }
}
