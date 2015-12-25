namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var command = "start";
            var army = new Army();

            while (command != "end")
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                command = input[0];

                switch (command)
                {
                    case "add":
                        {
                            var name = input[1];
                            var type = input[2];
                            var attack = int.Parse(input[3]);
                            army.Add(name, type, attack);
                            break;
                        }
                    case "find":
                        {
                            var type = input[1];
                            army.Find(type);
                            break;
                        }
                    case "power":
                        {
                            var power = int.Parse(input[1]);
                            army.Power(power);
                            break;
                        }
                    case "remove":
                        {
                            var name = input[1];
                            army.Remove(name);
                            break;
                        }
                    default:
                        break;
                }
            }

        }
    }

    public class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public int CompareTo(Unit other)
        {
            if (this.Attack == other.Attack)
            {
                // may be opposite
                return this.Name.CompareTo(other.Name);
            }
            else
            {
                return other.Attack.CompareTo(this.Attack);
            }
        }
    }

    public class Army
    {
        private HashSet<string> unitNames;
        private Dictionary<string, SortedSet<Unit>> unitsByType;
        private SortedDictionary<int, SortedSet<Unit>> unitsByPower;
        private Dictionary<string, Unit> unitsByName;

        public Army()
        {
            this.unitNames = new HashSet<string>();
            this.unitsByName = new Dictionary<string, Unit>();
            this.unitsByType = new Dictionary<string, SortedSet<Unit>>();
            this.unitsByPower = new SortedDictionary<int, SortedSet<Unit>>();
        }

        public void Add(string name, string type, int attack)
        {
            if (this.unitNames.Contains(name))
            {
                Console.WriteLine("FAIL: {0} already exists!", name);
                return;
            }
            else
            {
                var unitToAdd = new Unit(name, type, attack);
                Console.WriteLine("SUCCESS: {0} added!", name);

                this.unitNames.Add(name);
                this.unitsByName.Add(name, unitToAdd);

                if (this.unitsByType.ContainsKey(type))
                {
                    this.unitsByType[type].Add(unitToAdd);
                }
                else
                {
                    this.unitsByType.Add(type, new SortedSet<Unit>() { unitToAdd });
                }

                if (this.unitsByPower.ContainsKey(-attack))
                {
                    this.unitsByPower[-attack].Add(unitToAdd);
                }
                else
                {
                    this.unitsByPower.Add(-attack, new SortedSet<Unit>() { unitToAdd });
                }
            }
        }

        public void Find(string type)
        {
            if (this.unitsByType.ContainsKey(type))
            {
                var units = this.unitsByType[type].Take(10);

                Console.WriteLine("RESULT: {0}", string.Join(", ", units));
            }
            else
            {
                Console.WriteLine("RESULT: ");
            }
        }

        public void Power(int number)
        {
            var listOfUnitsToBePrinted = new List<Unit>();

            if (number == 0)
            {
                Console.WriteLine("RESULT: ");
            }
            else
            {
                var currentCount = 0;
                foreach (var listOfUnits in this.unitsByPower)
                {
                    if (currentCount + listOfUnits.Value.Count >= number)
                    {
                        foreach (var unit in listOfUnits.Value)
                        {
                            if (listOfUnitsToBePrinted.Count == number)
                            {
                                break;
                            }
                            else
                            {
                                listOfUnitsToBePrinted.Add(unit);
                            }
                        }
                        //for (int i = 0; i < number - currentCount; i++)
                        //{
                        //    listOfUnitsToBePrinted.Add(listOfUnits.Value[i]);
                        //}

                        break;
                    }
                    else
                    {
                        foreach (var unit in listOfUnits.Value)
                        {
                            listOfUnitsToBePrinted.Add(unit);
                        }
                        currentCount += listOfUnits.Value.Count;
                    }
                }

                Console.WriteLine("RESULT: {0}", string.Join(", ", listOfUnitsToBePrinted));
            }
        }

        internal void Remove(string name)
        {
            if (this.unitNames.Contains(name))
            {
                this.unitNames.Remove(name);
                var unitToRemove = this.unitsByName[name];
                this.unitsByPower[-unitToRemove.Attack].Remove(unitToRemove);
                this.unitsByType[unitToRemove.Type].Remove(unitToRemove);
                this.unitsByName.Remove(name);
                Console.WriteLine("SUCCESS: {0} removed!", name);
            }
            else
            {
                Console.WriteLine("FAIL: {0} could not be found!", name);
            }
        }
    }
}
