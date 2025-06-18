using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigation.iranianAgents;
using investigation.sensors;

namespace investigation.manager
{
    internal class InvestigationController
    {
        private List<string> TypesOfSensors = new List<string> { "audio", "thermal", "pulse", "magnetic", "motion" };
        private List<Agent> agents;
        private int currentAgentIndex = 0;
        private InvestigationLogic manager;
        private Dictionary<string, int> numOfSensors = new Dictionary<string, int>
        {
            {"foot soldier",2 },
            {"squad leader", 4 },
            {"senior commander", 6 },
            {"organisation leader", 8 }
        };
            
        public InvestigationController()
        {
            this.ShowWelcome();
            agents = new List<Agent>
            {
                new FootSoldier(TypesOfSensors),
                new SquadLeader(TypesOfSensors),
                new SeniorCommander(TypesOfSensors),
                new OrganizationLeader(TypesOfSensors)
            };
            InitLogicForCurrentAgent();

        }

        private void InitLogicForCurrentAgent()
        {
            Agent currentAgent = agents[currentAgentIndex];
            int amount = numOfSensors[currentAgent.type];
            manager = new InvestigationLogic(currentAgent, amount);

            Console.WriteLine($"\n--- New Iranian Agent Detected: {currentAgent.type.ToUpper()} ---");
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
            int chosenIndex;
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out chosenIndex) && chosenIndex >= 0 && chosenIndex < numOfSensors[manager.agent.type])
                {
                    break; 
                }

                Console.WriteLine($"Invalid number. Please enter a number between 0 and { numOfSensors[manager.agent.type] - 1}.");
            }

            Console.WriteLine("Available sensor type");
            Console.Write("types: ");
            Console.WriteLine(string.Join(", ", TypesOfSensors));
            string choose = this.ValidSensorSelection();
            Sensor sensor = SensorFactory.CreateSensor(choose);
            manager.room.Attach(chosenIndex, sensor);
            manager.ActivateSensors( );
        }

        public bool ShowMatches()
        {
            int numOfMatches = manager.NumOfMatches();
            Console.WriteLine($"{numOfMatches}/{numOfSensors[manager.agent.type]} matched");
            if (numOfMatches == numOfSensors[manager.agent.type])
            {
                Console.WriteLine($"✔ Iranian agent exposed! ({manager.agent.type})");
                currentAgentIndex++;
                if (currentAgentIndex < agents.Count)
                {
                    Console.WriteLine("\n➡ Proceeding to the next agent...");
                    InitLogicForCurrentAgent();
                    return false;
                }
                else
                {
                    Console.WriteLine("\n🎉🏅 All agents exposed. Mission complete!");
                    return true;
                }
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

                bool isValid = this.TypesOfSensors.Contains(choose);

                if (isValid)
                {
                    break; 
                }

                Console.WriteLine("Invalid sensor type. Please choose from the available sensors:");
                Console.Write("Available types: ");
                Console.WriteLine(string.Join(", ", TypesOfSensors));

            }
            return choose;

        }
    }
}
