using System;
using System.Collections.Generic;

namespace ZooManagementSystem
{

    public abstract class Animal
    {
        public string Species { get; protected set; }
        public string Name { get; protected set; }
        public int Age { get; protected set; }

        public Animal(string species, string name, int age)
        {
            Species = species;
            Name = name;
            Age = age;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Species: {Species}, Name: {Name}, Age: {Age}");
        }

        public abstract void Feed();
    }

    public class Mammal : Animal
    {
        public string FurColor { get; private set; }

        public Mammal(string species, string name, int age, string furColor)
            : base(species, name, age)
        {
            FurColor = furColor;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Fur Color: {FurColor}");
        }

        public override void Feed()
        {
            Console.WriteLine($"{Name} the {Species} is being fed with mammal-specific diet.");
        }
    }

    public class Bird : Animal
    {
        public double WingSpan { get; private set; }

        public Bird(string species, string name, int age, double wingSpan)
            : base(species, name, age)
        {
            WingSpan = wingSpan;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Wing Span: {WingSpan} cm");
        }

        public override void Feed()
        {
            Console.WriteLine($"{Name} the {Species} is being fed with bird-specific diet.");
        }
    }

    public class Zoo
    {
        public string Name { get; private set; }
        private List<Animal> Animals { get; set; }

        public Zoo(string name)
        {
            Name = name;
            Animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine($"{animal.Name} has been added to {Name} Zoo");
        }

        public void DisplayAllAnimals()
        {
            Console.WriteLine($"\nAnimals in {Name} Zoo:");
            foreach (var animal in Animals)
            {
                animal.DisplayInfo();
                Console.WriteLine(); 
            }
        }

        public void FeedAllAnimals()
        {
            Console.WriteLine($"\nFeeding all animals in {Name} Zoo:");
            foreach (var animal in Animals)
            {
                animal.Feed();
            }
        }

        public int GetTotalAnimals()
        {
            return Animals.Count;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo tiranaZoo = new Zoo("Tirana");
            Mammal bear = new Mammal("Bear", "Poo", 5, "brown");
            Mammal monkey = new Mammal("Monkey", "Steve", 10, "black");
            Bird parrot = new Bird("Parrot", "Loli", 1, 28);

            tiranaZoo.AddAnimal(bear);
            tiranaZoo.AddAnimal(monkey);
            tiranaZoo.AddAnimal(parrot);

            tiranaZoo.DisplayAllAnimals();

            tiranaZoo.FeedAllAnimals();
            Console.WriteLine($"\nTotal number of animals in the zoo: { tiranaZoo.GetTotalAnimals() }");
        }
    }
}
