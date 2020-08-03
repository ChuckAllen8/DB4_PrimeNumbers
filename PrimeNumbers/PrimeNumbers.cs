using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbers
{
    public class PrimeNumbers
    {
        private static List<int> primes;
        public PrimeNumbers()
        {
            if(primes == null)
            {
                primes = new List<int>()
                {
                    2 //add the first prime
                };
            }
        }

        public int GetPrime(int n)
        {
            if(primes.Count >= n && primes.Count > 0)
            {
                return primes[n - 1];
            }

            int number = primes[^1] + 1; //start at last known prime. plus 1
            bool thisPrime = true; // a number is prime until proven otherwise.

            while(true)
            {
                thisPrime = true;
                if(primes.Count == n)
                {
                    break;
                }

                foreach(int prime in primes)
                {
                    if(number % prime == 0)
                    {
                        // check existing primes to see if the number is divisible by them
                        thisPrime = false;
                        break;
                    }
                    else if(prime*prime > number)
                    {
                        // if we are greater than the square root there cannot be two factors besides 1 and the number
                        break; 
                    }
                }
                if(thisPrime)
                {
                    primes.Add(number);
                }
                number++;
            }
            return primes[^1]; //return last prime found
        }
    }
}
