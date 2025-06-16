using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigation.iranianAgents;

namespace investigation.manager
{
    internal class Display
    {
        private List<string> TypesOfSensors = new List<string> { "audio", "thermal" };
        private Manager manager;
        private Dictionary<string, int> numOfSensors = new Dictionary<string, int>
        {
            {"foot soldier",2 },
            {"squad leader", 4 },
            {"senior commander", 6 },
            {"organisation leader", 8 }
        };
            
        public Display()
        {
            manager = new Manager(new FootSoldier(TypesOfSensors));
        }

        public void ShowWelcome()
        {
            Console.WriteLine("Welcome to the investigation game!");
            Console.WriteLine("Investigation begining...");
            Console.WriteLine("Terrorist is waitin in room 8");
        }

        public void EnterChoose()
        {
            Console.WriteLine($"In which location would you like to set the sensor? (0 - {numOfSensors[manager.agent.type] - 1})");
            while (true)
            {
                string input = Console.ReadLine();

                int chosenIndex;
                if (int.TryParse(input, out chosenIndex) && chosenIndex >= 0 && chosenIndex < numOfSensors[manager.agent.type])
                {
                    break; 
                }

                Console.WriteLine($"Invalid number. Please enter a number between 0 and { numOfSensors[manager.agent.type] - 1} :");
            }

            Console.WriteLine("Available sensor type");
            Console.Write("types: ");
            foreach (var sensor in manager.availableSensors)
            {
                Console.Write($"{sensor.Key}, ");
            }
            Console.WriteLine();
            string choose = this.ValidSensorSelection();
            manager.ActivateSensor(choose);
        }

        public bool ShowMatches()
        {
            int numOfMatches = manager.NumOfMatches();
            Console.WriteLine($"{numOfMatches}/{numOfSensors[manager.agent.type]} matched");
            if (numOfMatches == numOfSensors[manager.agent.type])
            {
                Console.WriteLine("Iranian agent exposed!");
                return true;
            }
            return false;
        }

        private string ValidSensorSelection()
        {
            Console.WriteLine("Enter sensor type:");
            string choose;

            while (true)
            {
                choose = Console.ReadLine().ToLower();

                bool isValid = manager.availableSensors.ContainsKey(choose);

                if (isValid)
                {
                    break; 
                }

                Console.WriteLine("Invalid sensor type. Please choose from the available sensors:");
                Console.Write("Available types: ");
                foreach (var sensor in manager.availableSensors)
                {
                    Console.Write(sensor.Key + ", ");
                }
                Console.WriteLine();
            }
            return choose;

        }
    }
}
