namespace _06._Animals.Animals
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Animal : ISoundProducable
    {
        private const string ErrorMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                NotEmptyValidation(value);
                this.name = value;
            }
        }

        private int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.age = value;
            }
        }

        private string Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                NotEmptyValidation(value);
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(this.ProduceSound());

            return sb.ToString();
        }

        private static void NotEmptyValidation(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Equals(string.Empty))
            {
                throw new ArgumentException(ErrorMessage);
            }
        }
    }
}
