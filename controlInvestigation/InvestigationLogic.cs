using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using investigation.iranianAgents;
using investigation.room;
using investigation.sensors;

namespace investigation.manager
{
    internal class InvestigationLogic
    {
        public Agent agent;
        public Room room;

        public InvestigationLogic(Agent agent,int length)
        {
            room = new Room(length);
            this.agent = agent;
        }

        // function to active sensor
        public void ActivateSensors()
        {
            foreach (var sensor in this.room.attachedSensore)
            {
                if (sensor == null)
                    continue;
                sensor.Activate();
            }
        }
        // function to get how much is maches
        public int NumOfMatches()
        {
            return room.NumOfMatches(agent.GetSensorRequirementCount());
        }
    }
}
