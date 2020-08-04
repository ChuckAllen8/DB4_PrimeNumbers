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

        public bool GetPrimeComponents(double number, out int prime1, out int prime2)
        {
            double cap = Math.Ceiling(Math.Sqrt(number));
            int primeCount = 1;
            while (primes[^1] <= cap)
            {
                GetPrime(primeCount);
                primeCount++;
            }
            
            for (int index = 0; index < primes.Count; index++)
            {
                if(number % primes[index] == 0)
                {
                    int highNumber = (int)(number / primes[index]);

                    while (primes[^1] < highNumber)
                    {
                        GetPrime(primeCount);
                        primeCount++;
                    }

                    if(primes.Contains(highNumber))
                    {
                        prime1 = primes[index];
                        prime2 = (int)(number / primes[index]);
                        return true;
                    }

                    break;
                }
            }
            prime1 = default;
            prime2 = default;
            return false;
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
