using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using investigation.DataBase;
using investigation.iranianAgents;
using investigation.sensors;

namespace investigation.manager
{
    internal class InvestigationController
    {
        private int currentAgentIndex = 1;
        private InvestigationSupport logic = new InvestigationSupport();
        private string currentUser;
            
        public InvestigationController()
        {
            Console.WriteLine("Enter your username");
            currentUser = Console.ReadLine();

            currentAgentIndex = DalUserProgress.LoadProgress(currentUser);

            this.ShowWelcome();
            InitCurrentAgent();

        }

        private void InitCurrentAgent()
        {
            Agent currentAgent = AgentFactory.createAgent(currentAgentIndex,logic.SensorTypes);
            logic.InitNewAgent(currentAgent);
            Console.WriteLine($"\n--- New Iranian Agent Detected: {currentAgent.type.ToUpper()} ---");
        }

        public void ShowWelcome()
        {
            Console.WriteLine("Welcome to the investigation game!");
            Console.WriteLine("Investigation begining...");
            Console.WriteLine("Terrorist is waitin in room 8");
        }

        public void InvastigationRound()
        {
            Console.WriteLine($"In which location would you like to set the sensor? (0 - {logic.GetRequiredSensorCount() - 1})");
            int chosenIndex = this.ValidIndexSelection();
            Console.WriteLine("Available sensor types:");
            Console.WriteLine(string.Join(", ", logic.SensorTypes));
            string choose = this.ValidSensorSelection();
            Sensor sensor = SensorFactory.CreateSensor(choose);
            logic.AttachSensor(chosenIndex, sensor);
            logic.ActivateSensors();
            logic.HandleAttack();
        }

        public void ShowMatches()
        {
            Console.WriteLine("\nSensor bar:");

            foreach (var sensor in logic.room.attachedSensore)
            {
                if (sensor == null)
                {
                    Console.Write("[●]  ");
                }
                else
                {
                    string symbol;

                    switch (sensor.type)
                    {
                        case "audio": symbol = "🔊"; break;
                        case "thermal": symbol = "🔥"; break;
                        case "pulse": symbol = "💓"; break;
                        case "motion": symbol = "🕴"; break;
                        case "magnetic": symbol = "🧲"; break;
                        default: symbol = "❓"; break;
                    }


                    if (!sensor.active)
                        symbol += "🛑";

                    Console.Write($"[{symbol}]  ");
                }
            }

            Console.WriteLine("\n");
        
        int numOfMatches = logic.GetMatchCount();
            int required = logic.GetRequiredSensorCount();
            Console.WriteLine($"{numOfMatches}/{required} matched");
            
        }

        public bool ContinueGame()
        {
            if (logic.IsFullMatched())
            {
                Console.WriteLine($"✔ Iranian agent exposed! ({logic.agent.type})");
                currentAgentIndex++;

                DalUserProgress.SaveProgress(currentUser, currentAgentIndex);
                if (currentAgentIndex < AgentFactory.GetTotalAgentTypes())
                {
                    Console.WriteLine("\n➡ Proceeding to the next agent...");
                    InitCurrentAgent();
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
            
            while (true)
            {
                string choose = Console.ReadLine().ToLower();
                if (logic.SensorTypes.Contains(choose))
                {
                    return choose;
                }

                Console.WriteLine("Invalid sensor type. Please choose from the available sensors:");
                Console.Write("Available types: ");
                Console.WriteLine(string.Join(", ", logic.SensorTypes));

            }
            

        }

        private int ValidIndexSelection()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int chosenIndex) && chosenIndex >= 0 && chosenIndex < logic.GetRequiredSensorCount())
                {
                    return chosenIndex;
                }

                Console.WriteLine($"Invalid number. Please enter a number between 0 and {logic.GetRequiredSensorCount() - 1}.");
            }
        }
    }
}
