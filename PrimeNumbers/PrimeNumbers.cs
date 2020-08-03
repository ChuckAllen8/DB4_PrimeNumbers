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

            int number = primes[^1]; //start at last known prime
            bool thisPrime = true; // a number is prime until proven otherwise.

            while(true)
            {
                thisPrime = true;
                if(primes.Count == n)
                {
                    break;
                }

                // check existing primes to see if the number is divisible by them
                foreach(int prime in primes)
                {
                    if(number % prime == 0)
                    {
                        thisPrime = false;
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
