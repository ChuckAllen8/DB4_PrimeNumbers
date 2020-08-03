using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbers
{
    class PrimeNumbersApp
    {
        public void Start()
        {
            PrimeNumbers numbers = new PrimeNumbers();
            Validator validator = new Validator();
            Console.WriteLine("Let's locate some primes!");
            Console.WriteLine("This application will find any n-th prime number, in order, from the first prime on.");
            string goAgain;
            do
            {
                string input = "";

                while(!validator.AcceptableInput(input))
                {
                    Console.Write("Which prime number are you looking for? ");
                    input = Console.ReadLine();
                }

                int n = int.Parse(input);
                Console.WriteLine($"\nThe {n}{NumberEnding(n)} prime number is {numbers.GetPrime(n)}\n");

                while(!validator.ParseYN(input, out goAgain))
                {
                    Console.Write("Do you want to find another prime number? (Y/N): ");
                    input = Console.ReadLine();
                }
                Console.WriteLine();
            } while (goAgain == "Y");
        }

        private string NumberEnding(int number)
        {
            if(number > 9 && number < 21)
            {
                return "th";
            }
            switch (number%10)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }
    }
}
