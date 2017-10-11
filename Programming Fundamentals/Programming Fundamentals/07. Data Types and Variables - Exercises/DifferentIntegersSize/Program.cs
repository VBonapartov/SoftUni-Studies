using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentIntegersSize
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal input = decimal.Parse(Console.ReadLine()); ;

            StringBuilder output = new StringBuilder();
            // sbyte
            try
            {
                sbyte n = Convert.ToSByte(input);
                output.Append("* sbyte\n");
            }
            catch(OverflowException e)
            {
                
            }

            // byte
            try
            {
                byte n = Convert.ToByte(input);
                output.Append("* byte\n");
            }
            catch (OverflowException e)
            {
                
            }

            // short
            try
            {
                short n = Convert.ToInt16(input);
                output.Append("* short\n");
            }
            catch (OverflowException e)
            {
                
            }

            // ushort
            try
            {
                ushort n = Convert.ToUInt16(input);
                output.Append("* ushort\n");
            }
            catch (OverflowException e)
            {
                
            }

            // int
            try
            {
                int n = Convert.ToInt32(input);
                output.Append("* int\n");
            }
            catch (OverflowException e)
            {
                
            }

            // uint
            try
            {
                uint n = Convert.ToUInt32(input);
                output.Append("* uint\n");
            }
            catch (OverflowException e)
            {
                
            }

            // long
            try
            {
                long n = Convert.ToInt64(input);
                output.Append("* long\n");
            }
            catch (OverflowException e)
            {
               
            }

            // output
            if (output.Length > 0)
            {
                Console.WriteLine($"{input} can fit in:");
                Console.Write(output);
            }
            else
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }
    }
}
