using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalException
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
            : base()
        {
        }

        public NegativeNumberException(String message)
            : base(message)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number >= 0)
                    {
                        Console.WriteLine(number);
                    }
                    else
                    {
                        throw new NegativeNumberException("My first exception is awesome!!!");
                    }
                }
            }
            catch (NegativeNumberException nnex)
            {
                Console.WriteLine(nnex.Message);
            }
        }
    }
}
