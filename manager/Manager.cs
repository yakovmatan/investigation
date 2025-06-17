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
        private Sensor pulseSensor = new PulseSensor();
        public Dictionary<string,Sensor> availableSensors;
        private Room room;

        public Manager(Agent agent,int length)
        {
            room = new Room(length);
            this.agent = agent;
            this.availableSensors = new Dictionary<string,Sensor> 
            {
                {audioSensore.type,audioSensore },
                {thermalSensor.type, thermalSensor },
                {pulseSensor.type,pulseSensor }
            };
        }

        // function to active sensor
        public void ActivateSensor(int num,string type)
        {
            foreach (var keyValue in this.availableSensors)
            {
                if (type == keyValue.Key)
                {
                    keyValue.Value.Activate(num,room.attachedSensore);
                }
            }
        }
        // function to get how much is maches
        public int NumOfMatches()
        {
            return room.NumOfMatches(agent.GetSensorRequirementCount());
        }
    }
}
