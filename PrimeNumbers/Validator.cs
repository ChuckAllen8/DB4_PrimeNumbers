using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbers
{
    public class Validator
    {
        public bool AcceptableInput(string input)
        {
            if(!int.TryParse(input, out int number))
            {
                //not really a number
                return false;
            }
            else if (number <= 0)
            {
                //an invalid number
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ParseYN(string input, out string selection)
        {
            if(input.ToUpper() == "Y" || input.ToUpper() == "YES")
            {
                selection = "Y";
                return true;
            }
            else if(input.ToUpper() == "N" || input.ToUpper() == "NO")
            {
                selection = "N";
                return true;
            }
            else
            {
                selection = default;
                return false;
            }
        }
    }
}
