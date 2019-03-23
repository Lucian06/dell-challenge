using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
            var human = new Human();
            human.GetSpecies();

            var bird = new Bird();
            bird.GetSpecies();

            var fish = new Fish();
            fish.GetSpecies();
        }
    }

    public interface IDoForLiving
    {
        void Eat();
        void Drink();
    }

    public interface ISwimSpecies : IDoForLiving
    {
        void Swim();
    }

    public interface IFlyingSpecies : IDoForLiving
    {
        void Fly();
    }

    public class Species
    {
        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }
    }

    public class Human : Species, ISwimSpecies
    {
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
        public override void GetSpecies()
        {
            Console.WriteLine($"I am Human");
        }
    }

    public class Bird : Species, IFlyingSpecies
    {
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I am Bird");
        }
    }

    public class Fish : Species, ISwimSpecies
    {
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I am Fish");
        }
    }
}

