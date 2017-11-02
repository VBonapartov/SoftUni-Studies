using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stateless
{
    class Program
    {
        static void Main(string[] args)
        {
            string state = string.Empty;
            while(!(state = Console.ReadLine()).Equals("collapse"))
            {
                string fiction = Console.ReadLine();

                while (fiction.Length != 0)
                {
                    int index = 0;
                    while ((index = state.IndexOf(fiction)) != -1)
                    {
                        state = state.Substring(0, index) + state.Substring(index + fiction.Length).Trim();
                    }

                    if (fiction.Length < 3)
                    {
                        fiction = "";
                    }
                    else
                    {
                        fiction = fiction.Substring(1, fiction.Length - 2);
                    }
                }

                if (state.Length > 0)
                {
                    Console.WriteLine(state);
                }
                else
                {
                    Console.WriteLine("(void)");
                }
            }            
        }
    }
}
