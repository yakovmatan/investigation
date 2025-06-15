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
    internal class Manager
    {
        public Agent agent;
        private Sensor audioSensore = new AudioSensor();
        private Sensor thermalSensor = new ThermalSensor();
        public List<Sensor> availableSensors;
        private Room room = new Room();

        public Manager(Agent agent)
        {
            this.agent = agent;
            this.availableSensors = new List<Sensor> { audioSensore, thermalSensor };
        }

        // function to active sensor
        public void ActivateSensor(string type)
        {
            if (type == "audio")
            {
                audioSensore.Activate(room.activeSensore);
            }
            else if (type == "thermal")
            {
                thermalSensor.Activate(room.activeSensore);
            }
        }
        // function to get how much is maches
        public int NumOfMatches()
        {
            return room.NumOfMatches(agent.GetSensorRequirementCount());
        }
    }
}
