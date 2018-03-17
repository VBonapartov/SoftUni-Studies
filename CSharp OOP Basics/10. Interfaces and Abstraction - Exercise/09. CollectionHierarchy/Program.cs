namespace _09._CollectionHierarchy
{
    using System;
    using System.Text;

    public class Program
    {
        private static IAddCollection<string> addCollection;
        private static IAddRemoveCollection<string> addRemoveCollection;
        private static IMyList<string> myList;

        private static StringBuilder result;

        public static void Main(string[] args)
        {
            result = new StringBuilder();
            Run();
        }

        private static void Run()
        {
            InitializeCollections();
            RemoveOperations();

            PrintResult();
        }

        private static void InitializeCollections()
        {
            string[] input = Console.ReadLine().Split(' ');

            addCollection = new AddCollection<string>();
            addRemoveCollection = new AddRemoveCollection<string>();
            myList = new MyList<string>();

            AddOperation(input, addCollection);
            AddOperation(input, addRemoveCollection);
            AddOperation(input, myList);
        }

        private static void AddOperation(string[] input, IAddCollection<string> collection)
        {
            foreach (string str in input)
            {
                int index = collection.Add(str);
                result.Append($"{index} ");
            }

            result.Remove(result.Length - 1, 1).AppendLine();
        }

        private static void RemoveOperations()
        {
            int numberOfRemovals = int.Parse(Console.ReadLine());

            RemoveOperation(numberOfRemovals, addRemoveCollection);
            RemoveOperation(numberOfRemovals, myList);
        }

        private static void RemoveOperation<T>(int numberOfRemovals, IAddRemoveCollection<T> collection)
        {
            for (int i = 0; i < numberOfRemovals; i++)
            {
                var removedElement = collection.Remove();
                result.Append($"{removedElement} ");
            }

            result.Remove(result.Length - 1, 1).AppendLine();
        }

        private static void PrintResult()
        {
            Console.WriteLine(result);
        }
    }
}
