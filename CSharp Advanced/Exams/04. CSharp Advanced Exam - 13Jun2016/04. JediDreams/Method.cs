namespace _04.JediDreams
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Method
    {
        private List<string> invokedMethods;

        public Method(string name)
        {
            this.Name = name;
            this.invokedMethods = new List<string>();
        }

        public string Name { get; private set; }

        public void AddInvokedMethod(string invokedMethod)
        {
            this.invokedMethods.Add(invokedMethod);
        }

        public int NumberOfInvokedMethods()
        {
            return this.invokedMethods.Count();
        }

        public override string ToString()
        {
            List<string> sortedInvokedMethods = this.invokedMethods.OrderBy(s => s).ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Name} -> ");

            if (this.NumberOfInvokedMethods() == 0)
            {
                sb.Append("None");
            }
            else
            {
                sb.Append($"{this.NumberOfInvokedMethods()} -> {string.Join(", ", sortedInvokedMethods)}");
            }

            return sb.ToString();
        }
    }
}
