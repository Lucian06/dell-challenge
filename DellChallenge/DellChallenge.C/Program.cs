using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            PrintSum();
            Console.ReadLine();
        }

        private static void PrintSum()
        {
            var operations = new MathOperations();

            Console.WriteLine(operations.Sum(1, 3));
            Console.WriteLine(operations.Sum(1, 3, 5));
        }
    }

    class MathOperations
    {
        public int Sum(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
                sum += number;

            return sum;
        }
    }
}
