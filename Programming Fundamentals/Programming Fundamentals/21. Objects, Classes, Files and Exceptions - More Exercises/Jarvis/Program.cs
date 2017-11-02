using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Jarvis
{
    class Arm
    {
        public int EnergyConsumption { get; set; }
        public int ReachDistance { get; set; }
        public int CountOfFingers  { get; set; }
    }

    class Leg
    {
        public int EnergyConsumption { get; set; }
        public int Strength  { get; set; }
        public int Speed { get; set; }
    }

    class Torso
    {
        public int EnergyConsumption { get; set; }
        public double ProcessorSizeInCentimeters  { get; set; }
        public string Material { get; set; }
    }

    class Head
    {
        public int EnergyConsumption { get; set; }
        public int IQ { get; set; }
        public string Material { get; set; }
    }

    class Robot
    {
        public string Name { get; set; }
        public List<Arm> Arms { get; set; }
        public List<Leg> Legs { get; set; }
        public Torso Torso { get; set; }
        public Head Head { get; set; }

        public bool IsBuild()
        {
            bool isBuild = (Arms.Count == 2) &&
                           (Legs.Count == 2) &&
                           (Torso.Material != null) &&
                           (Head.Material != null);

            return isBuild;
        }

        public long TotalEnergyConsumption()
        {
            long result = Arms.Sum(a => (long)a.EnergyConsumption) +
                          Legs.Sum(l => (long)l.EnergyConsumption) +
                          Torso.EnergyConsumption +
                          Head.EnergyConsumption;

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            long maximumEnergyCapacity = long.Parse(Console.ReadLine());

            Robot jarvis = new Robot
            {
                Name = "Jarvis",
                Arms = new List<Arm>(),
                Legs = new List<Leg>(),
                Torso = new Torso(),
                Head = new Head()
            };

            ReadComponents(jarvis);
            PrintRobot(jarvis, maximumEnergyCapacity);
        }

        private static void ReadComponents(Robot jarvis)
        {

            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("Assemble!"))
            {
                string element = input.Substring(0, input.IndexOf(" "));
                switch(element)
                {
                    case "Arm":
                        SelectArmByMinEnergyConsumption(ReadArm(input), jarvis.Arms);
                        break;

                    case "Leg":
                        SelectLegByMinEnergyConsumption(ReadLeg(input), jarvis.Legs);
                        break;

                    case "Torso":
                        SelectTorsoByMinEnergyConsumption(ReadTorso(input), jarvis);
                        break;

                    case "Head":
                        SelectHeadByMinEnergyConsumption(ReadHead(input), jarvis);
                        break;
                }
            }
        }

        private static Arm ReadArm(string input)
        {
            string[] elements = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Arm arm = new Arm
            {
                EnergyConsumption = int.Parse(elements[1]),
                ReachDistance = int.Parse(elements[2]),
                CountOfFingers = int.Parse(elements[3])
            };

            return arm;
        }

        private static Leg ReadLeg(string input)
        {
            string[] elements = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Leg leg = new Leg
            {
                EnergyConsumption = int.Parse(elements[1]),
                Strength = int.Parse(elements[2]),
                Speed = int.Parse(elements[3])
            };

            return leg;
        }

        private static Torso ReadTorso(string input)
        {
            string[] elements = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Torso torso = new Torso
            {
                EnergyConsumption = int.Parse(elements[1]),
                ProcessorSizeInCentimeters = double.Parse(elements[2]),
                Material = elements[3]
            };

            return torso;
        }

        private static Head ReadHead(string input)
        {
            string[] elements = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Head head = new Head
            {
                EnergyConsumption = int.Parse(elements[1]),
                IQ = int.Parse(elements[2]),
                Material = elements[3]
            };

            return head;
        }

        private static void SelectArmByMinEnergyConsumption(Arm newArm, List<Arm> arms)
        {
            if(arms.Count < 2)
            {
                arms.Add(newArm);
            }
            else
            {
                for (int i = 0; i < arms.Count; i++)
                {
                    if (newArm.EnergyConsumption < arms[i].EnergyConsumption)
                    {
                        arms[i] = newArm;
                        break;
                    }
                }
            }
        }

        private static void SelectLegByMinEnergyConsumption(Leg newLeg, List<Leg> legs)
        {
            if (legs.Count < 2)
            {
                legs.Add(newLeg);
            }
            else
            {
                for (int i = 0; i < legs.Count; i++)
                {
                    if (newLeg.EnergyConsumption < legs[i].EnergyConsumption)
                    {
                        legs[i] = newLeg;
                        break;
                    }
                }
            }
        }

        private static void SelectTorsoByMinEnergyConsumption(Torso newTorso, Robot jarvis)
        {
            if ((jarvis.Torso.EnergyConsumption == 0) || (newTorso.EnergyConsumption < jarvis.Torso.EnergyConsumption))
            {
                jarvis.Torso = newTorso;
            }
        }

        private static void SelectHeadByMinEnergyConsumption(Head newHead, Robot jarvis)
        {
            if ((jarvis.Head.EnergyConsumption == 0) || (newHead.EnergyConsumption < jarvis.Head.EnergyConsumption))
            {
                jarvis.Head = newHead;
            }
        }

        private static void PrintRobot(Robot jarvis, long maximumEnergyCapacity)
        {
            if (!jarvis.IsBuild())
            {
                Console.WriteLine("We need more parts!");
            }
            else if (jarvis.TotalEnergyConsumption() > maximumEnergyCapacity)
            {
                Console.WriteLine("We need more power!");
            }

            else
            {
                jarvis.Arms = jarvis.Arms.OrderBy(a => a.EnergyConsumption).ToList();
                jarvis.Legs = jarvis.Legs.OrderBy(l => l.EnergyConsumption).ToList();

                Console.WriteLine($"{jarvis.Name}:");

                Console.WriteLine("#Head:");
                Console.WriteLine($"###Energy consumption: {jarvis.Head.EnergyConsumption}");
                Console.WriteLine($"###IQ: {jarvis.Head.IQ}");
                Console.WriteLine($"###Skin material: {jarvis.Head.Material}");

                Console.WriteLine("#Torso:");
                Console.WriteLine($"###Energy consumption: {jarvis.Torso.EnergyConsumption}");
                Console.WriteLine($"###Processor size: {jarvis.Torso.ProcessorSizeInCentimeters:F1}");
                Console.WriteLine($"###Corpus material: {jarvis.Torso.Material}");

                Console.WriteLine("#Arm:");
                Console.WriteLine($"###Energy consumption: {jarvis.Arms[0].EnergyConsumption}");
                Console.WriteLine($"###Reach: {jarvis.Arms[0].ReachDistance}");
                Console.WriteLine($"###Fingers: {jarvis.Arms[0].CountOfFingers}");

                Console.WriteLine("#Arm:");
                Console.WriteLine($"###Energy consumption: {jarvis.Arms[1].EnergyConsumption}");
                Console.WriteLine($"###Reach: {jarvis.Arms[1].ReachDistance}");
                Console.WriteLine($"###Fingers: {jarvis.Arms[1].CountOfFingers}");

                Console.WriteLine("#Leg:");
                Console.WriteLine($"###Energy consumption: {jarvis.Legs[0].EnergyConsumption}");
                Console.WriteLine($"###Strength: {jarvis.Legs[0].Strength}");
                Console.WriteLine($"###Speed: {jarvis.Legs[0].Speed}");

                Console.WriteLine("#Leg:");
                Console.WriteLine($"###Energy consumption: {jarvis.Legs[1].EnergyConsumption}");
                Console.WriteLine($"###Strength: {jarvis.Legs[1].Strength}");
                Console.WriteLine($"###Speed: {jarvis.Legs[1].Speed}");
            }
        }
    }
}
