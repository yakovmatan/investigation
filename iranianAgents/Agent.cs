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

        public Agent(int numOfSensors,List<string> availableSensors,string type)
        {
            InitializeRandomSensors(numOfSensors, availableSensors);
            this.type = type;
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

        public Dictionary<string,int> GetSensorRequirementCount()
        {
            Dictionary<string, int> dictWeaknessSensors = new Dictionary<string, int>();
            for (int i = 0; i < weaknessSensors.Length; i++)
            {
                if (dictWeaknessSensors.ContainsKey(weaknessSensors[i]))
                {
                    dictWeaknessSensors[weaknessSensors[i]] += 1;
                }
                else
                {
                    dictWeaknessSensors[weaknessSensors[i]] = 1;
                }
            }
            return dictWeaknessSensors;
        }

    }
}
