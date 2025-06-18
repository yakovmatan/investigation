using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace investigation.iranianAgents
{
    public static class AgentFactory
    {
        public static Agent createAgent(int index, List<string> sensorTypes)
        {
            switch(index)
            {
                case 0: return new FootSoldier(sensorTypes);
                case 1: return new SquadLeader(sensorTypes);
                case 2: return new SeniorCommander(sensorTypes);
                case 3: return new OrganizationLeader(sensorTypes);
                default: throw new ArgumentException("Invalid agent index");
            }
        }

        public static int GetTotalAgentTypes()
        {
            return 4;
        }
    }
}
