namespace _03._IteratorTest
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExecuteCommands();
        }

        private static void ExecuteCommands()
        {
            string[] inputArgs = Console.ReadLine().Split();
            ListIterator iterator = new ListIterator(inputArgs.Skip(1));
            //MethodInfo[] iteratorMethods = iterator.GetType().GetMethods();

            string command = string.Empty;

            while (!(command = Console.ReadLine()).Equals("END"))
            {
                try
                {
                    switch (command)
                    {
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;

                        case "Move":
                            Console.WriteLine(iterator.Move());
                            break;

                        case "Print":
                            Console.WriteLine(iterator.Print());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //try
                //{
                //    var parsedMethod = iteratorMethods.FirstOrDefault(m => m.Name == command);

                //    if (parsedMethod == null)
                //    {
                //        Console.WriteLine($"This option {command} does not exists");
                //    }

                //    Console.WriteLine(parsedMethod.Invoke(iterator, new object[] { }));
                //}
                //catch (TargetInvocationException tie)
                //{
                //    if (tie.InnerException is InvalidOperationException)
                //    {
                //        Console.WriteLine(tie.InnerException.Message);
                //    }
                //}
                //catch (ArgumentNullException ane)
                //{
                //    Console.WriteLine(ane.Message);
                //}
            }
        }
    }
}
