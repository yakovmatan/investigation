using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.iranianAgents
{
    internal abstract class Agent
    {
        public string type { get; }
        protected static Random random = new Random();
        protected string[] weaknessSensors;

        public Agent(int numOfSensors,List<string> availableSensors)
        {
            InitializeRandomSensors(numOfSensors, availableSensors);
        }
        protected void InitializeRandomSensors(int numOfSensors,List<string> availableSensors)
        {
            weaknessSensors = new string[numOfSensors];
            for (int i = 0; i < numOfSensors; i++)
            {
                int index = random.Next(availableSensors.Count);
                weaknessSensors[i] = availableSensors[index];
            }    
        }

    }
}
